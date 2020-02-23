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

                Action<Status> SetToUI = (Status inStatus) => {
                    UserInfo.User = inStatus?.User;
                    ContentsView.Medias = inStatus?.ExtendedEntities?.Media;
                    ContentsView.Visible = (inStatus?.ExtendedEntities?.Media != null) && (inStatus?.ExtendedEntities?.Media.Length != 0);
                    if (!ContentsView.Visible)
                        Height = LabelTweetText.Bottom;

                    if (inStatus != null)
                        LabelTimeStamp.Text = ToTimeStampText(inStatus.CreatedAt.DateTime);

                    string text = "";
                    if (inStatus != null) {
                        text = inStatus.Text;
                        if (Status.ExtendedEntities?.Media?.Length > 0) {
                            var media = Status.ExtendedEntities.Media[0];
                            text = text.Remove(media.Indices[0], media.Indices[1] - media.Indices[0]);
                        }
                    }
                    
                    LabelTweetText.Text = text;
                };

                if (InvokeRequired) {
                    Invoke((MethodInvoker)delegate () { SetToUI(m_Status); });
                } else {
                    SetToUI(m_Status);
                }
                return;
            }
        }

        public MediaEntity CurrentMedia
        { get { return ContentsView.Medias?[ContentsView.MediaIndex]; } }
        public int CurrentMediaIndex
        { get { return ContentsView.MediaIndex; } }

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
