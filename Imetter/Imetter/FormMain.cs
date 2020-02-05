using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CoreTweet;

namespace Imetter
{
    public partial class FormMain : Form
    {
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
                try {
                    UserResponse user = m_Tokens.Account.VerifyCredentials();
                    
                    CreateNewFilterStream("Keyword");

                } catch (Exception e) /*(WebException e)*/ {
                    // can not authorize user by saved access tokens.
                    Console.WriteLine(e.GetType().FullName);
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }

                
                m_Session.RequestToken = m_AccessKeys.AccessToken;
                m_Session.RequestTokenSecret = m_AccessKeys.AccessSecret;
            }

            return true;
        }

        private void CreateNewFilterStream(string inKeyword)
        {
            if (m_TweetThreadView == null) {
                m_TweetThreadView = new CtrlTweetThreadView(m_Tokens, inKeyword);
                m_TweetThreadView.Parent = PanelThreadView; 
                m_TweetThreadView.Dock = DockStyle.Fill;

            } else {
                m_TweetThreadView.Keyword = inKeyword;
            }
            
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

        private void ButtonUpdateTimeline_Click(object sender, EventArgs e)
        {
            UpdateTimeline();
            return;
        }

        private void UpdateTimeline()
        {
            //var responses = m_Tokens.Statuses.UserTimeline(since_id: m_LastResponseID, count: 100, include_rts: false, exclude_replies: true);
            //foreach (var response in responses) {
            //    if ((response.ExtendedEntities?.Media　!= null) && (response.ExtendedEntities?.Media.Count() > 0)) {
            //        TweetView.Status = response;
            //        break;
            //    }
            //}

            //if (responses.Count > 0)
            //    m_LastResponseID = responses.First().Id;

            return;
        }

        private void TweetView_OnMouseClickTweetMedia(object inSender, IMediaMouseClickEventArgs inMedia)
        {
            PanelMediaDisplay.Media = inMedia.Media;
            PanelMediaDisplay.Visible = PanelMediaDisplay.Media != null;
            //TweetView.Visible = !PanelMediaDisplay.Visible;
            return;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (PanelMediaDisplay.Visible) {
                PanelMediaDisplay.Media = null;
                PanelMediaDisplay.Visible = false;
            }
            //TweetView.Visible = !PanelMediaDisplay.Visible;
            return;
        }

        private OAuth.OAuthSession m_Session = null;
        private Tokens m_Tokens = null;
        private long? m_LastResponseID = null;
        private Queue<Status> m_TweetLog = new Queue<Status>();

        private AuthorizeKeys.ApplicationKeys m_ApplicationKeys = null;
        private AuthorizeKeys.AccessKeys m_AccessKeys = null;

        private List<CtrlTweetView> m_TweetViewList = new List<CtrlTweetView>();
        private CtrlTweetThreadView m_TweetThreadView = null;
    }
}
