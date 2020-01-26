using System;
using System.Net;
using System.Windows.Forms;
using CoreTweet;

namespace AutoReplier
{
    public partial class FormMain : Form
    {
        private const string TargetUserID = "";

        public FormMain()
        {
            InitializeComponent();
            return;
        }

        private bool AuthorizeApplication()
        {
            m_ApplicationKeys = AuthorizeKeys.LoadFromFile<AuthorizeKeys.ApplicationKeys>("autapp");
            if (m_ApplicationKeys == null) {
                m_ApplicationKeys = new AuthorizeKeys.ApplicationKeys();
                FormApplicaionKeysQuery input = new FormApplicaionKeysQuery();

                do {
                    if (input.ShowDialog() != DialogResult.OK)
                        return false;

                    m_ApplicationKeys.ConsumerKey = input.APIKey;
                    m_ApplicationKeys.ConsumerSecret = input.SecretKey;

                    try {
                        Session = OAuth.Authorize(m_ApplicationKeys.ConsumerKey, m_ApplicationKeys.ConsumerSecret);

                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                } while (Session == null);

                m_ApplicationKeys.ExportToFile("autapp");

            } else {
                Session = OAuth.Authorize(m_ApplicationKeys.ConsumerKey, m_ApplicationKeys.ConsumerSecret);
            }

            return true;
        }

        private bool AuthorizeUser()
        {
            m_AccessKeys = AuthorizeKeys.LoadFromFile<AuthorizeKeys.AccessKeys>("autacc");
            if (m_AccessKeys == null) {
                m_AccessKeys = new AuthorizeKeys.AccessKeys();
                FormUserPincodeQuery input = new FormUserPincodeQuery(Session);

                do {
                    if (input.ShowDialog() != DialogResult.OK)
                        return false;

                    try {
                        Tokens = OAuth.GetTokens(Session, input.Pincode);
                        m_AccessKeys.AccessToken = Tokens.AccessToken;
                        m_AccessKeys.AccessSecret = Tokens.AccessTokenSecret;

                    } catch (Exception e) {
                        Console.Write(e.Message);
                    }

                } while (Tokens == null);

                m_AccessKeys.ExportToFile("autacc");

            } else {
                Tokens = Tokens.Create(m_ApplicationKeys.ConsumerKey,
                                         m_ApplicationKeys.ConsumerSecret,
                                         m_AccessKeys.AccessToken,
                                         m_AccessKeys.AccessSecret);

                Session.RequestToken = m_AccessKeys.AccessToken;
                Session.RequestTokenSecret = m_AccessKeys.AccessSecret;

                try {
                    User = Tokens.Account.VerifyCredentials();

                    // if target user is locked account, can't be polled by filter stream.
                    bool targetIsLockedAccount = false;
                    if (!targetIsLockedAccount) {
                        FilterStreamMonitor monitor = new FilterStreamMonitor(Tokens, new string[] { TargetUserID });
                        m_TweetMonitor = monitor;
                    } else {
                        TimelineStreamMonitor monitor = new TimelineStreamMonitor(Tokens, TargetUserID);
                        monitor.UpdateInterval = 2;
                        m_TweetMonitor = monitor;
                    }

                    if (m_TweetMonitor != null) {
                        m_TweetMonitor.OnReceiveError += Monitor_OnReceiveError;
                        m_TweetMonitor.OnReceiveStatus += Monitor_OnReceiveStatus;
                        m_TweetMonitor.StartMonitoring();
                    }

                } catch (WebException exception) {
                    // can not authorize user by saved access tokens.
                }
            }

            return true;
        }

        private void Monitor_OnReceiveStatus(Status inStatus)
        {
            if (InvokeRequired) {
                Invoke(new SafeCallDoReceiveStatus(DoReceiveStatus), inStatus);
            } else {
                DoReceiveStatus(inStatus);
            }
            return;
        }

        private void Monitor_OnReceiveError(Exception inError)
        {
            if (InvokeRequired) {
                Invoke(new SafeCallDoReceiveError(DoReceiveError), inError);
            } else {
                DoReceiveError(inError);
            }
            
            return;
        }

        private void CheckTweetForReaction(Status inStatus)
        {
            TimeSpan offset = DateTimeOffset.Now.Subtract(inStatus.CreatedAt);
            if (offset.TotalMinutes < 1) {
                if (inStatus.Text == "おっ") {
                    Tokens.Statuses.Update(new { status = "ぱい" });
                }
            }
            
            return;
        }

        private void DoReceiveError(Exception inError)
        {
            TextTimeLine.Clear();
            TextTimeLine.Text = $"Exception: { inError.GetType().ToString() }{ Environment.NewLine }" +
                                $"{ inError.Message }{ Environment.NewLine }" +
                                $"{ inError.StackTrace }";
            return;
        }

        private void DoReceiveStatus(Status inStatus)
        {
            if (++m_RateLimitRequestSpan > 50) {
                TextRateLimits.Clear();

                var limits = Tokens.Application.RateLimitStatus()["statuses"];
                TextRateLimits.AppendText($"-----{ "status" }-----{ Environment.NewLine }");
                foreach (var limit in limits) {
                    TextRateLimits.AppendText($"-{ limit.Key }:{ limit.Value.Remaining }, { limit.Value.Limit }{ Environment.NewLine }");
                }

                limits = Tokens.Application.RateLimitStatus()["application"];
                TextRateLimits.AppendText($"-----{ "application" }-----{ Environment.NewLine }");
                foreach (var limit in limits) {
                    TextRateLimits.AppendText($"-{ limit.Key }:{ limit.Value.Remaining }, { limit.Value.Limit }{ Environment.NewLine }");
                }
                m_RateLimitRequestSpan = 0;
            }

            string tweet = "//--------------------" + Environment.NewLine +
                                   $"@{ inStatus.User.ScreenName } ({ inStatus.User.Name }){ Environment.NewLine }" +
                                   $"{ inStatus.Text }{ Environment.NewLine }";
            TextTimeLine.Text = tweet + TextTimeLine.Text;

            while (TextTimeLine.Text.Length > 30000) {
                string text = TextTimeLine.Text;

                int index = text.Length;
                for (int i = 0; i < 3; ++i) {
                    int tmpIndex = text.LastIndexOf(Environment.NewLine, index);
                    if (tmpIndex != -1) {
                        index = tmpIndex;
                    } else {
                        break;
                    }
                }
                TextTimeLine.Text = text.Substring(index + Environment.NewLine.Length);
            }

            CheckTweetForReaction(inStatus);
            return;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if ((!AuthorizeApplication()) || (!AuthorizeUser())) {
                Close();
                return;
            }

            return;
        }

        delegate void SafeCallDoReceiveError(Exception inException);
        delegate void SafeCallDoReceiveStatus(Status inStatus);

        private OAuth.OAuthSession Session
        { get; set; } = null;
        private Tokens Tokens
        { get; set; } = null;
        private UserResponse User
        { get; set; } = null;

        private int m_RateLimitRequestSpan = 0;

        private AuthorizeKeys.ApplicationKeys m_ApplicationKeys = null;
        private AuthorizeKeys.AccessKeys m_AccessKeys = null;

        private TweetMonitor m_TweetMonitor = null;
    }
}
