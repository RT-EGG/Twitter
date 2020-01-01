using CoreTweet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Imetter
{
    enum TweetMediaType
    {
        Unknown,
        Image,
        Video
    }

    interface ITweetMedia
    {
        TweetMediaType MediaType { get; }
        long ID { get; }
        string URL { get; }
    }

    interface ITweetImageMedia
    {
        Image Image { get; }
    }

    abstract class TweetMedia : ITweetMedia
    {
        public static ITweetMedia Query(MediaEntity inEntity)
        {
            ITweetMedia result;
            if (!m_Medias.TryGetValue(inEntity.Id, out result)) {
                result = NewMedia(inEntity);
                m_Medias.Add(inEntity.Id, result);
            }

            return result;
        }

        public static async Task<ITweetMedia> QueryAsync(MediaEntity inEntity)
        {
            ITweetMedia result;
            if (!m_Medias.TryGetValue(inEntity.Id, out result)) {
                result = await NewMediaAsync(inEntity);
                m_Medias.Add(inEntity.Id, result);
            }

            return result;
        }

        private static ITweetMedia NewMedia(MediaEntity inEntity)
        {
            TweetMedia result = CreateInstance(inEntity);
            result.LoadResource();
            result.LastUpdateTime = DateTime.Now;
            return result;
        }

        private static async Task<ITweetMedia> NewMediaAsync(MediaEntity inEntity)
        {
            TweetMedia result = CreateInstance(inEntity);
            await result.LoadResourceAsync();
            result.LastUpdateTime = DateTime.Now;
            return result;
        }

        private static TweetMedia CreateInstance(MediaEntity inEntity)
        {
            switch (GetMediaType(inEntity)) {
                case TweetMediaType.Image:
                    return new TweetImageMedia(inEntity);
                default:
                    return null;
            }
        }

        public static TweetMediaType GetMediaType(MediaEntity inEntity)
        {
            string extension = Path.GetExtension(inEntity.MediaUrlHttps);
            switch (extension.ToLower()) {
                case ".jpg":
                case ".jpeg":
                case ".png":
                    return TweetMediaType.Image;
                default:
                    return TweetMediaType.Unknown;
            }
        }

        public TweetMedia(MediaEntity inEntity)
        {
            ID = inEntity.Id;
            URL = inEntity.MediaUrlHttps;
            return;
        }

        protected virtual void LoadResource()
        {
            return;
        }

        protected virtual async Task LoadResourceAsync()
        {
            await Task.Run(() => {
            });
            return;
        }

        public abstract TweetMediaType MediaType
        { get; }
        public long ID
        { get; private set; } = 0;
        public string URL
        { get; private set; } = "";
        public DateTime LastUpdateTime
        { get; private set; } = DateTime.Now;
 
        private static IDictionary<long, ITweetMedia> m_Medias = new Dictionary<long, ITweetMedia>();

        private class TweetImageMedia : TweetMedia, ITweetImageMedia
        {
            public TweetImageMedia(MediaEntity inEntity)
                : base (inEntity)
            {
                return;
            }

            public override TweetMediaType MediaType => TweetMediaType.Image;
            public Image Image
            { get; private set; } = null;

            protected override void LoadResource()
            {
                Image = ImageDownloader.Download(URL);
                return;
            }

            protected async override Task LoadResourceAsync()
            {
                Image = await ImageDownloader.DownloadAsync(URL);
                return;
            }
        }
    }
}
