using System;
using CoreTweet;

namespace Imetter
{
    class FilterStreamingMessageObserver
    {
        public delegate void ReceiveStatusEvent(Status inStatus);

        public FilterStreamingMessageObserver(Tokens inTokens, string inKeyword)
        {
            Tokens = inTokens;
            Keyword = inKeyword;
            return;
        }

        public void Start()
        {
            InternalObserver = new StreamingMessageObserver();
            InternalObserver.OnReceiveError += InternalObserver_OnReceiveError;
            InternalObserver.OnReceiveStatus += InternalObserver_OnReceiveStatus;

            Tokens.Streaming.FilterAsObservable(track: Keyword).Subscribe(InternalObserver);
            return;
        }

        private void InternalObserver_OnReceiveError(Exception inException)
        {
            // restart
            Start();
            return;
        }

        private void InternalObserver_OnReceiveStatus(Status inStatus)
        {
            OnReceiveStatus?.Invoke(inStatus);
            return;
        }

        public event ReceiveStatusEvent OnReceiveStatus;

        public Tokens Tokens
        { get; private set; } = null;
        public string Keyword
        { get; private set; } = null;
        private StreamingMessageObserver InternalObserver
        { get; set; } = null;
    }
}
