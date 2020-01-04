namespace Imetter
{
    partial class FormMain
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ButtonUpdateTimeline = new System.Windows.Forms.Button();
            this.RequestTimer = new System.Windows.Forms.Timer(this.components);
            this.TweetView = new Imetter.CtrlTweetView();
            this.SuspendLayout();
            // 
            // ButtonUpdateTimeline
            // 
            this.ButtonUpdateTimeline.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonUpdateTimeline.Location = new System.Drawing.Point(3, 3);
            this.ButtonUpdateTimeline.MaximumSize = new System.Drawing.Size(200, 500);
            this.ButtonUpdateTimeline.Name = "ButtonUpdateTimeline";
            this.ButtonUpdateTimeline.Size = new System.Drawing.Size(200, 25);
            this.ButtonUpdateTimeline.TabIndex = 1;
            this.ButtonUpdateTimeline.Text = "Update";
            this.ButtonUpdateTimeline.UseVisualStyleBackColor = true;
            this.ButtonUpdateTimeline.Click += new System.EventHandler(this.ButtonUpdateTimeline_Click);
            // 
            // RequestTimer
            // 
            this.RequestTimer.Interval = 60000;
            this.RequestTimer.Tick += new System.EventHandler(this.RequestTimer_Tick);
            // 
            // TweetView
            // 
            this.TweetView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TweetView.Location = new System.Drawing.Point(3, 28);
            this.TweetView.Name = "TweetView";
            this.TweetView.Size = new System.Drawing.Size(698, 369);
            this.TweetView.Status = null;
            this.TweetView.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 400);
            this.Controls.Add(this.TweetView);
            this.Controls.Add(this.ButtonUpdateTimeline);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonUpdateTimeline;
        private System.Windows.Forms.Timer RequestTimer;
        private CtrlTweetView TweetView;
    }
}

