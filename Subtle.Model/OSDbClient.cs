using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CookComputing.XmlRpc;
using Subtle.Model.Helpers;
using Subtle.Model.Requests;
using Subtle.Model.Responses;

namespace Subtle.Model
{
    public class OSDbClient
    {
        public const string UserAgent = "OSTestUserAgent"; // Subtle/0.1
        public const string ApiUrl = "http://api.opensubtitles.org:80/xml-rpc";

        private readonly IOSDbProxy proxy;
        private Session session;

        public OSDbClient()
        {
            proxy = XmlRpcProxyGen.Create<IOSDbProxy>();
            proxy.Url = ApiUrl;
            proxy.UserAgent = UserAgent;
        }

        public async Task Login()
        {
            session = await Task.Run(() => proxy.LogIn(
                string.Empty, string.Empty, string.Empty, UserAgent));

            if (session.StatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException(
                    $"Failed to initialize session: {session.Status}");
            }
        }

        public Task<SubtitleSearchResultCollection> SearchSubtitlesAsync(byte[] hash, long fileSize, IEnumerable<string> languageIds)
        {
            CheckSession();

            var info = new VideoInformation
            {
                FileHash = Crypto.BinaryToHex(hash),
                LanguageIds = string.Join(",", languageIds),
                FileSize = fileSize
            };

            return Task.Run(() => proxy.SearchSubtitles(
                session.Token,
                new[] { info }));
        }

        public Task<SubtitleFile> DownloadSubtitleAsync(string fileId)
        {
            CheckSession();

            return Task.Run(() => proxy.DownloadSubtitles(
                session.Token,
                new[] { fileId }).First());
        }

        public LanguageCollection GetLanguages()
        {
            return proxy.GetLanguages();
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
