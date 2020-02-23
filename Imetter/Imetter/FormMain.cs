using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Linq;
using CoreTweet;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Imetter
{
    public partial class FormMain : Form
    {
        const string ThreadFileName = "thread.json";

        public FormMain()
        {
            InitializeComponent();

            return;
        }

        public void EndProgram()
        {
            m_ThreadConfiguration.Keyword = m_TweetThreadView?.Keyword ?? "";
            List<string> saveDirectories = new List<string>();
            for (int i = 0; i < ComboSaveImageDirectories.Items.Count - 1; ++i) {
                saveDirectories.Add(ComboSaveImageDirectories.Items[i].ToString());
            }
            m_ThreadConfiguration.SaveDirectories = saveDirectories.ToArray();
            m_ThreadConfiguration.ExportToFile(ThreadFileName);

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
                m_TweetThreadView.MouseClickTweetMedia += M_TweetThreadView_MouseClickTweetMedia;

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

            const string ThreadFileName = "thread.json";
            if (File.Exists(ThreadFileName)) {
                try {
                    m_ThreadConfiguration = JsonSerializable.LoadFromFile<ThreadConfiguration>(ThreadFileName);

                } catch {
                    File.Delete(ThreadFileName);
                }
            }
            if (m_ThreadConfiguration.Keyword != "") {
                CreateNewFilterStream(m_ThreadConfiguration.Keyword);
            }

            ComboSaveImageDirectories.Items.Clear();
            foreach (string directory in m_ThreadConfiguration.SaveDirectories) {
                ComboSaveImageDirectories.Items.Add(directory);
            }
            ComboSaveImageDirectories.Items.Add("Add new directory...");

            return;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (PanelMediaDisplay.Visible) {
                PanelMediaDisplay.Media = null;
                PanelMediaDisplay.Visible = false;
            }
            PanelThreadView.Visible = !PanelMediaDisplay.Visible;
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

        private void M_TweetThreadView_MouseClickTweetMedia(object inSender, IMediaMouseClickEventArgs inMedia)
        {
            PanelMediaDisplay.Media = inMedia.Media;
            PanelMediaDisplay.Visible = PanelMediaDisplay.Media != null;
            PanelThreadView.Visible = !PanelMediaDisplay.Visible;
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

        private void ComboSaveImageDirectories_TextChanged(object sender, EventArgs e)
        {
            if (ComboSaveImageDirectories.SelectedIndex == (ComboSaveImageDirectories.Items.Count - 1)) {
                // add new directory
                var dialog = new CommonOpenFileDialog("フォルダ選択");
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok) {
                    ComboSaveImageDirectories.Items.Insert(ComboSaveImageDirectories.Items.Count - 1, dialog.FileName);
                    ComboSaveImageDirectories.SelectedIndex = ComboSaveImageDirectories.Items.Count - 2;
                } else {
                    ComboSaveImageDirectories.SelectedIndex = -1;
                }
            } else {
                ButtonSaveImage.Text = ComboSaveImageDirectories.Text;

            }

            return;
        }

        private void ButtonSaveImage_Click(object sender, EventArgs e)
        {
            int index = ComboSaveImageDirectories.SelectedIndex;
            if ((index < 0) || ((ComboSaveImageDirectories.Items.Count - 1) < index))
                return;
            Status status = m_TweetThreadView.Status;
            if (status == null)
                return;
            Debug.Assert(ButtonSaveImage.Text == ComboSaveImageDirectories.Text, $"(\"{ ButtonSaveImage.Text }\" == \"{ ComboSaveImageDirectories.Text }\")");

            string directory = ButtonSaveImage.Text;
            string name = ConvertToFileName(m_ThreadConfiguration.SaveFileNamePattern, status, m_TweetThreadView.CurrentMediaIndex);
            string filepath = directory + "\\" + name;

            TweetMedia.Query(m_TweetThreadView.CurrentMedia, (ITweetMedia inMedia) => {
                if (!(inMedia is ITweetImageMedia)) {
                    AddLog($"Media is { inMedia.MediaType.ToString() }, not image.");
                    return;
                }

                ITweetImageMedia media = (inMedia as ITweetImageMedia);
                filepath = $"{ filepath }{ Path.GetExtension(media.URL) }";
                media.Image.Save(filepath);
                AddLog($"Completed save to { filepath }");
            });

            return;
        }

        private string ConvertToFileName(string inPattern, Status inStatus, int inMediaIndex)
        {
            int index = 0;
            string name = "";
            while (index < inPattern.Length) {
                switch (inPattern[index]) {
                    case '<':
                        int endIndex = inPattern.IndexOf('>', ++index);
                        if (endIndex == -1)
                            // TODO create new exception class for this pattern
                            throw new InvalidFileNameCharacterException('<');
                        DateTime time = inStatus.CreatedAt.DateTime;
                        string datetime = inPattern.Substring(index, endIndex - index);
                        datetime = datetime.Replace("YYYY", $"{time.Year:D4}");
                        datetime = datetime.Replace("YY", $"{time.Year:D4}".Substring(2, 2));
                        datetime = datetime.Replace("MM", $"{time.Month:D2}");
                        datetime = datetime.Replace("DD", $"{time.Day:D2}");
                        datetime = datetime.Replace("HH", $"{time.Hour:D2}");
                        datetime = datetime.Replace("NN", $"{time.Minute:D2}");
                        name += datetime;
                        index = endIndex + 1;
                        break;
                    case '?':
                        //{ get; set; } = "<YYYYMMDDHHNN>?U?I";
                        switch (inPattern[++index]) {
                            case 'U':
                                name += inStatus.User.ScreenName;
                                break;
                            case 'I':
                                name += $"{ inMediaIndex + 1 }";
                                break;
                            default:
                                throw new InvalidFileNameCharacterException('?');
                        }
                        ++index;
                        break;
                    case '>':
                    case '\\':
                    case '/':
                    case ':':
                    case '*':
                    case '\"':
                        throw new InvalidFileNameCharacterException(inPattern[index]);
                    default:
                        name += inPattern[index++];
                        break;
                }
            }

            return name;
        }

        private void AddLog(string inLine)
        {
            Action add = () => {
                TextBoxLog.Text += inLine + Environment.NewLine;

                const int MaxLines = 10;
                if (TextBoxLog.Lines.Length > MaxLines) {
                    List<string> lines = new List<string>(TextBoxLog.Lines);

                    lines.RemoveRange(0, lines.Count - MaxLines);
                    TextBoxLog.Lines = lines.ToArray();
                }

                TextBoxLog.Select(TextBoxLog.Text.Length, 0);
            };

            if (InvokeRequired) {
                Invoke((MethodInvoker) delegate() { add(); });
            } else {
                add();
            }
            return;
        }

        private OAuth.OAuthSession m_Session = null;
        private Tokens m_Tokens = null;

        private AuthorizeKeys.ApplicationKeys m_ApplicationKeys = null;
        private AuthorizeKeys.AccessKeys m_AccessKeys = null;

        private CtrlTweetThreadView m_TweetThreadView = null;
        private ThreadConfiguration m_ThreadConfiguration = new ThreadConfiguration();
        //private List<string> m_SaveDirectories = new List<string>();
    }
}
