using CookComputing.XmlRpc;

namespace Subtle.Model.Requests
{
    public class SearchOptions
    {
        [XmlRpcMember("limit")]
        public int Limit { get; set; }
    }
}
