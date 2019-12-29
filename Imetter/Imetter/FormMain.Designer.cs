namespace TwitterTimeLine
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
            this.TextTimeline = new System.Windows.Forms.TextBox();
            this.ButtonUpdateTimeline = new System.Windows.Forms.Button();
            this.RequestTimer = new System.Windows.Forms.Timer(this.components);
            this.UserInfoView = new TwitterTimeLine.CtrlUserInfoView();
            this.SuspendLayout();
            // 
            // TextTimeline
            // 
            this.TextTimeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextTimeline.Location = new System.Drawing.Point(3, 135);
            this.TextTimeline.Multiline = true;
            this.TextTimeline.Name = "TextTimeline";
            this.TextTimeline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTimeline.Size = new System.Drawing.Size(698, 262);
            this.TextTimeline.TabIndex = 0;
            // 
            // ButtonUpdateTimeline
            // 
            this.ButtonUpdateTimeline.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonUpdateTimeline.Location = new System.Drawing.Point(3, 110);
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
            // UserInfoView
            // 
            this.UserInfoView.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserInfoView.Location = new System.Drawing.Point(3, 3);
            this.UserInfoView.Name = "UserInfoView";
            this.UserInfoView.Size = new System.Drawing.Size(698, 107);
            this.UserInfoView.TabIndex = 2;
            this.UserInfoView.User = null;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 400);
            this.Controls.Add(this.TextTimeline);
            this.Controls.Add(this.ButtonUpdateTimeline);
            this.Controls.Add(this.UserInfoView);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextTimeline;
        private System.Windows.Forms.Button ButtonUpdateTimeline;
        private System.Windows.Forms.Timer RequestTimer;
        private CtrlUserInfoView UserInfoView;
    }
}

