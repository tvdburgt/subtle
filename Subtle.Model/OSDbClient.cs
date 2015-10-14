using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CookComputing.XmlRpc;
using Subtle.Model.Requests;
using Subtle.Model.Responses;

namespace Subtle.Model
{
    public class OSDbClient
    {
        public const string UserAgent = "OSTestUserAgent"; // Subtle/0.1 (TODO: make configurable for test)
        public const string ApiUrl = "http://api.opensubtitles.org:80/xml-rpc";

        /// <summary>
        /// Default limit for SearchSubtitles. Maximum is 500.
        /// </summary>
        public const int SearchLimit = 100;

        private readonly IOSDbProxy proxy;
        private Session session;

        public OSDbClient()
        {
            proxy = XmlRpcProxyGen.Create<IOSDbProxy>();
            proxy.Url = ApiUrl;
            proxy.UserAgent = UserAgent;
        }

        public async Task InitSessionAsync()
        {
            session = await Task.Run(() => proxy.LogIn(
                string.Empty, string.Empty, string.Empty, UserAgent));

            if (session.StatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException(
                    $"Failed to initialize session: {session.Status}");
            }
        }

        public Task<SubtitleFile> DownloadSubtitleAsync(string fileId)
        {
            CheckSession();
            return Task.Run(() => proxy.DownloadSubtitles(
                session.Token,
                new[] { fileId }).First());
        }

        public Task<ImdbSearchResultCollection> SearchVideos(string query)
        {
            CheckSession();
            return Task.Run(() => proxy.SearchVideos(
                session.Token, query));
        }

        public LanguageCollection GetLanguages()
        {
            return proxy.GetLanguages();
        }

        public Task<SubtitleSearchResultCollection> SearchSubtitlesAsync(params SearchQuery[] query)
        {
            CheckSession();
            var settings = new SearchSettings { Limit = SearchLimit };
            return Task.Run(() => proxy.SearchSubtitles(
                session.Token, query, settings));
        }

        private void CheckSession()
        {
            if (string.IsNullOrEmpty(session?.Token))
            {
                throw new InvalidOperationException("Session is not initialized");
            }
        }
    }
}
