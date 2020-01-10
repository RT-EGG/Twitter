using System.Windows.Forms;

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

        }

        public virtual void UnDisplay(Control inDisplay)
        {

        }

        public ITweetMedia Media
        { get; private set; } = null;

        class TweetImageMediaPlayer : TweetMediaPlayer
        {
            public TweetImageMediaPlayer(ITweetImageMedia inImageMedia)
                : base(inImageMedia)
            {
                return;
            }

            public override void DisplayTo(Control inDisplay)
            {
                base.DisplayTo(inDisplay);

                inDisplay.BackgroundImageLayout = ImageLayout.Zoom;
                inDisplay.BackgroundImage = Media.Image;
                return;
            }

            public override void UnDisplay(Control inDisplay)
            {
                base.UnDisplay(inDisplay);

                inDisplay.BackgroundImage = null;
                return;
            }

            public new ITweetImageMedia Media
            { get { return base.Media as ITweetImageMedia; } }
        }
    }
}
