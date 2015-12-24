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
        public string MatchMethod { get; set; }

        [XmlRpcMember("SubFeatured")]
        public string IsFeatured { get; set; }

        [XmlRpcMember("SubtitlesLink")]
        public string Url { get; set; }

        [XmlRpcMember("SubHearingImpaired")]
        public string IsHearingImpaired { get; set; }

        [XmlRpcMember("UserNickName")]
        public string UploaderName { get; set; }

        [XmlRpcMember("UserRank")]
        public string UploaderRank { get; set; }

        [XmlRpcMember("SubEncoding")]
        public string Encoding { get; set; }

        public static class SearchMethods
        {
            public const string Hash = "moviehash";
            public const string Imdb = "imdbid";
            public const string FullText = "fulltext";
            public const string Tag = "tag";
        }

        public static class UserRanks
        {
            public const string Platinum = "platinum member";
            public const string Gold = "gold member";
            public const string Silver = "silver member";
            public const string Bronze = "bronze member";
            public const string Trusted = "trusted";
            public const string Administrator = "administrator";
            public const string Leecher = "sub leecher";
            public const string Anonymous = "";
        }

        public static class Encodings
        {
            public const string Utf8 = "UTF-8";
            public const string Ascii = "ASCII";
            public const string Cp1252 = "CP1252";
            public const string Unknown = "Unknown";
        }
    }
}
