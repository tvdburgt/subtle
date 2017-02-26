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
        public const string TestUserAgent = "OSTestUserAgentTemp";

        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(20);

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
            proxy.Timeout = (int)Timeout.TotalMilliseconds;
            proxy.EnableCompression = true;
        }

        public async Task<Session> InitSessionAsync()
        {
            var task = Task.Factory.FromAsync(
                (callback, state) => proxy.BeginLogIn(string.Empty, string.Empty, string.Empty, proxy.UserAgent, callback),
                proxy.EndLogIn,
                null);

            session = await ExecuteOSDbTask(task);
            return session;
        }

        public Task<SubtitleSearchResultCollection> SearchSubtitlesAsync(params SearchQuery[] query)
        {
            EnsureSession();

            var options = new SearchOptions { Limit = SearchLimit };
            var task = Task.Factory.FromAsync(
                (callback, state) => proxy.BeginSearchSubtitles(session.Token, query, options, callback),
                proxy.EndSearchSubtitles,
                null);

            return ExecuteOSDbTask(task);
        }

        public Task<SubtitleFileCollection> DownloadSubtitlesAsync(params string[] fileIds)
        {
            EnsureSession();

            var task = Task.Factory.FromAsync(
                (callback, state) => proxy.BeginDownloadSubtitles(session.Token, fileIds, callback),
                proxy.EndDownloadSubtitles,
                null);

            return ExecuteOSDbTask(task);
        }

        public async Task<ServerInfo> GetServerInfoAsync()
        {
            var watch = Stopwatch.StartNew();
            var task = Task.Factory.FromAsync(
                (callback, state) => proxy.BeginGetServerInfo(callback),
                proxy.EndGetServerInfo,
                null);

            var info = await task.WithTimeout(Timeout);

            watch.Stop();
            info.ResponseTime = watch.Elapsed;
            return info;
        }

        public LanguageCollection GetLanguages()
        {
            return proxy.GetLanguages();
        }

        private void EnsureSession()
        {
            if (string.IsNullOrEmpty(session?.Token))
            {
                throw new InvalidOperationException("Session is not initialized");
            }
        }

        private async Task<T> ExecuteOSDbTask<T>(Task<T> task) where T : OSDbResponse
        {
            try
            {
                var result = await task.WithTimeout(Timeout);
                if (!result.IsSuccess)
                {
                    throw new OSDbException(result);
                }
                return result;
            }
            catch (XmlRpcServerException e)
            {
                throw new OSDbException(e.Message, e);
            }
            catch (TimeoutException e)
            {
                throw new OSDbException(e.Message, e);
            }
        }
    }
}
