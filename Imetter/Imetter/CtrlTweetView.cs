using System;
using CoreTweet;
using System.Windows.Forms;

namespace Imetter
{
    public partial class CtrlTweetView : UserControl
    {
        public event MediaMouseClickEvent OnMouseClickTweetMedia;

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
                    ContentsView.Medias = Status.ExtendedEntities.Media;
                    ContentsView.Visible = (Status.ExtendedEntities.Media != null) && (Status.ExtendedEntities.Media.Length != 0);
                    if (!ContentsView.Visible)
                        Height = LabelTweetText.Bottom + PanelAction.Height;

                    LabelTimeStamp.Text = ToTimeStampText(Status.CreatedAt.DateTime);

                    string text = Status.Text;
                    if (Status.ExtendedEntities?.Media?.Length > 0) {
                        var media = Status.ExtendedEntities.Media[0];
                        text = text.Remove(media.Indices[0], media.Indices[1] - media.Indices[0]);
                    }
                    LabelTweetText.Text = text;
                }
                return;
            }
        }

        private void ContentsView_OnMouseClickMedia(object inSender, IMediaMouseClickEventArgs inMedia)
        {
            OnMouseClickTweetMedia?.Invoke(inSender, inMedia);
            return;
        }

        private static string ToTimeStampText(DateTime inTime)
        {
            return $"{ inTime.Month }M/{ inTime.Day }D - {inTime.Hour:D2}:{inTime.Minute:D2}:{inTime.Second:D2}";
        }

        private Status m_Status = null;
    }
}
