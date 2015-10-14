using CookComputing.XmlRpc;

namespace Subtle.Model.Requests
{
    public class HashSearchQuery : SearchQuery
    {
        [XmlRpcMember("moviehash")]
        public string FileHash { get; set; }

        [XmlRpcMember("moviebytesize")]
        public double FileSize { get; set; }
    }
}
