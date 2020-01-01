using CoreTweet;
using System.Diagnostics;
using System.Windows.Forms;

namespace Imetter
{
    public partial class FormUserPincodeQuery : Form
    {
        public FormUserPincodeQuery(OAuth.OAuthSession inSession)
        {
            InitializeComponent();

            m_Session = inSession;
            AccessAuthorizeURL();
            return;
        }

        public string Pincode => TextPincode.Text;

        private void LabelReaccess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccessAuthorizeURL();
            return;
        }

        private void AccessAuthorizeURL()
        {
            Process.Start(m_Session.AuthorizeUri.AbsoluteUri);
            return;
        }

        private readonly OAuth.OAuthSession m_Session = null;
    }
}
