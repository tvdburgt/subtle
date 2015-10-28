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
                var client = new OSDbClient(OSDbClient.TestUserAgent);
                await client.InitSessionAsync();

                var query = new ImdbSearchQuery
                {
                    LanguageIds = "eng",
                    ImdbId = "1559549",
                };

                var subs = await client.SearchSubtitlesAsync(query);

                File.WriteAllText("SearchSubtitles.json", JsonConvert.SerializeObject(subs, Formatting.Indented));

            }).Wait();
        }
    }
}
