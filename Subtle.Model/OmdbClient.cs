using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Subtle.Model
{
    public class OmdbClient
    {
        private const int ApiVersion = 1;
        private const string ContentType = "json";
        private const string BaseAddress = "https://www.omdbapi.com/";

        private TimeSpan Timeout => TimeSpan.FromMilliseconds(2000);

        private readonly HttpClient client;

        public OmdbClient()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseAddress),
                Timeout = Timeout
            };
        }

        public async Task<OmdbResponse> SearchMovieAsync(string title, int year)
        {
            return await SearchAsync(new Dictionary<string, string>
            {
                { "type", "movie" },
                { "t", title },
                { "y", year.ToString() },
                { "r", ContentType },
                { "v", ApiVersion.ToString() },
            });
        }

        public async Task<OmdbResponse> SearchEpisodeAsync(string title, int season, int episode)
        {
            return await SearchAsync(new Dictionary<string, string>
            {
                { "type", "episode" },
                { "t", title },
                { "season", season.ToString() },
                { "episode", episode.ToString() },
                { "r", ContentType },
                { "v", ApiVersion.ToString() },
            });
        }

        private async Task<OmdbResponse> SearchAsync(IDictionary<string, string> parameters)
        {
            var query = string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}"));
            return await SearchAsync(query);
        }

        private async Task<OmdbResponse> SearchAsync(string query)
        {
            HttpResponseMessage response;

            try
            {
                response = await client.GetAsync("?" + query.TrimStart('?'));
            }
            catch (TaskCanceledException)
            {
                // Timeout occurred
                return new OmdbResponse();
            }

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
        public string ImdbIdTrimmed => ImdbId?.Trim().TrimStart('t');

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
