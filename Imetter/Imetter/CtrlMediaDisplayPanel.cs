using System.Windows.Forms;

namespace Imetter
{
    public partial class CtrlMediaDisplayPanel : UserControl
    {
        public CtrlMediaDisplayPanel()
        {
            InitializeComponent();
        }

        public ITweetMedia Media
        { 
            get { return m_Media; }
            set {
                if (m_Media == value)
                    return;

                if (MediaPlayer != null)
                    MediaPlayer.UnDisplay(this);

                m_Media = value;
                MediaPlayer = TweetMediaPlayer.Create(Media);

                if (MediaPlayer != null)
                    MediaPlayer.DisplayTo(this);
                return;
            }
        }

        private ITweetMedia m_Media = null;
        private TweetMediaPlayer MediaPlayer
        { get; set; } = null;
    }
}
