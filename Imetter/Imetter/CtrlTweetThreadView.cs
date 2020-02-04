using System.Collections.Generic;
using CoreTweet;

namespace Imetter
{
    public partial class CtrlTweetThreadView : CtrlTweetLogView
    {
        public CtrlTweetThreadView(Tokens inTokens, string inKeyword)
        {
            InitializeComponent();

            Tokens = inTokens;

            base.TweetLog = new List<Status>();
            SearchResult search = Tokens.Search.Tweets(count: 100, q: inKeyword, include_entities: true);
            foreach (var status in search) {
                TweetLog.Add(status);
            }

            MessageObserver = new FilterStreamingMessageObserver(inTokens, inKeyword);
            MessageObserver.OnReceiveStatus += MessageObserver_OnReceiveStatus;

            LogIndex = 0;
            Invalidate();
            return;
        }

        private void MessageObserver_OnReceiveStatus(Status inStatus)
        {
            if (inStatus.ExtendedEntities.Media.Length == 0)
                return;

            TweetLog.Add(inStatus);
            return;
        }

        public Tokens Tokens
        { get; private set; } = null;
        private FilterStreamingMessageObserver MessageObserver
        { get; set; } = null;
    }
}
