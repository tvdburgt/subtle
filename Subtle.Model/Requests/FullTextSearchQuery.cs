using CookComputing.XmlRpc;

namespace Subtle.Model.Requests
{
    public class FullTextSearchQuery : SearchQuery
    {
        [XmlRpcMember("query")]
        public string Query { get; set; }
    }
}
