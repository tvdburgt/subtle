using CookComputing.XmlRpc;

namespace Subtle.Model.Requests
{
    public class TagSearchQuery : SearchQuery
    {
        [XmlRpcMember("tag")]
        public string Tag { get; set; }
    }
}
