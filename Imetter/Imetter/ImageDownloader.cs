using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Imetter
{
    delegate void ImageDownloadedEvent(Bitmap inImage);
    delegate void ImagesDownloadedEvent(Bitmap[] inImage);

    class ImageDownloader
    {
        public static void Download(string[] inURL, ImagesDownloadedEvent inOnDownloaded)
        {
            GetInstance().Download_(inURL, inOnDownloaded);
            return;
        }

        public static void DownloadAsync(string inURL, ImageDownloadedEvent inOnDownloaded)
        {
            WebClient client = new WebClient();
            client.DownloadDataCompleted += (object sender, DownloadDataCompletedEventArgs e) => {
                MemoryStream stream = new MemoryStream(e.Result);
                inOnDownloaded?.Invoke(new Bitmap(stream));
            };
            client.DownloadDataAsync(new Uri(inURL));
            return;
        }

        private static void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static async Task<Bitmap[]> DownloadAsync(string[] inURL)
        {
            Bitmap[] result = new Bitmap[inURL.Length];
            WebClient client = new WebClient();
            for (int i = 0; i < result.Length; ++i) {
                var data = await client.DownloadDataTaskAsync(inURL[i]);
                MemoryStream stream = new MemoryStream(data);
                result[i] = new Bitmap(stream);
            }

            return result;
        }

        private ImageDownloader()
        {
            m_DownloadThread = new Thread(new ThreadStart(this.OnDownloadThread));
            m_DownloadThread.Start();
            return;
        }

        ~ImageDownloader()
        {
            m_DownloadThread.Abort();
            m_DownloadThread.Join();
            return;
        }

        private void Download_(string[] inURL, ImagesDownloadedEvent inOnDownloaded)
        {
            DownloadQueue queue = new DownloadQueue();
            queue.URL = inURL;
            queue.Event = inOnDownloaded;

            lock (m_DownloadQueue) {
                m_DownloadQueue.Enqueue(queue);
            }
            switch (m_DownloadThread.ThreadState) {
                case ThreadState.Unstarted:
                    m_DownloadThread.Start();
                    break;
                case ThreadState.Stopped:
                case ThreadState.Suspended:
                    break;
            }

            //if (m_DownloadThread.ThreadState != ThreadState.Unstarted)
            //    m_DownloadThread.Start();
            return;
        }

        private void OnDownloadThread()
        {
            try {
                while (true) {
                    lock (m_DownloadQueue) {
                        if (m_DownloadQueue.Count <= 0) {
                            Thread.Sleep(100);
                            break;
                        }
                        var queue = m_DownloadQueue.Dequeue();

                        Bitmap[] result = new Bitmap[queue.URL.Length];
                        for (int i = 0; i < result.Length; ++i) {
                            var data = m_WebClient.DownloadData(queue.URL[i]);
                            MemoryStream stream = new MemoryStream(data);
                            result[i] = new Bitmap(stream);
                        }

                        queue.Event(result);
                    }
                }
            } catch /*(ThreadAbortException abort)*/ {
            }
            return;
        }

        private static ImageDownloader GetInstance()
        {
            return m_Instance;
        }

        private class DownloadQueue
        {
            public string[] URL = null;
            public ImagesDownloadedEvent Event = null;
        }

        private static ImageDownloader m_Instance = new ImageDownloader();
        private Thread m_DownloadThread = null;
        private Queue<DownloadQueue> m_DownloadQueue = new Queue<DownloadQueue>();
        private WebClient m_WebClient = new WebClient();
    }
}
