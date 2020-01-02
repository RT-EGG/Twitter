using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreTweet;

namespace Imetter
{
    public partial class CtrlTweetView : UserControl
    {
        public CtrlTweetView()
        {
            InitializeComponent();
        }

        public Status Status
        {
            get { return m_Status; }
            set {
                m_Status = value;
                if (m_Status != null) {
                    UserInfo.User = Status.User;
                    LabelTweetText.Text = Status.Text;
                    ContentsView.Medias = Status.Entities.Media;
                    ContentsView.Visible = Status.Entities.Media.Length != 0;
                }
                return;
            }
        }

        private Status m_Status = null;
    }
}
