using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    public class ServerInfo : OSDbResponse
    {
        [XmlRpcMember("xmlrpc_version")]
        public string XmlRpcVersion { get; set; }

        [XmlRpcMember("xmlrpc_url")]
        public string XmlRpcUrl { get; set; }

        [XmlRpcMember("application")]
        public string Application { get; set; }

        [XmlRpcMember("users_online_total")]
        public int OnlineUserCount { get; set; }
    }
}
