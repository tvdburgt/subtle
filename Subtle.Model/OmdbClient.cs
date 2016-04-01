using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Subtle.Model
{
    public class OmdbClient
    {
        private const int ApiVersion = 1;
        private const string ContentType = "json";
        private const string BaseAddress = "https://www.omdbapi.com/";

        private readonly HttpClient client;

        public OmdbClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);
        }

        public async Task<OmdbResponse> SearchMovieAsync(string title, int year)
        {
            var query = $"type=movie&t={title}&y={year}&r={ContentType}&v={ApiVersion}";
            return await SearchAsync(query);
        }

        public async Task<OmdbResponse> SearchEpisodeAsync(string title, int season, int episode)
        {
            var query = $"type=episode&t={title}&season={season}&episode={episode}&r={ContentType}&v={ApiVersion}";
            return await SearchAsync(query);
        }

        private async Task<OmdbResponse> SearchAsync(string query)
        {
            var response = await client.GetAsync("?" + query);

            if (!response.IsSuccessStatusCode)
            {
                return new OmdbResponse();
            }

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<OmdbResponse>(content);
            }
            catch (JsonException)
            {
                return new OmdbResponse();
            }
        }
    }

    public class OmdbResponse
    {
        [JsonProperty(PropertyName = "imdbID")]
        public string ImdbId { get; set; }

        [JsonProperty(PropertyName = "Response")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "Error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "Poster")]
        public string PosterUrl { get; set; }

        [JsonIgnore]
        public string ImdbIdTrimmed
        {
            get
            {
                return ImdbId?.Trim()?.TrimStart('t');
            }
        }

        [JsonIgnore]
        public string ImdbUrl
        {
            get
            {
                if (string.IsNullOrEmpty(ImdbId))
                {
                    return null;
                }

                return $"http://www.imdb.com/title/{ImdbId}/";
            }
        }
    }
}
