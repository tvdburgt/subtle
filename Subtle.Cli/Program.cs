using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Subtle.Model;
using Subtle.Model.Helpers;
using Subtle.Model.Requests;
using Subtle.Model.Responses;

namespace Subtle.Cli
{
    class Program
    {
        private static readonly string[] SubtitleTypes = { "srt", "sub", "smi", /*"txt",*/ "ssa", "ass", "mpl" };
        private static readonly Regex IgnorePattern = new Regex(@"sample$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static OSDbClient client;
        private static SubtleOptions options;
        private static Language language;

        static int Main(string[] args)
        {
            client = new OSDbClient(OSDbClient.DefaultUserAgent);
            options = new SubtleOptions();
            CommandLine.Parser.Default.ParseArgumentsStrict(args, options);

            if (string.IsNullOrEmpty(options.Path))
            {
                Console.WriteLine("Missing path.");
                Console.WriteLine(options.GetUsage());
                return 1;
            }

            language = OSDbConfig.Languages.SingleOrDefault(l =>
                options.Language.Equals(l.Iso6391, StringComparison.OrdinalIgnoreCase) ||
                options.Language.Equals(l.Iso6392, StringComparison.OrdinalIgnoreCase));

            if (language == null)
            {
                Console.WriteLine("Unrecognized language code.");
                Console.WriteLine(options.GetUsage());
                return 1;
            }

            if (Directory.Exists(options.Path))
            {
                client.InitSession();
                var results = ScanDirectory(options.Path)
                    .Select(SearchSubtitle)
                    .Where(s => s.Selection != null)
                    .ToList();

                if (!options.DryRun)
                {
                    Console.WriteLine();
                    Console.WriteLine("Downloading...");
                    DownloadSubtitles(results);
                    Console.WriteLine("Done!");
                }
            }
            else if (File.Exists(options.Path))
            {
                client.InitSession();
                var sub = SearchSubtitle(options.Path);
                if (sub.Selection != null && !options.DryRun)
                {
                    DownloadSubtitle(sub);
                }
            }
            else
            {
                Console.WriteLine("Path must be an existing file or directory.");
                Console.WriteLine(options.GetUsage());
                return 1;
            }

            return 0;
        }

        private static SubtitleSelection SearchSubtitle(string file)
        {
            var hash = Crypto.HashFile(file);
            var fileInfo = new FileInfo(file);

            var subs = client.SearchSubtitles(
                new HashSearchQuery
                {
                    LanguageIds = language.Iso6392,
                    FileHash = Crypto.BinaryToHex(hash),
                    FileSize = fileInfo.Length,
                });

            var selection = SelectSubtitle(subs);

            if (selection == null)
            {
                Console.WriteLine($"[notfound]\t{file}");
            }
            else
            {
                Console.WriteLine($"[{selection.MatchMethod}]\t{file}");
            }

            return new SubtitleSelection
            {
                File = file,
                Selection = selection
            };
        }

        private static void DownloadSubtitle(SubtitleSelection sub)
        {
            DownloadSubtitles(new[] { sub });
        }

        private static void DownloadSubtitles(ICollection<SubtitleSelection> subs)
        {
            if (subs.Count == 0)
            {
                return;
            }

            var downloads = client.DownloadSubtitles(subs.Select(s => s.Selection.Id).ToArray());

            foreach (var file in downloads)
            {
                var sub = subs.First(s => s.Selection.Id == file.Id); // Same subtitle might be used for multiple files
                var path = Path.ChangeExtension(sub.File, sub.Selection.FileFormat);
                var data = Convert.FromBase64String(file.Base64Data);
                File.WriteAllBytes(path, Gzip.Decompress(data));
            }
        }

        private static IEnumerable<string> ScanDirectory(string path)
        {
            var searchOption = SearchOption.AllDirectories;

            if (options.Shallow)
            {
                searchOption = SearchOption.TopDirectoryOnly;
            }

            var files = Directory.EnumerateFiles(path, "*", searchOption);

            foreach (var file in files)
            {
                var ext = Path.GetExtension(file).TrimStart('.');

                if (!FileTypes.VideoTypes.Contains(ext))
                {
                    continue;
                }

                if (IgnorePattern.IsMatch(Path.GetFileNameWithoutExtension(file)))
                {
                    Console.WriteLine($"[ignored]\t{file}");
                    //Console.WriteLine($@"Skipping ""{file}"": matched ignore pattern");
                    continue;
                }

                if (!options.Replace && HasSubtitle(file))
                {
                    Console.WriteLine($"[skipped]\t{file}");
                    //Console.WriteLine($@"Skipping ""{file}"": already has matching subtitle");
                    continue;
                }

                yield return file;
            }
        }

        /// <summary>
        /// Selects best matching subtitle.
        /// </summary>
        /// <param name="subs"></param>
        /// <returns></returns>
        private static SubtitleSearchResult SelectSubtitle(IEnumerable<SubtitleSearchResult> subs)
        {
            return subs
                .OrderByDescending(s => int.Parse(s.IsFeatured))
                .ThenByDescending(s => decimal.Parse(s.Rating))
                .ThenByDescending(s => int.Parse(s.DownloadCount))
                .FirstOrDefault();
        }

        private static bool HasSubtitle(string file)
        {
            var dir = Path.GetDirectoryName(file);
            var name = Path.GetFileNameWithoutExtension(file);
            return SubtitleTypes.Any(type => File.Exists($@"{dir}\{name}.{type}"));
        }
    }
}
