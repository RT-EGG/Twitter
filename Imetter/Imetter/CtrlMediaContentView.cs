using System;
using System.Windows.Forms;
using System.Drawing;
using CoreTweet;

namespace Imetter
{
    public partial class CtrlMediaContentView : UserControl
    {
        // interface
        public event MediaMouseClickEvent OnMouseClickMedia;

        public bool ContainsInThumbnail(Point inPoint)
        {
            if (Media == null)
                return false;

            return GetMediaRect().Contains(inPoint);
        }

        public CtrlMediaContentView()
        {
            InitializeComponent();
        }

        public MediaEntity MediaEntity
        {
            get { return m_MediaEntity; }
            set {
                m_MediaEntity = value;
                if (MediaEntity != null) {
                    TweetMedia.Query(MediaEntity, (ITweetMedia inMedia) => {
                        Media = inMedia;
                        switch (Media.MediaType) {
                            case TweetMediaType.Image:
                                this.BackgroundImage = (Media as ITweetImageMedia).Image;
                                break;
                            default:
                                break;
                        }
                    });
                }
                return;
            }
        }

        private void CtrlMediaContentView_MouseClick(object sender, MouseEventArgs e)
        {
            if (ContainsInThumbnail(e.Location)) {
                MediaMouseClickEventArgs args = new MediaMouseClickEventArgs(e);
                args.Media = Media;

                OnMouseClickMedia?.Invoke(args);
            }
            return;
        }

        private Rectangle GetMediaRect()
        {
            Rectangle result = new Rectangle();
            if (BackgroundImage != null) {
                Image thumbnail = BackgroundImage;

                int width, height;
                if (((float)thumbnail.Width / (float)Width) < ((float)thumbnail.Height / (float)Height)) {
                    height = Height;
                    width = (int)Math.Truncate((float)thumbnail.Width * ((float)height / (float)thumbnail.Height));
                } else {
                    width = Width;
                    height = (int)Math.Truncate((float)thumbnail.Height * ((float)width / (float)thumbnail.Width));
                }

                result.X = (Width / 2) - (width / 2);
                result.Y = (Height / 2) - (height / 2);
                result.Width = width;
                result.Height = height;
            }

            return result;
        }

        private MediaEntity m_MediaEntity = null;
        private ITweetMedia Media
        { get; set; }
    }

    public interface IMediaClickEventArgs
    {
        ITweetMedia Media { get; }
    }

    public interface IMediaMouseClickEventArgs
    {

    }

    class MediaClickEventArgs : IMediaClickEventArgs
    {
        public ITweetMedia Media
        { get; set; } = null;
    }

    class MediaMouseClickEventArgs : MediaClickEventArgs, IMediaMouseClickEventArgs
    {
        public MediaMouseClickEventArgs(MouseEventArgs inArgs)
        {
            SourceArgs = inArgs;
            return;
        }

        public Point Loation => SourceArgs.Location;

        private MouseEventArgs SourceArgs
        { get; set; } = null;
    }

    public delegate void MediaMouseClickEvent(IMediaMouseClickEventArgs inMedia);
}
