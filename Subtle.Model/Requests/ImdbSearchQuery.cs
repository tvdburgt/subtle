using CookComputing.XmlRpc;

namespace Subtle.Model.Requests
{
    public class ImdbSearchQuery : SearchQuery
    {
        [XmlRpcMember("imdbid")]
        public string ImdbId { get; set; }
    }
}
