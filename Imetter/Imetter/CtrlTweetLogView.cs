using CoreTweet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            ButtonMovePrevious.Enabled = CanMovePrevious;
            ButtonMoveNext.Enabled = CanMoveNext;
            return;
        }

        public IList<Status> TweetLog
        { 
            get { return m_TweetLog; }
            set {
                m_TweetLog = value;
                LogIndex = (TweetLog == null) ? -1 : 0;
            }
        }
        public int LogIndex
        { 
            get { return m_LogIndex; }
            set {
                if (value < 0) {
                    value = -1;
                } else {

                }

                CtrlTweetView1.Status = (LogIndex == -1) ? null : TweetLog[LogIndex];
            }
        }

        private IList<Status> m_TweetLog = null;
        private int m_LogIndex = -1;
    }
}
