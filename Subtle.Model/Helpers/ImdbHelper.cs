using System.IO;
using System.Text.RegularExpressions;

namespace Subtle.Model.Helpers
{
    public static class ImdbHelper
    {
        private static readonly Regex ImdbRegex = new Regex(@"imdb\.\w{2,3}\/title\/tt(\d{7})");

        public static string GetImdbId(string filename)
        {
            var searchDir = Path.GetDirectoryName(filename);
            var filenames = Directory.GetFiles(searchDir, "*.nfo", SearchOption.AllDirectories);

            foreach (var fn in filenames)
            {
                var text = File.ReadAllText(fn);
                var match = ImdbRegex.Match(text);

                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
            }

            return null;
        }
    }
}
