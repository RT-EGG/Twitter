namespace Imetter
{
    partial class CtrlMediaThumbnailListView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            Imetter.CtrlImageView.ImagePaintOption imagePaintOption2 = new Imetter.CtrlImageView.ImagePaintOption();
            this.ButtonMovePrevious = new System.Windows.Forms.Button();
            this.ButtonMoveNext = new System.Windows.Forms.Button();
            this.ThumbnailView = new Imetter.CtrlMediaThumbnailView();
            this.LabelMediaIndex = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonMovePrevious
            // 
            this.ButtonMovePrevious.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonMovePrevious.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonMovePrevious.Font = new System.Drawing.Font("MS UI Gothic", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonMovePrevious.ForeColor = System.Drawing.Color.Gray;
            this.ButtonMovePrevious.Location = new System.Drawing.Point(3, 3);
            this.ButtonMovePrevious.Name = "ButtonMovePrevious";
            this.ButtonMovePrevious.Size = new System.Drawing.Size(48, 393);
            this.ButtonMovePrevious.TabIndex = 1;
            this.ButtonMovePrevious.Text = "<";
            this.ButtonMovePrevious.UseVisualStyleBackColor = false;
            this.ButtonMovePrevious.Click += new System.EventHandler(this.ButtonMovePrevious_Click);
            // 
            // ButtonMoveNext
            // 
            this.ButtonMoveNext.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonMoveNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonMoveNext.Font = new System.Drawing.Font("MS UI Gothic", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonMoveNext.ForeColor = System.Drawing.Color.Gray;
            this.ButtonMoveNext.Location = new System.Drawing.Point(524, 3);
            this.ButtonMoveNext.Name = "ButtonMoveNext";
            this.ButtonMoveNext.Size = new System.Drawing.Size(48, 393);
            this.ButtonMoveNext.TabIndex = 2;
            this.ButtonMoveNext.Text = ">";
            this.ButtonMoveNext.UseVisualStyleBackColor = false;
            this.ButtonMoveNext.Click += new System.EventHandler(this.ButtonMoveNext_Click);
            // 
            // ThumbnailView
            // 
            this.ThumbnailView.BackColor = System.Drawing.SystemColors.Control;
            this.ThumbnailView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ThumbnailView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ThumbnailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThumbnailView.Image = null;
            this.ThumbnailView.Location = new System.Drawing.Point(51, 25);
            this.ThumbnailView.Margin = new System.Windows.Forms.Padding(2);
            this.ThumbnailView.MediaEntity = null;
            this.ThumbnailView.Name = "ThumbnailView";
            this.ThumbnailView.PaintOption = imagePaintOption2;
            this.ThumbnailView.Size = new System.Drawing.Size(473, 371);
            this.ThumbnailView.TabIndex = 3;
            this.ThumbnailView.OnMouseClickMedia += new Imetter.MediaMouseClickEvent(this.ThumbnailView_OnMouseClickMedia);
            // 
            // LabelMediaIndex
            // 
            this.LabelMediaIndex.AutoSize = true;
            this.LabelMediaIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelMediaIndex.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelMediaIndex.Location = new System.Drawing.Point(51, 3);
            this.LabelMediaIndex.Name = "LabelMediaIndex";
            this.LabelMediaIndex.Padding = new System.Windows.Forms.Padding(3);
            this.LabelMediaIndex.Size = new System.Drawing.Size(52, 22);
            this.LabelMediaIndex.TabIndex = 4;
            this.LabelMediaIndex.Text = "label1";
            // 
            // CtrlMediaThumbnailListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ThumbnailView);
            this.Controls.Add(this.LabelMediaIndex);
            this.Controls.Add(this.ButtonMovePrevious);
            this.Controls.Add(this.ButtonMoveNext);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CtrlMediaThumbnailListView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(575, 399);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonMovePrevious;
        private System.Windows.Forms.Button ButtonMoveNext;
        private CtrlMediaThumbnailView ThumbnailView;
        private System.Windows.Forms.Label LabelMediaIndex;
    }
}
