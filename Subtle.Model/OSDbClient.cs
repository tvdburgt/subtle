using System;
using System.Threading.Tasks;
using CookComputing.XmlRpc;
using Subtle.Model.Requests;
using Subtle.Model.Responses;
using System.Diagnostics;

namespace Subtle.Model
{
    public class OSDbClient
    {
        public const string ApiUrl = "http://api.opensubtitles.org/xml-rpc";
        public const string DefaultUserAgent = "tvdburgt";
        public const string TestUserAgent = "OSTestUserAgent";

        /// <summary>
        /// Default limit for SearchSubtitles. Maximum is 500.
        /// </summary>
        public const int SearchLimit = 100;

        private readonly IOSDbProxy proxy;
        private Session session;

        public OSDbClient() : this(DefaultUserAgent)
        {
        }

        public OSDbClient(string userAgent)
        {
            proxy = XmlRpcProxyGen.Create<IOSDbProxy>();
            proxy.Url = ApiUrl;
            proxy.UserAgent = userAgent;
            proxy.EnableCompression = true;
        }

        public void InitSession()
        {
            session = proxy.LogIn(
                username: string.Empty,
                password: string.Empty,
                language: string.Empty,
                userAgent: DefaultUserAgent);

            if (!session.IsSuccess)
            {
                throw new OSDbException(
                    $"Failed to initialize session: {session.Status}");
            }
        }

        public ServerInfo GetServerInfo()
        {
            var sw = Stopwatch.StartNew();
            var info = proxy.GetServerInfo();
            sw.Stop();
            info.ResponseTime = sw.Elapsed;
            return info;
        }

        public SubtitleFileCollection DownloadSubtitles(params string[] fileIds)
        {
            CheckSession();
            return proxy.DownloadSubtitles(session.Token, fileIds);
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

        public SubtitleSearchResultCollection SearchSubtitles(params SearchQuery[] query)
        {
            CheckSession();

            var options = new SearchOptions { Limit = SearchLimit };
            var result = proxy.SearchSubtitles(
                session.Token, query, options);

            if (!result.IsSuccess)
            {
                throw new OSDbException(
                    $"Subtitle search failed: {result.Status}");
            }

            return result;
        }

        public Task InitSessionAsync()
        {
            return Task.Run(() => InitSession());
        }

        public Task<SubtitleSearchResultCollection> SearchSubtitlesAsync(params SearchQuery[] query)
        {
            return Task.Run(() => SearchSubtitles(query));
        }

        public Task<SubtitleFileCollection> DownloadSubtitlesAsync(params string[] fileIds)
        {
            return Task.Run(() => DownloadSubtitles(fileIds));
        }

        public Task<ServerInfo> GetServerInfoAsync()
        {
            return Task.Run(() => GetServerInfo());
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
