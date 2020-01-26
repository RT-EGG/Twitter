using System;
using CoreTweet;
using CoreTweet.Streaming;

namespace AutoReplier
{
    delegate void OnTweetObserverError(Exception inError);
    delegate void OnTweetObserverReceiveMessage(Status inStatus);

    class TweetObserver : IObserver<StreamingMessage>
    {
        public void OnCompleted()
        {
            return;
        }

        public void OnError(Exception error)
        {
            OnReceiveError?.Invoke(error);
            return;
        }

        public void OnNext(StreamingMessage value)
        {
            if (value is StatusMessage) {
                OnReceiveMessage?.Invoke((value as StatusMessage).Status);
            }
            return;
        }

        public event OnTweetObserverError OnReceiveError;
        public event OnTweetObserverReceiveMessage OnReceiveMessage;
    }
}
