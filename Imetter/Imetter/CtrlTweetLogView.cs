using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CoreTweet;

namespace Imetter
{
    public partial class CtrlTweetLogView : UserControl
    {
        public CtrlTweetLogView()
        {
            InitializeComponent();
        }

        public void MovePrevious()
        {
            if (!CanMovePrevious)
                return;

            LogIndex += 1;
            return;
        }
        
        public void MoveNext()
        {
            if (!CanMoveNext)
                return;

            LogIndex -= 1;
            return;
        }

        public bool CanMovePrevious
        { get { return (TweetLog != null) && (LogIndex < (TweetLog.Count - 1)); } }

        public bool CanMoveNext
        { get { return (TweetLog != null) && (LogIndex > 0); } }

        private void TimerPanelAnimation_Tick(object sender, EventArgs e)
        {
            if (true) {
                TimerPanelAnimation.Enabled = false;
            }
            return;
        }

        private void ButtonMovePrevious_Click(object sender, EventArgs e)
        {
            MovePrevious();
            return;
        }

        private void ButtonMoveNext_Click(object sender, EventArgs e)
        {
            MoveNext();
            return;
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);

            Action UpdateUI = () => {
                ButtonMovePrevious.Enabled = CanMovePrevious;
                ButtonMoveNext.Enabled = CanMoveNext;
                LabelLogIndex.Text = (TweetLog == null) ? "N/A" : $"{ TweetLog.Count - LogIndex } / { TweetLog.Count }";
            };

            if (InvokeRequired) {
                Invoke((MethodInvoker)delegate () { UpdateUI(); });
            } else {
                UpdateUI();
            }
            return;
        }

        public IList<Status> TweetLog
        { 
            get { return m_TweetLog; }
            set {
                m_TweetLog = value;
                LogIndex = (TweetLog == null) ? -1 : 0;
                Invalidate();
                return;
            }
        }

        public int LogIndex
        { 
            get { return m_LogIndex; }
            set {
                if ((value < 0) || (TweetLog == null) || (TweetLog.Count == 0)) {
                    m_LogIndex = -1;
                } else {
                    m_LogIndex = Math.Max(0, Math.Min(TweetLog.Count - 1, value));
                }

                CtrlTweetView1.Status = (m_LogIndex == -1) ? null : TweetLog[m_LogIndex];
                Invalidate();
                return;
            }
        }

        private IList<Status> m_TweetLog = null;
        private int m_LogIndex = -1;
    }
}
