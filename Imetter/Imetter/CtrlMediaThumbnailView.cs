using System;
using System.Windows.Forms;
using System.Drawing;
using CoreTweet;

namespace Imetter
{
    public partial class CtrlMediaThumbnailView : CtrlImageView
    {
        // interface
        public event MediaMouseClickEvent OnMouseClickMedia;

        public bool ContainsInThumbnail(Point inPoint)
        {
            if (Media == null)
                return false;

            return ImageDisplayRectangle.Contains(inPoint);
        }

        public CtrlMediaThumbnailView()
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
                                Image = (Media as ITweetImageMedia).Image;
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

                OnMouseClickMedia?.Invoke(this, args);
            }
            return;
        }

        private MediaEntity m_MediaEntity = null;
        private ITweetMedia Media
        { get; set; }
    }

    public interface IMediaClickEventArgs
    {
        ITweetMedia Media { get; }
    }

    public interface IMediaMouseClickEventArgs : IMediaClickEventArgs
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

    public delegate void MediaMouseClickEvent(object inSender, IMediaMouseClickEventArgs inMedia);
}
