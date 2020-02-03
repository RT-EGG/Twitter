using CoreTweet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Imetter
{
    public partial class CtrlMediaThumbnailListView : UserControl
    {
        public event MediaMouseClickEvent OnMouseClickMedia;

        public CtrlMediaThumbnailListView()
        {
            InitializeComponent();
        }

        public void MovePrevious()
        {
            if (!CanMovePrevious)
                return;

            --MediaIndex;
            return;
        }

        public void MoveNext()
        {
            if (!CanMoveNext)
                return;

            ++MediaIndex;
            return;
        }

        public bool CanMovePrevious
        { get { return (Medias != null) && (MediaIndex > 0); } }

        public bool CanMoveNext
        { get { return (Medias != null) && (MediaIndex < (Medias.Count() - 1)); } }

        public IList<MediaEntity> Medias
        {
            get { return m_Medias; }
            set {
                m_Medias = value;

                if ((Medias != null) && (Medias.Count() > 0))
                    MediaIndex = 0;
                else
                    MediaIndex = -1;
                return;
            }
        }

        public int MediaIndex
        {
            get { return m_MediaIndex; }
            set {
                m_MediaIndex = value;
                if (Medias == null)
                    m_MediaIndex = -1;

                if (MediaIndex == -1) {
                    ThumbnailView.MediaEntity = null;

                    ButtonMovePrevious.Enabled = false;
                    ButtonMoveNext.Enabled = false;
                    LabelMediaIndex.Visible = false;

                } else {
                    m_MediaIndex = Math.Min(Medias.Count() - 1, Math.Max(0, m_MediaIndex));
                    ThumbnailView.MediaEntity = m_Medias[m_MediaIndex];

                    ButtonMovePrevious.Enabled = m_MediaIndex > 0;
                    ButtonMoveNext.Enabled = m_MediaIndex < (Medias.Count() - 1);
                    LabelMediaIndex.Visible = true;
                    LabelMediaIndex.Text = $"{ m_MediaIndex + 1 } / { Medias.Count() }";
                }
                return;
            }
        }

        private void ThumbnailView_OnMouseClickMedia(object inSender, IMediaMouseClickEventArgs inMedia)
        {
            OnMouseClickMedia?.Invoke(inSender, inMedia);
            return;
        }

        private IList<MediaEntity> m_Medias = null;
        private int m_MediaIndex = -1;

        private void ButtonMovePrevious_Click(object sender, EventArgs e)
        {
            MovePrevious();
            return;
        }

        private void ButtonMoveNext_Click(object sender, EventArgs e)
        {
            MoveNext();
            return;
        }
    }
}
