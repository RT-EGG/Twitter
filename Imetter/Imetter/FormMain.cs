using System;
using System.Drawing;
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
                m_TweetThreadView.StatusChanged += M_TweetThreadView_StatusChanged;

            } else {
                if (m_TweetThreadView.Keyword == inKeyword)
                    return;

                m_TweetThreadView.Keyword = inKeyword;
            }

            if (TextBoxKeyword.Text != inKeyword) {
                TextBoxKeyword.Text = inKeyword;
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

        private void ButtonChangeKeyword_Click(object sender, EventArgs e)
        {
            CreateNewFilterStream(TextBoxKeyword.Text);
            return;
        }

        private void ButtonRT_Click(object sender, EventArgs e)
        {
            Status status = m_TweetThreadView?.Status;
            if (status == null)
                return;
            
            if (IsRetweeted(status)) {
                m_Tokens.Statuses.Unretweet(status.Id);
                status.IsRetweeted = false;
            } else {
                StatusResponse response = m_Tokens.Statuses.Retweet(status.Id);
                status.IsRetweeted = true;
            }
            
            UpdateActionButtonAppearance();
            return;
        }

        private void ButtonFav_Click(object sender, EventArgs e)
        {
            Status status = m_TweetThreadView?.Status;
            if (status == null)
                return;

            if (m_Tokens.Statuses.Show(id: status.Id).IsFavorited.Value) {
                m_Tokens.Favorites.Destroy(status.Id);
                status.IsFavorited = false;
            } else {
                m_Tokens.Favorites.Create(status.Id);
                status.IsFavorited = true;
            }
            UpdateActionButtonAppearance();
            return;
        }

        private void M_TweetThreadView_StatusChanged(object inSender, Status inStatus)
        {
            UpdateActionButtonAppearance();
            return;
        }

        private void UpdateActionButtonAppearance()
        {
            ButtonRT.Text = $"RT";
            ButtonFav.Text = $"Fav";

            Status status = m_TweetThreadView?.Status;
            if (status == null)
                return;

            int rtCount  = status.RetweetCount.GetValueOrDefault(0);
            int favCount = status.FavoriteCount.GetValueOrDefault(0);

            if (rtCount > 0)
                ButtonRT.Text += $" ({rtCount})";
            ButtonRT.ForeColor = IsRetweeted(status) ? Color.LimeGreen : Color.Black;

            if (favCount > 0)
                ButtonFav.Text += $" ({favCount})";
            ButtonFav.ForeColor = IsFavorited(status) ? Color.HotPink : Color.Black;
            return;
        }

        private bool IsRetweeted(Status inStatus)
        {
            return m_Tokens.Statuses.Show(id: inStatus.Id).IsRetweeted.GetValueOrDefault(false);
        }

        private bool IsFavorited(Status inStatus)
        {
            return m_Tokens.Statuses.Show(id: inStatus.Id).IsFavorited.GetValueOrDefault(false);
        }

        private OAuth.OAuthSession m_Session = null;
        private Tokens m_Tokens = null;

        private AuthorizeKeys.ApplicationKeys m_ApplicationKeys = null;
        private AuthorizeKeys.AccessKeys m_AccessKeys = null;

        private CtrlTweetThreadView m_TweetThreadView = null;
    }
}
