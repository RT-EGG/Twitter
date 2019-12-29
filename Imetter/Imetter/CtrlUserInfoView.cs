﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreTweet;
using System.Net;

namespace TwitterTimeLine
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
                    UserChanged = true;
                    LabelUserName.Text = $"@{ User.Name} ";
                    LabelUserScreenName.Text = User.ScreenName;
                    this.Invalidate();
                }
                return;
            }
        }

        private async void CtrlUserInfoView_Paint(object sender, PaintEventArgs e)
        {
            if (UserChanged) {
                IUserProfileImages newImages = await UserProfileImages.QueryAsync(User);
                PanelIcon.BackgroundImage = newImages.Icon;

                UserChanged = false;
            }
            return;
        }

        private User m_User = null;
        private bool UserChanged = false;
    }
}
