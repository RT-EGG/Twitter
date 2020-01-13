using System.Windows.Forms;
using System.Drawing;

namespace Imetter
{
    class TweetMediaPlayer
    {
        public static TweetMediaPlayer Create(ITweetMedia inMedia)
        {
            if (inMedia == null)
                return null;

            switch (inMedia.MediaType) {
                case TweetMediaType.Image:
                    return new TweetImageMediaPlayer(inMedia as ITweetImageMedia);
                default:
                    return null;
            }
        }

        public TweetMediaPlayer(ITweetMedia inMedia)
        {
            Media = inMedia;
            return;
        }

        public virtual void DisplayTo(Control inDisplay)
        {
            return;
        }

        public virtual void UnDisplay(Control inDisplay)
        {
            return;
        }

        public virtual void Paint(Control inDisplay, Graphics inTarget)
        {
            return;
        }

        public ITweetMedia Media
        { get; private set; } = null;

        class TweetImageMediaPlayer : TweetMediaPlayer
        {
            public TweetImageMediaPlayer(ITweetImageMedia inImageMedia)
                : base(inImageMedia)
            {
                if (Media != null)
                    View.Image = Media.Image;
                return;
            }

            public override void DisplayTo(Control inDisplay)
            {
                base.DisplayTo(inDisplay);

                //View.Parent = inDisplay;
                //View.Dock = DockStyle.Fill;
                return;
            }

            public override void UnDisplay(Control inDisplay)
            {
                base.UnDisplay(inDisplay);

                //View.Parent = null;
                return;
            }

            public override void Paint(Control inDisplay, Graphics inTarget)
            {
                base.Paint(inDisplay, inTarget);

                if (Media.Image != null) {
                    CtrlImageView.ImagePaintOption options = new CtrlImageView.ImagePaintOption();
                    options.BackColor = inDisplay.BackColor;
                    CtrlImageView.PaintTo(inDisplay, inTarget, Media.Image, options);
                }
                return;
            }

            public new ITweetImageMedia Media
            { get { return base.Media as ITweetImageMedia; } }

            private CtrlImageView View
            { get; } = new CtrlImageView();
        }
    }
}
