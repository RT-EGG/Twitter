﻿using CoreTweet;
using System;
using System.Windows.Forms;
using System.Drawing;

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
                    TweetMedia.Query(MediaEntity, (ITweetMedia inMedia) => {
                        m_Media = inMedia;
                        switch (m_Media.MediaType) {
                            case TweetMediaType.Image:
                                this.BackgroundImage = (m_Media as ITweetImageMedia).Image;
                                break;
                            default:
                                break;
                        }
                    });
                }
                return;
            }
        }

        public bool ContainsInThumbnail(Point inPoint)
        {
            if (m_Media == null)
                return false;

            return false;
        }

        private MediaEntity m_MediaEntity = null;
        private ITweetMedia m_Media = null;
    }
}
