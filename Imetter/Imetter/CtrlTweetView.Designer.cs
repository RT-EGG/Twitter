namespace Imetter
{
    partial class CtrlTweetView
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
            this.LabelTweetText = new System.Windows.Forms.Label();
            this.LabelTimeStamp = new System.Windows.Forms.Label();
            this.ContentsView = new Imetter.CtrlMediaThumbnailListView();
            this.UserInfo = new Imetter.CtrlUserInfoView();
            this.SuspendLayout();
            // 
            // LabelTweetText
            // 
            this.LabelTweetText.AutoEllipsis = true;
            this.LabelTweetText.AutoSize = true;
            this.LabelTweetText.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelTweetText.Location = new System.Drawing.Point(0, 80);
            this.LabelTweetText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTweetText.Name = "LabelTweetText";
            this.LabelTweetText.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.LabelTweetText.Size = new System.Drawing.Size(685, 18);
            this.LabelTweetText.TabIndex = 1;
            this.LabelTweetText.Text = "textaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            // 
            // LabelTimeStamp
            // 
            this.LabelTimeStamp.AutoSize = true;
            this.LabelTimeStamp.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelTimeStamp.Location = new System.Drawing.Point(0, 62);
            this.LabelTimeStamp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTimeStamp.Name = "LabelTimeStamp";
            this.LabelTimeStamp.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.LabelTimeStamp.Size = new System.Drawing.Size(31, 18);
            this.LabelTimeStamp.TabIndex = 4;
            this.LabelTimeStamp.Text = "text";
            // 
            // ContentsView
            // 
            this.ContentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsView.Location = new System.Drawing.Point(0, 98);
            this.ContentsView.Margin = new System.Windows.Forms.Padding(1);
            this.ContentsView.MediaIndex = -1;
            this.ContentsView.Medias = null;
            this.ContentsView.Name = "ContentsView";
            this.ContentsView.Padding = new System.Windows.Forms.Padding(3);
            this.ContentsView.Size = new System.Drawing.Size(529, 372);
            this.ContentsView.TabIndex = 2;
            this.ContentsView.OnMouseClickMedia += new Imetter.MediaMouseClickEvent(this.ContentsView_OnMouseClickMedia);
            // 
            // UserInfo
            // 
            this.UserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserInfo.Location = new System.Drawing.Point(0, 0);
            this.UserInfo.Margin = new System.Windows.Forms.Padding(4);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.Size = new System.Drawing.Size(529, 62);
            this.UserInfo.TabIndex = 0;
            this.UserInfo.User = null;
            // 
            // CtrlTweetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContentsView);
            this.Controls.Add(this.LabelTweetText);
            this.Controls.Add(this.LabelTimeStamp);
            this.Controls.Add(this.UserInfo);
            this.Name = "CtrlTweetView";
            this.Size = new System.Drawing.Size(529, 470);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelTweetText;
        private CtrlMediaThumbnailListView ContentsView;
        private CtrlUserInfoView UserInfo;
        private System.Windows.Forms.Label LabelTimeStamp;
    }
}
