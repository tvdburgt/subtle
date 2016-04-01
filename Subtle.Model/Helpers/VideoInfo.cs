using System.IO;
using System.Text.RegularExpressions;

namespace Subtle.Model.Helpers
{
    public class VideoInfo
    {
        private VideoInfo()
        {
        }

        private VideoInfo(string title, VideoType type, int year, int season, int episode)
        {
            Title = title;
            Type = type;
            Year = year;
            Season = season;
            Episode = episode;
        }

        public string Title { get; }
        public VideoType Type { get; }
        public int Year { get; }
        public int Season { get; }
        public int Episode { get; }

        public static VideoInfo Extract(string input)
        {
            input = Path.GetFileNameWithoutExtension(input);

            // Try to match episode format
            var re = new Regex(@"^(?<Title>.+)\.S(?<Season>\d{2})E(?<Episode>\d{2})", RegexOptions.IgnoreCase);
            var match = re.Match(input);
            if (match.Success)
            {
                return new VideoInfo(
                    title: match.Groups["Title"].Value.Replace('.', ' '),
                    type: VideoType.Episode,
                    year: 0,
                    season: int.Parse(match.Groups["Season"].Value),
                    episode: int.Parse(match.Groups["Episode"].Value));
            }

            // Try to match movie format
            re = new Regex(@"^(?<Title>.+)\.(?<Year>\d{4})(\..*)?$", RegexOptions.IgnoreCase);
            match = re.Match(input);
            if (match.Success)
            {
                return new VideoInfo(
                    title: match.Groups["Title"].Value.Replace('.', ' '),
                    type: VideoType.Movie,
                    year: int.Parse(match.Groups["Year"].Value),
                    season: 0,
                    episode: 0);
            }

            return new VideoInfo();
        }
    }

    public enum VideoType
    {
        Undefined,
        Movie,
        Episode,
    }
}