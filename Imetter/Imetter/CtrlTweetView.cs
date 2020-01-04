using System;
using CoreTweet;
using System.Windows.Forms;

namespace Imetter
{
    public partial class CtrlTweetView : UserControl
    {
        public CtrlTweetView()
        {
            InitializeComponent();
        }

        public Status Status
        {
            get { return m_Status; }
            set {
                m_Status = value;
                if (m_Status != null) {
                    UserInfo.User = Status.User;
                    LabelTweetText.Text = Status.Text;
                    ContentsView.Medias = Status.ExtendedEntities.Media;
                    ContentsView.Visible = (Status.ExtendedEntities.Media != null) && (Status.ExtendedEntities.Media.Length != 0);
                    if (!ContentsView.Visible)
                        Height = LabelTweetText.Bottom + PanelAction.Height;
                }
                return;
            }
        }

        private Status m_Status = null;

        private void ContentsView_MouseClick(object sender, MouseEventArgs e)
        {
            Control clicked = ContentsView.GetChildAtPoint(e.Location);
        }

        private void ContentsView_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}
