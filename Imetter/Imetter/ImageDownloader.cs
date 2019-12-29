using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace TwitterTimeLine
{
    static class ImageDownloader
    {
        public static Image Download(string inURL)
        {
            byte[] data = m_WebClient.DownloadData(inURL);
            MemoryStream stream = new MemoryStream(data);
            return new Bitmap(stream);
        }

        public static async Task<Image> DownloadAsync(string inURL)
        {
            var data = await m_WebClient.DownloadDataTaskAsync(inURL);
            MemoryStream stream = new MemoryStream(data);
            return new Bitmap(stream);
            
        }

        private static WebClient m_WebClient = new WebClient();
    }
}
