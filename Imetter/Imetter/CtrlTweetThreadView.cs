using System.Collections.Generic;
using System.IO;
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
            Keyword = inKeyword;

            LogIndex = 0;
            Invalidate();
            return;
        }

        private void MessageObserver_OnReceiveStatus(Status inStatus)
        {
            AddStatus(inStatus);
            return;
        }

        public Tokens Tokens
        { get; private set; } = null;
        public string Keyword
        {
            get { return m_Keyword; }
            set {
                if (m_Keyword == value)
                    return;
                if (MessageObserver != null) {
                    MessageObserver.OnReceiveStatus -= MessageObserver_OnReceiveStatus;
                }

                LogIndex = -1;
                m_Keyword = value;

                TweetLog.Clear();
                SearchResult search = Tokens.Search.Tweets(count: 100, q: Keyword, include_entities: true);
                foreach (var status in search) {
                    AddStatus(status);
                }

                MessageObserver = new FilterStreamingMessageObserver(Tokens, Keyword);
                MessageObserver.OnReceiveStatus += MessageObserver_OnReceiveStatus;
                MessageObserver.Start();

                return;
            }
        }

        private void AddStatus(Status inStatus)
        {
            if (inStatus.Text.StartsWith("RT @"))
                return;
            if (!HasImageEntity(inStatus))
                return;

            TweetLog.Add(inStatus);
            Invalidate();
            return;
        }

        private bool HasImageEntity(Status inStatus)
        {
            if ((inStatus.ExtendedEntities == null) || (inStatus.ExtendedEntities.Media.Length == 0))
                return false;

            foreach (var entity in inStatus.ExtendedEntities.Media) {
                string ext = Path.GetExtension(entity.MediaUrlHttps);
                switch (ext.ToLower()) {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                        return true;
                }
            }

            return false;
        }

        private FilterStreamingMessageObserver MessageObserver
        { get; set; } = null;

        private string m_Keyword = "";
    }
}
