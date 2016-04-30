using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Subtle.Model;
using Subtle.Model.Helpers;
using Subtle.Model.Requests;
using Subtle.Model.Responses;
using System.Threading.Tasks;
using AutoMapper;
using Subtle.Model.Models;
using Subtle.Model.Mapping;

namespace Subtle.Cli
{
    class Program
    {
        private static readonly string[] SubtitleTypes = { "srt", "sub", "smi", "ssa", "ass", "mpl" };
        private static readonly Regex IgnorePattern = new Regex(@"sample$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static OSDbClient client;
        private static SubtleOptions options;
        private static Language language;

        static int Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile<OSDbProfile>());

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

            return MainAsync().GetAwaiter().GetResult();
        }

        private static async Task<int> MainAsync()
        {
            IEnumerable<string> files = Enumerable.Empty<string>();

            if (Directory.Exists(options.Path))
            {
                files = ScanDirectory(options.Path);
            }
            else if (File.Exists(options.Path))
            {
                if (options.Replace || !HasSubtitle(options.Path))
                {
                    files = new[] { options.Path };
                }
            }
            else
            {
                Console.WriteLine("Path must be an existing file or directory.");
                Console.WriteLine(options.GetUsage());
                return 1;
            }

            await client.InitSessionAsync();
            var searchTasks = files.Select(f => SearchSubtitleAsync(f));

            var subs = (await Task.WhenAll(searchTasks)).AsEnumerable();
            subs = subs.Where(s => s.Selection != null);

            if (!options.DryRun && subs.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Downloading...");
                await DownloadSubtitlesAsync(subs);
                Console.WriteLine("Done!");
            }

            return 0;
        }

        private static async Task<SubtitleSelection> SearchSubtitleAsync(string file)
        {
            var hash = Crypto.HashFile(file);
            var fileInfo = new FileInfo(file);

            var subs = await client.SearchSubtitlesAsync(
                new HashSearchQuery
                {
                    LanguageIds = language.Iso6392,
                    FileHash = Crypto.BinaryToHex(hash),
                    FileSize = fileInfo.Length,
                });

            var selection = SelectSubtitle(Mapper.Map<Subtitle[]>(subs));

            if (selection == null)
            {
                Console.WriteLine("{0} {1}", Keyword("NotFound"), fileInfo.Name);
            }
            else
            {
                Console.WriteLine("{0} {1}", Keyword(selection.MatchMethod), fileInfo.Name);
            }

            return new SubtitleSelection
            {
                File = file,
                Selection = selection
            };
        }

        private static async Task DownloadSubtitlesAsync(IEnumerable<SubtitleSelection> subs)
        {
            if (!subs.Any())
            {
                return;
            }

            var downloads = await client.DownloadSubtitlesAsync(subs.Select(s => s.Selection.Id).ToArray());

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
            var searchOption = options.Shallow ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories;
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
                    Console.WriteLine("{0} {1}", Keyword("Ignored"), Path.GetFileName(file));
                    continue;
                }

                if (!options.Replace && HasSubtitle(file))
                {
                    Console.WriteLine("{0} {1}", Keyword("Skipped"), Path.GetFileName(file));
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
        private static Subtitle SelectSubtitle(IEnumerable<Subtitle> subs)
        {
            return subs
                .OrderByDescending(s => s.IsFeatured)
                .ThenByDescending(s => s.Rating)
                .ThenByDescending(s => s.DownloadCount)
                .FirstOrDefault();
        }

        private static bool HasSubtitle(string file)
        {
            var dir = Path.GetDirectoryName(file);
            var name = Path.GetFileNameWithoutExtension(file);
            return SubtitleTypes.Any(type => File.Exists($@"{dir}\{name}.{type}"));
        }

        private static string Keyword(object value)
        {
            return $"{$"[{value.ToString()}]",-12}";
        }
    }
}
