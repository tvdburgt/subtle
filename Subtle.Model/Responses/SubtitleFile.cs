using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    public class SubtitleFile
    {
        [XmlRpcMember("idsubtitlefile")]
        public string Id { get; set; }

        [XmlRpcMember("data")]
        public string Base64Data { get; set; }
    }
}
