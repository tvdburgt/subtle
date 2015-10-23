using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    public class Language
    {
        /// <summary>
        /// ISO 639-2 (three-letter) code
        /// </summary>
        [XmlRpcMember("SubLanguageID")]
        public string Id { get; set; }

        [XmlRpcMember("LanguageName")]
        public string Name { get; set; }

        /// <summary>
        /// ISO 639-1 (two-letter) code
        /// </summary>
        [XmlRpcMember("ISO639")]
        public string Iso639Code { get; set; }
    }
}