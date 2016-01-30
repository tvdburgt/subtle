using CookComputing.XmlRpc;
using System;

namespace Subtle.Model.Responses
{
    public class ServerInfo
    {
        [XmlRpcMember("xmlrpc_version")]
        public string ApiVersion { get; set; }

        [XmlRpcMember("xmlrpc_url")]
        public string ApiUrl { get; set; }

        [XmlRpcMember("website_url")]
        public string WebsiteUrl { get; set; }

        [XmlRpcMember("application")]
        public string Application { get; set; }

        [XmlRpcMember("users_online_total")]
        public int OnlineUserCount { get; set; }

        [XmlRpcMember("users_online_program")]
        public int OnlineClientCount { get; set; }

        [XmlRpcMember("subs_subtitle_files")]
        public string SubtitleCount { get; set; }

        [XmlRpcMember("download_limits")]
        public DownloadQuota DownloadQuota { get; set; }

        [XmlRpcMember("seconds")]
        public double ServerTime { get; set; }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public TimeSpan ResponseTime { get; set; }
    }

    public class DownloadQuota
    {
        [XmlRpcMember("client_download_quota")]
        public int Remaining { get; set; }

        [XmlRpcMember("client_24h_download_limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Scope (e.g., <c>user_ip</c>) that determines subtitle download quota.
        /// </summary>
        [XmlRpcMember("limit_check_by")]
        public string Scope { get; set; }

        [XmlRpcMember("client_ip")]
        public string ClientIp { get; set; }
    }
}
