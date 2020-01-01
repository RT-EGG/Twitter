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
    public partial class CtrlMediaContentView : UserControl
    {
        public CtrlMediaContentView()
        {
            InitializeComponent();
        }

        public MediaEntity MediaEntity
        {
            get { return m_MediaEntity; }
            set {
                m_MediaEntity = value;
                if (MediaEntity != null) {
                    ImageUpdateTimer.Enabled = true;
                }
                return;
            }
        }

        private async void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            ImageUpdateTimer.Enabled = false;
            m_Media = await TweetMedia.QueryAsync(m_MediaEntity);
            switch (m_Media.MediaType) {
                case TweetMediaType.Image:
                    this.BackgroundImage = (m_Media as ITweetImageMedia).Image;
                    break;
                default:
                    break;
            }
            return;
        }

        private MediaEntity m_MediaEntity = null;
        private ITweetMedia m_Media = null;
    }
}
