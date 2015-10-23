using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    public class Language
    {
        /// <summary>
        /// ISO 639-1 (two-letter) code
        /// </summary>
        [XmlRpcMember("ISO639")]
        public string Iso6391 { get; set; }

        /// <summary>
        /// ISO 639-2 (three-letter) code
        /// </summary>
        [XmlRpcMember("SubLanguageID")]
        public string Iso6392 { get; set; }

        [XmlRpcMember("LanguageName")]
        public string Name { get; set; }
    }
}