using CoreTweet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Imetter
{
    delegate void MediaReadyEvent(ITweetMedia inMedia);

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
        Image Thumbnail { get; }
    }

    abstract class TweetMedia : ITweetMedia
    {
        public static void Query(MediaEntity inEntity, MediaReadyEvent inOnMediaReady)
        {
            if (m_Medias.TryGetValue(inEntity.Id, out ITweetMedia result)) {
                inOnMediaReady?.Invoke(result);
            } else {
                NewMedia(inEntity, (ITweetMedia inMedia) => {
                    m_Medias.Add(inEntity.Id, inMedia);
                    inOnMediaReady?.Invoke(inMedia);
                });
            }
            return;
        }

        private static ITweetMedia NewMedia(MediaEntity inEntity, MediaReadyEvent inOnMediaReady)
        {
            TweetMedia result = CreateInstance(inEntity);
            result.LoadResource(inOnMediaReady);
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
            RawData = inEntity;
            return;
        }

        protected virtual void LoadResource(MediaReadyEvent inEvent)
        {
            return;
        }

        public abstract TweetMediaType MediaType
        { get; }
        protected MediaEntity RawData
        { get; private set; } = null;
        public long ID
        { get => RawData.Id; }
        public string URL
        { get => RawData.MediaUrlHttps; }
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
            Image ITweetImageMedia.Image => Image;
            Image ITweetImageMedia.Thumbnail => Thumbnail;
            public Bitmap Image
            { get; private set; } = null;
            public Bitmap Thumbnail
            { get; private set; } = null;

            protected override void LoadResource(MediaReadyEvent inEvent)
            {
                ImageDownloader.DownloadAsync(URL, (Bitmap inImage) => {
                    Image = inImage;
                    if ((RawData.Sizes != null) && (RawData.Sizes.Thumb != null)) {
                        switch (RawData.Sizes.Thumb.Resize) {
                            case "crop":
                                Rectangle rect = new Rectangle();
                                rect.X = (Image.Width / 2) - (RawData.Sizes.Thumb.Width / 2);
                                rect.Y = (Image.Height / 2) - (RawData.Sizes.Thumb.Height / 2);
                                rect.Width = RawData.Sizes.Thumb.Width;
                                rect.Height = RawData.Sizes.Thumb.Height;
                                Thumbnail = Image.Clone(rect, Image.PixelFormat);
                                break;
                            case "fit":
                                break;
                            default:
                                break;
                        }
                    }

                    inEvent?.Invoke(this);
                });
                return;
            }
        }
    }
}
