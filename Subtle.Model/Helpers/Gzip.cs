using System.IO;
using System.IO.Compression;

namespace Subtle.Model.Helpers
{
    public static class Gzip
    {
        public static byte[] Decompress(byte[] data)
        {
            using (var inStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(inStream, CompressionMode.Decompress))
            using (var outStream = new MemoryStream())
            {
                zipStream.CopyTo(outStream);
                return outStream.ToArray();
            }
        }
    }
}
