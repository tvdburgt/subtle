using CookComputing.XmlRpc;
using Subtle.Model.Requests;
using Subtle.Model.Responses;
using System;

namespace Subtle.Model
{
    public interface IOSDbProxy : IXmlRpcProxy
    {
        [XmlRpcMethod("GetSubLanguages")]
        LanguageCollection GetLanguages(string language = "en");

        [XmlRpcBegin]
        IAsyncResult BeginSearchSubtitles(string token, SearchQuery[] query, SearchOptions options, AsyncCallback callback);
        [XmlRpcEnd]
        SubtitleSearchResultCollection EndSearchSubtitles(IAsyncResult result);

        [XmlRpcBegin]
        IAsyncResult BeginLogIn(string username, string password, string language, string userAgent, AsyncCallback callback);
        [XmlRpcEnd]
        Session EndLogIn(IAsyncResult result);

        [XmlRpcBegin]
        IAsyncResult BeginDownloadSubtitles(string token, string[] fileIds, AsyncCallback callback);
        [XmlRpcEnd]
        SubtitleFileCollection EndDownloadSubtitles(IAsyncResult result);

        [XmlRpcBegin("ServerInfo")]
        IAsyncResult BeginGetServerInfo(AsyncCallback callback);
        [XmlRpcEnd("ServerInfo")]
        ServerInfo EndGetServerInfo(IAsyncResult result);
    }
}