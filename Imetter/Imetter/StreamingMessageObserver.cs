using System;
using CoreTweet;
using CoreTweet.Streaming;

namespace Imetter
{
    class StreamingMessageObserver : IObserver<StreamingMessage>
    {
        public delegate void ReceiveErrorEvent(Exception inException);
        public delegate void ReceiveStatusEvent(Status inStatus);

        public void OnCompleted()
        {
            return;
        }

        public void OnError(Exception inError)
        {
            OnReceiveError?.Invoke(inError);
            return;
        }

        public void OnNext(StreamingMessage inMessage)
        {
            if (inMessage is StatusMessage) {
                Status status = (inMessage as StatusMessage).Status;

                OnReceiveStatus?.Invoke(status);
            }
            return;
        }

        public event ReceiveErrorEvent OnReceiveError;
        public event ReceiveStatusEvent OnReceiveStatus;
    }
}
