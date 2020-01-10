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
        public event MediaMouseClickEvent OnMouseClickMedia;

        public CtrlMediaContentListView()
        {
            InitializeComponent();
        }

        public IEnumerable<MediaEntity> Medias
        {
            get { return null; }
            set {
                m_ContentViewList.Clear();
                if (value != null) {
                    foreach (var entity in value) {
                        switch (TweetMedia.GetMediaType(entity)) {
                            case TweetMediaType.Image:
                                break;
                            default:
                                continue;
                        }

                        CtrlMediaContentView view = new CtrlMediaContentView();
                        view.Parent = this;
                        view.MediaEntity = entity;
                        view.OnMouseClickMedia += View_OnMouseClickMedia;
                        m_ContentViewList.Add(view);
                    }
                }

                DoLayout();
                return;
            }
        }

        private void DoLayout()
        {
            switch (m_ContentViewList.Count) {
                case 1:
                    SetLayout(m_ContentViewList[0], 0, 0, 2, 2);
                    break;
                case 2:
                    SetLayout(m_ContentViewList[0], 0, 0, 2, 1);
                    SetLayout(m_ContentViewList[1], 0, 1, 2, 1);
                    break;
                case 3:
                    SetLayout(m_ContentViewList[0], 0, 0, 2, 1);
                    SetLayout(m_ContentViewList[1], 0, 1, 1, 1);
                    SetLayout(m_ContentViewList[2], 1, 1, 1, 1);
                    break;
                case 4:
                    SetLayout(m_ContentViewList[0], 0, 0, 1, 1);
                    SetLayout(m_ContentViewList[1], 0, 1, 1, 1);
                    SetLayout(m_ContentViewList[2], 1, 0, 1, 1);
                    SetLayout(m_ContentViewList[3], 1, 1, 1, 1);
                    break;
            }

            return;
        }

        private void SetLayout(Control inControl, int inRow, int inCol, int inRowSpan, int inColSpan)
        {
            inControl.Parent = LayoutPanel;
            inControl.Dock = DockStyle.Fill;
            LayoutPanel.SetCellPosition(inControl, new TableLayoutPanelCellPosition(inCol, inRow));
            LayoutPanel.SetRowSpan(inControl, inRowSpan);
            LayoutPanel.SetColumnSpan(inControl, inColSpan);
            return;
        }

        private void View_OnMouseClickMedia(object inSender, IMediaMouseClickEventArgs inMedia)
        {
            OnMouseClickMedia?.Invoke(inSender, inMedia);
            return;
        }

        private List<CtrlMediaContentView> m_ContentViewList = new List<CtrlMediaContentView>();
    }
}
