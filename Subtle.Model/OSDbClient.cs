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

        private readonly IOSDbProxy _proxy;
        private Session _session;

        public OSDbClient() : this(DefaultUserAgent)
        {
        }

        public OSDbClient(string userAgent)
        {
            _proxy = XmlRpcProxyGen.Create<IOSDbProxy>();
            _proxy.Url = ApiUrl;
            _proxy.UserAgent = userAgent;
            _proxy.Timeout = (int)Timeout.TotalMilliseconds;
            _proxy.EnableCompression = true;
        }

        public async Task<Session> InitSessionAsync()
        {
            var task = Task.Factory.FromAsync(
                (callback, state) => _proxy.BeginLogIn(string.Empty, string.Empty, string.Empty, _proxy.UserAgent, callback),
                _proxy.EndLogIn,
                null);

            _session = await ExecuteOSDbTask(task);
            return _session;
        }

        public Task<SubtitleSearchResultCollection> SearchSubtitlesAsync(params SearchQuery[] query)
        {
            EnsureSession();

            var options = new SearchOptions { Limit = SearchLimit };
            var task = Task.Factory.FromAsync(
                (callback, state) => _proxy.BeginSearchSubtitles(_session.Token, query, options, callback),
                _proxy.EndSearchSubtitles,
                null);

            return ExecuteOSDbTask(task);
        }

        public Task<SubtitleFileCollection> DownloadSubtitlesAsync(params string[] fileIds)
        {
            EnsureSession();

            var task = Task.Factory.FromAsync(
                (callback, state) => _proxy.BeginDownloadSubtitles(_session.Token, fileIds, callback),
                _proxy.EndDownloadSubtitles,
                null);

            return ExecuteOSDbTask(task);
        }

        public async Task<ServerInfo> GetServerInfoAsync()
        {
            var watch = Stopwatch.StartNew();
            var task = Task.Factory.FromAsync(
                (callback, state) => _proxy.BeginGetServerInfo(callback),
                _proxy.EndGetServerInfo,
                null);

            var info = await task.WithTimeout(Timeout);

            watch.Stop();
            info.ResponseTime = watch.Elapsed;
            return info;
        }

        public LanguageCollection GetLanguages()
        {
            return _proxy.GetLanguages();
        }

        private void EnsureSession()
        {
            if (string.IsNullOrEmpty(_session?.Token))
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
