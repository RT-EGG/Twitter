using System;
using System.Collections.Generic;
using CoreTweet;

namespace AutoReplier
{
    delegate void TweetMonitorReceiveErrorEvent(Exception inError);
    delegate void TweetMonitorReceiveStatusEvent(Status inStatus);

    abstract class TweetMonitor
    {
        public TweetMonitor(Tokens inTokens, IEnumerable<string> inTargetUserID)
        {
            Tokens = inTokens;
            TargetUserNames = inTargetUserID;
            return;
        }

        public abstract void StartMonitoring();

        public Tokens Tokens
        { get; private set; } = null;
        public IEnumerable<string> TargetUserNames
        { get; private set; } = new List<string>();

        protected void CallOnReceiveError(Exception inError)
        {
            OnReceiveError?.Invoke(inError);
            return;
        }

        protected void CallOnReceiveStatus(Status inStatus)
        {
            OnReceiveStatus?.Invoke(inStatus);
            return;
        }

        public event TweetMonitorReceiveErrorEvent OnReceiveError;
        public event TweetMonitorReceiveStatusEvent OnReceiveStatus;
    }
}
