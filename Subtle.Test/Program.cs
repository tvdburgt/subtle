using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Subtle.Model;
using Subtle.Model.Requests;

namespace Subtle.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var client = new OSDbClient();
                await client.InitSessionAsync();

                var query = new FullTextSearchQuery
                {
                    LanguageIds = "eng",
                    Query = "Limitless (2015) S01E03 1080p WEB-DL x264 nl subs",
                    Season = "1",
                    Episode = "2"
                };

                var subs = await client.SearchSubtitlesAsync(query);

                File.WriteAllText("SearchSubtitles.json", JsonConvert.SerializeObject(subs, Formatting.Indented));

            }).Wait();
        }
    }
}
