using CookComputing.XmlRpc;

namespace Subtle.Model.Requests
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public abstract class SearchQuery
    {
        /// <summary>
        /// Comma-separated list of ISO639-3 language codes
        /// </summary>
        [XmlRpcMember("sublanguageid")]
        public string LanguageIds { get; set; }

        [XmlRpcMember("season")]
        public string Season { get; set; }

        [XmlRpcMember("episode")]
        public string Episode { get; set; }
    }
}
