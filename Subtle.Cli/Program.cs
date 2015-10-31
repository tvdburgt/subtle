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
        private const string LanguageId = "eng";

        private static readonly string[] SubtitleTypes = { "srt", "sub", "smi", /*"txt",*/ "ssa", "ass", "mpl" };
        private static readonly Regex IgnorePattern = new Regex(@"sample$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static OSDbClient client;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Nowhere to look...");
                return;
            }

            client = new OSDbClient(OSDbClient.DefaultUserAgent);

            client.InitSession();

            var path = args[0];

            if (Directory.Exists(path))
            {
                var results = ScanDirectory(path)
                    .Select(SearchSubtitle)
                    .Where(s => s.Selection != null)
                    .ToList();

                Console.WriteLine();
                DownloadSubtitles(results);
            }
            else if (File.Exists(path))
            {
                var sub = SearchSubtitle(path);
                if (sub.Selection != null)
                {
                    DownloadSubtitle(sub);
                }
            }
            else
            {
                Console.WriteLine("Path must be an existing file or directory.");
            }
        }

        private static SubtitleSelection SearchSubtitle(string file)
        {
            var hash = Crypto.HashFile(file);
            var fileInfo = new FileInfo(file);

            var subs = client.SearchSubtitles(
                new HashSearchQuery
                {
                    LanguageIds = LanguageId,
                    FileHash = Crypto.BinaryToHex(hash),
                    FileSize = fileInfo.Length,
                });

            var selection = SelectSubtitle(subs);

            if (selection == null)
            {
                Console.WriteLine($@"Skipping ""{file}"": no search results");
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

            var files = client.DownloadSubtitles(subs.Select(s => s.Selection.Id).ToArray());

            foreach (var file in files)
            {
                var sub = subs.Single(s => s.Selection.Id == file.Id);
                var path = Path.ChangeExtension(sub.File, sub.Selection.FileFormat);
                var data = Convert.FromBase64String(file.Base64Data);

                File.WriteAllBytes(path, Gzip.Decompress(data));
                Console.WriteLine($@"Downloaded ""{path}""");
            }
        }

        private static IEnumerable<string> ScanDirectory(string path)
        {
            var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var ext = Path.GetExtension(file).TrimStart('.');

                if (!FileTypes.VideoTypes.Contains(ext))
                {
                    continue;
                }

                if (IgnorePattern.IsMatch(Path.GetFileNameWithoutExtension(file)))
                {
                    Console.WriteLine($@"Skipping ""{file}"": matched ignore pattern");
                    continue;
                }

                if (HasSubtitle(file))
                {
                    Console.WriteLine($@"Skipping ""{file}"": already has matching subtitle");
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
