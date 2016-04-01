using NUnit.Framework;
using Subtle.Model.Helpers;

namespace Subtle.Model.Test
{
    [TestFixture]
    public class VideoInfoTest
    {
        [TestCase("and.then.there.were.none.s01e01.hdtv.x264-river[ettv].mp4", "and then there were none", 1, 1)]
        [TestCase("Game.of.Thrones.S05E01.1080p.HDTV.x264-BATV.mkv", "Game of Thrones", 5, 1)]
        [TestCase("Pioneer.One.S01E01.720p.x264-VODO.mkv", "Pioneer One", 1, 1)]
        public void Extract_Episode(string filename, string title, int season, int episode)
        {
            var info = VideoInfo.Extract(filename);

            Assert.AreEqual(VideoType.Episode, info.Type);
            Assert.AreEqual(title, info.Title);
            Assert.AreEqual(season, info.Season);
            Assert.AreEqual(episode, info.Episode);
        }

        [TestCase("Stand.Off.2016.HDRip.XviD.AC3-EVO.avi", "Stand Off", 2016)]
        [TestCase("The.Big.Short.2015.1080p.WEB-DL.DD5.1.H264-RARBG.mkv", "The Big Short", 2015)]
        public void Extract_Movie(string filename, string title, int year)
        {
            var info = VideoInfo.Extract(filename);

            Assert.AreEqual(VideoType.Movie, info.Type);
            Assert.AreEqual(title, info.Title);
            Assert.AreEqual(year, info.Year);
        }

        [TestCase("The Wire Season 4 Episode 03 - Home Rooms.avi")]
        [TestCase("Burnt 2015 1080p BluRay x264 DTS-JYK.mkv")]
        public void Extract_Fail(string filename)
        {
            var info = VideoInfo.Extract(filename);
            Assert.AreEqual(VideoType.Undefined, info.Type);
        }
    }
}