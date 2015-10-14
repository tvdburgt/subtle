using CookComputing.XmlRpc;

namespace Subtle.Model.Requests
{
    public class SearchSettings
    {
        [XmlRpcMember("limit")]
        public int Limit { get; set; }
    }
}
