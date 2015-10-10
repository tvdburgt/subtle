using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    public class Session : OSDbResponse
    {
        [XmlRpcMember("token")]
        public string Token { get; set; }
    }
}
