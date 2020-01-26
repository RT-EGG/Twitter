using System;
using System.Collections.Generic;
using CoreTweet;
using CoreTweet.Streaming;

namespace AutoReplier
{
    class FilterStreamMonitor : TweetMonitor
    {
        public FilterStreamMonitor(Tokens inTokens, IEnumerable<string> inTargeNames)
            : base(inTokens, inTargeNames)
        {
            var users = Tokens.Users.Lookup(inTargeNames);
            foreach (var user in users) {
                m_TargetUsers.Add(user);
            }
            return;
        }

        public override void StartMonitoring()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string ids = "";
            foreach (var user in m_TargetUsers) {
                ids += $"{ user.Id },";
            }
            ids = ids.Substring(0, ids.Length - 1);
            parameters.Add("follow", ids);
            parameters.Add("replies", "all");

            TweetObserver observer = new TweetObserver();
            observer.OnReceiveError += Observer_OnReceiveError;
            observer.OnReceiveMessage += Observer_OnReceiveMessage;
            Tokens.Streaming.FilterAsObservable(parameters).Subscribe(observer);
            return;
        }

        private void Observer_OnReceiveError(Exception inError)
        {
            CallOnReceiveError(inError);
            StartMonitoring();
            return;
        }

        private void Observer_OnReceiveMessage(Status inStatus)
        {
            CallOnReceiveStatus(inStatus);
            return;
        }

        private List<User> m_TargetUsers = new List<User>();

        delegate void TweetObserverReceiveErrorEvent(Exception inError);
        delegate void TweetObserverReceiveMessageEvent(Status inStatus);
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

            public event TweetObserverReceiveErrorEvent OnReceiveError;
            public event TweetObserverReceiveMessageEvent OnReceiveMessage;
        }
    }
}
