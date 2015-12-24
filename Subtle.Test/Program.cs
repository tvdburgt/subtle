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
            var client = new OSDbClient(OSDbClient.TestUserAgent);
            client.InitSession();

            var query = new ImdbSearchQuery
            {
                LanguageIds = "eng",
                ImdbId = "0111161",
            };

            var subs = client.SearchSubtitles(query);

            File.WriteAllText("SearchSubtitles.json", JsonConvert.SerializeObject(subs, Formatting.Indented));
        }
    }
}
