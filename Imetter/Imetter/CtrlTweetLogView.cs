using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            CtrlTweetView1.Status = TweetLog[--LogIndex];
            return;
        }
        
        public void MoveNext()
        {
            if (!CanMoveNext)
                return;

            CtrlTweetView1.Status = TweetLog[++LogIndex];
            return;
        }

        public void Remove()
        {

        }

        public bool CanMovePrevious
        { get { return (TweetLog != null) && (LogIndex > 0); } }

        public bool CanMoveNext
        { get { return (TweetLog != null) && (LogIndex < (TweetLog.Count - 1)); } }

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

        public IList<Status> TweetLog
        { 
            get { return m_TweetLog; }
            set {
                m_TweetLog = value;
                LogIndex = (TweetLog == null) ? -1 : 0;
            }
        }
        public int LogIndex
        { get; private set; } = -1;

        private IList<Status> m_TweetLog = null;
    }
}
