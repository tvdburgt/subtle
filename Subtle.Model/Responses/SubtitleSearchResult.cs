using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    public class SubtitleSearchResult
    {
        [XmlRpcMember("IDSubtitleFile")]
        public string Id { get; set; }

        [XmlRpcMember("SubFileName")]
        public string FileName { get; set; }

        [XmlRpcMember("SubLanguageID")]
        public string LanguageId { get; set; }

        [XmlRpcMember("LanguageName")]
        public string Language { get; set; }

        [XmlRpcMember("SubFormat")]
        public string FileFormat { get; set; }

        [XmlRpcMember("SubAddDate")]
        public string UploadDate { get; set; }

        [XmlRpcMember("SubRating")]
        public string Rating { get; set; }

        [XmlRpcMember("SubDownloadsCnt")]
        public string DownloadCount { get; set; }

        [XmlRpcMember("MatchedBy")]
        public string MatchedBy { get; set; }

        [XmlRpcMember("SubFeatured")]
        public string IsFeatured { get; set; }

        [XmlRpcMember("SubtitlesLink")]
        public string Url { get; set; }

        public static class MatchMethods
        {
            public const string Hash = "moviehash";
            public const string Imdb = "???";
        }
    }
}
