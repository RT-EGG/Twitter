using CoreTweet;
using System;
using System.Net;
using System.Windows.Forms;

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
                        m_Session = OAuth.Authorize(m_ApplicationKeys.ConsumerKey, m_ApplicationKeys.ConsumerSecret);

                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                } while (m_Session == null);

                m_ApplicationKeys.ExportToFile("autapp");

            } else {
                m_Session = OAuth.Authorize(m_ApplicationKeys.ConsumerKey, m_ApplicationKeys.ConsumerSecret);
            }

            return true;
        }

        private bool AuthorizeUser()
        {
            m_AccessKeys = AuthorizeKeys.LoadFromFile<AuthorizeKeys.AccessKeys>("autacc");
            if (m_AccessKeys == null) {
                m_AccessKeys = new AuthorizeKeys.AccessKeys();
                FormUserPincodeQuery input = new FormUserPincodeQuery(m_Session);

                do {
                    if (input.ShowDialog() != DialogResult.OK)
                        return false;

                    try {
                        m_Tokens = OAuth.GetTokens(m_Session, input.Pincode);
                        m_AccessKeys.AccessToken = m_Tokens.AccessToken;
                        m_AccessKeys.AccessSecret = m_Tokens.AccessTokenSecret;

                    } catch (Exception e) {
                        Console.Write(e.Message);
                    }

                } while (m_Tokens == null);

                m_AccessKeys.ExportToFile("autacc");

            } else {
                m_Tokens = Tokens.Create(m_ApplicationKeys.ConsumerKey,
                                         m_ApplicationKeys.ConsumerSecret,
                                         m_AccessKeys.AccessToken,
                                         m_AccessKeys.AccessSecret);

                m_Session.RequestToken = m_AccessKeys.AccessToken;
                m_Session.RequestTokenSecret = m_AccessKeys.AccessSecret;

                try {
                    m_User = m_Tokens.Account.VerifyCredentials();

                    // if target user is locked account, can't be polled by filter stream.
                    bool targetIsLockedAccount = false;
                    if (!targetIsLockedAccount) {
                        FilterStreamMonitor monitor = new FilterStreamMonitor(m_Tokens, new string[] { TargetUserID });
                        m_TweetMonitor = monitor;
                    } else {
                        TimelineStreamMonitor monitor = new TimelineStreamMonitor(m_Tokens, TargetUserID);
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
                if (inStatus.Text == "てす") {
                    m_Tokens.Statuses.Update(new { status = "びゃー" });
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

                var limits = m_Tokens.Application.RateLimitStatus()["statuses"];
                TextRateLimits.AppendText($"-----{ "status" }-----{ Environment.NewLine }");
                foreach (var limit in limits) {
                    TextRateLimits.AppendText($"-{ limit.Key }:{ limit.Value.Remaining }, { limit.Value.Limit }{ Environment.NewLine }");
                }

                limits = m_Tokens.Application.RateLimitStatus()["application"];
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

        private OAuth.OAuthSession m_Session = null;
        private Tokens m_Tokens = null;
        private UserResponse m_User = null;

        private long? m_LastID = null;
        private int m_RateLimitRequestSpan = 0;

        private AuthorizeKeys.ApplicationKeys m_ApplicationKeys = null;
        private AuthorizeKeys.AccessKeys m_AccessKeys = null;

        private TweetMonitor m_TweetMonitor = null;
    }
}
