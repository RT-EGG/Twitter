using CoreTweet;
using CoreTweet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoReplier
{
    class TimelineStreamMonitor : TweetMonitor
    {
        public TimelineStreamMonitor(Tokens inTokens, string inTargetUserName)
            : base(inTokens,  new string[] { inTargetUserName })
        {
            m_UpdateTimer.Enabled = false;
            m_RequestRestartTimer.Enabled = false;
            m_RequestRestartTimer.Interval = 60 * 1000;

            m_UpdateTimer.Tick += UpdateTimer_Tick;
            m_RequestRestartTimer.Tick += RequestRestartTimer_Tick;

            return;
        }

        public override void StartMonitoring()
        {
            if (TargetUserNames.Count() < 1)
                return;

            m_UpdateTimer.Enabled = true;
            return;
        }

        public int UpdateInterval
        {
            get { return m_UpdateTimer.Interval; }
            set { m_UpdateTimer.Interval = value; }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            try {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("cuont", 50);
                if (m_LastID != null)
                    parameters.Add("since_id", m_LastID.Value);
                // supports only one account because of API limitation.
                parameters.Add("screen_name", TargetUserNames.First());

                ListedResponse<Status> timeline = Tokens.Statuses.UserTimeline(parameters);

                foreach (var status in timeline.Reverse()) {
                    CallOnReceiveStatus(status);
                }

                if (timeline.Count > 0) {
                    m_LastID = timeline.First().Id;
                }

            } catch (Exception exception) {
                m_UpdateTimer.Enabled = false;
                m_RequestRestartTimer.Enabled = true;
                CallOnReceiveError(exception);
            }
            return;
        }

        private void RequestRestartTimer_Tick(object sender, EventArgs e)
        {
            m_RequestRestartTimer.Enabled = false;
            m_UpdateTimer.Enabled = true;
            return;
        }

        private Timer m_UpdateTimer = new Timer();
        private Timer m_RequestRestartTimer = new Timer();
        private long? m_LastID = null;
    }
}
