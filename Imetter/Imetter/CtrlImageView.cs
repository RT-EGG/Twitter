using System;
using System.Drawing;
using System.Windows.Forms;

namespace Imetter
{
    public partial class CtrlImageView : UserControl
    {
        public CtrlImageView()
        {
            InitializeComponent();
        }

        public Image Image
        { 
            get { return m_Image; } 
            set {
                m_Image = value;
                Invalidate();
            }
        }
        public ImagePaintOption PaintOption
        { get; set; } = new ImagePaintOption();
        public Rectangle ImageDisplayRectangle
        { 
            get {
                if (Image == null)
                    return new Rectangle();
                return PaintOption.CalcImageDisplayRectangle(this.Size, Image.Size);
            } 
        }

        public  class ImagePaintOption
        {
            public Color BackColor = Color.Gray;
            public bool LimitToOriginalSize = true;
            //public Padding Padding = new Padding(0);

            public Rectangle CalcImageDisplayRectangle(Size inControlSize, Size inImageSize)
            {
                Rectangle result = new Rectangle();

                int width, height;
                if (((float)inImageSize.Width / (float)inControlSize.Width) < ((float)inImageSize.Height / (float)inControlSize.Height)) {
                    height = inControlSize.Height;
                    width = (int)Math.Truncate((float)inImageSize.Width * ((float)height / (float)inImageSize.Height));
                } else {
                    width = inControlSize.Width;
                    height = (int)Math.Truncate((float)inImageSize.Height * ((float)width / (float)inImageSize.Width));
                }

                if (LimitToOriginalSize) {
                    width = Math.Min(width, inImageSize.Width);
                    height = Math.Min(height, inImageSize.Height);
                }

                result.X = (inControlSize.Width / 2) - (width / 2);
                result.Y = (inControlSize.Height / 2) - (height / 2);
                result.Width = width;
                result.Height = height;

                return result;
            }
        }

        public static void PaintTo(Control inControl, Graphics inTarget, Image inImage, ImagePaintOption inOption)
        {
            inTarget.Clear(inOption.BackColor);
            if (inImage != null)
                inTarget.DrawImage(inImage, inOption.CalcImageDisplayRectangle(inControl.Size, inImage.Size));
            return;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);
            if (Image != null)
                PaintTo(this, e.Graphics, Image, PaintOption);
            return;
        }

        private Image m_Image = null;
    }
}
