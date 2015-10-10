using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    public class ImdbSearchResult
    {
        [XmlRpcMember("id")]
        public string Id { get; set; }

        [XmlRpcMember("title")]
        public string Title { get; set; }
    }
}
