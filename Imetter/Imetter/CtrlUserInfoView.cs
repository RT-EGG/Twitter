using System.Windows.Forms;
using CoreTweet;

namespace Imetter
{
    public partial class CtrlUserInfoView : UserControl
    {
        public CtrlUserInfoView()
        {
            InitializeComponent();
        }

        public User User
        {
            get { return m_User; }
            set {
                m_User = value;
                this.BackgroundImage = null;
                PanelIcon.BackgroundImage = null;

                if (User == null) {
                    LabelUserName.Text = "---";
                    LabelUserScreenName.Text = "---";

                } else {
                    LabelUserName.Text = User.Name;
                    LabelUserScreenName.Text = $"@{ User.ScreenName }";
                    UserProfileImages.QueryAsync(User, (IUserProfileImages inImages) => {
                        PanelIcon.BackgroundImage = inImages.Icon;
                    });
                }
                return;
            }
        }

        private User m_User = null;
    }
}
