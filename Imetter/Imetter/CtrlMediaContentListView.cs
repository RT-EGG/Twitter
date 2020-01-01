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
    public partial class CtrlMediaContentListView : UserControl
    {
        public CtrlMediaContentListView()
        {
            InitializeComponent();
        }

        public IEnumerable<MediaEntity> Medias
        {
            get { return null; }
            set {
                return;
            }
        }
    }
}
