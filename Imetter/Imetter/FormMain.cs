using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using CoreTweet;
using System.Net;
using System.IO;

namespace TwitterTimeLine
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
                    UserInfoView.User = user;

                    //WebClient client = new WebClient();
                    //MemoryStream stream = new MemoryStream(client.DownloadData(user.ProfileImageUrlHttps));
                    //Bitmap icon = new Bitmap(stream);
                    //this.BackgroundImage = icon;

                } catch (WebException e) {
                    // can not authorize user by saved access tokens.
                }

                
                m_Session.RequestToken = m_AccessKeys.AccessToken;
                m_Session.RequestTokenSecret = m_AccessKeys.AccessSecret;
            }

            return true;
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

        private void RequestTimer_Tick(object sender, EventArgs e)
        {

        }

        private void UpdateTimeline()
        {
            //var responses = m_Tokens.Search.Tweets("", since_id: m_LastResponseID, include_entities: true);
            //foreach (var response in responses.Reverse()) {
            //    if ((response.Entities.Media == null) || (response.Entities.Media.Length == 0))
            //        continue;

            //    m_TweetLog.Enqueue(response);
            //}

            var responses = m_Tokens.Statuses.UserTimeline(since_id: m_LastResponseID);

            TextTimeline.Clear();
            foreach (var response in responses) {
                if (response.User != null) {
                }

                //if ((response.Entities.Media != null) && (response.Entities.Media.Length > 0)) {
                //    MediaEntity media = response.Entities.Media[0];
                //    TextTimeline.AppendText($"DisplayURL: { media.DisplayUrl }{ Environment.NewLine }");
                //    TextTimeline.AppendText($"ExpandedURL: { media.ExpandedUrl }{ Environment.NewLine }");
                //    TextTimeline.AppendText($"MediaURL: { media.MediaUrl }{ Environment.NewLine }");
                //    TextTimeline.AppendText($"MediaURLHttps: { media.MediaUrlHttps }{ Environment.NewLine }");
                //    TextTimeline.AppendText($"URL: { media.Url }{ Environment.NewLine }");
                //    break;
                //}

                //TextTimeline.AppendText($"----------{ Environment.NewLine }");
                //TextTimeline.AppendText($"{ response.User.ScreenName }{ Environment.NewLine }");
                //TextTimeline.AppendText($"{ response.Text }{ Environment.NewLine }");
                //TextTimeline.AppendText($"{ Environment.NewLine }");
            }

            if (responses.Count > 0)
                m_LastResponseID = responses.First().Id;

            return;
        }

        private OAuth.OAuthSession m_Session = null;
        private Tokens m_Tokens = null;
        private long? m_LastResponseID = null;
        private Queue<Status> m_TweetLog = new Queue<Status>();

        private AuthorizeKeys.ApplicationKeys m_ApplicationKeys = null;
        private AuthorizeKeys.AccessKeys m_AccessKeys = null;
    }
}
