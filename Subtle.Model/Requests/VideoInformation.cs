using CookComputing.XmlRpc;

namespace Subtle.Model.Requests
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class VideoInformation
    {
        /// <summary>
        /// Comma-separated list of ISO639-3 language codes
        /// </summary>
        [XmlRpcMember("sublanguageid")]
        public string LanguageIds { get; set; }

        [XmlRpcMember("moviehash")]
        public string FileHash { get; set; }

        [XmlRpcMember("moviebytesize")]
        public double FileSize { get; set; }

        [XmlRpcMember("imdbid")]
        public string ImdbId { get; set; }
    }
}
