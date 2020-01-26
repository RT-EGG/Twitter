namespace AutoReplier
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
            this.TextRateLimits = new System.Windows.Forms.TextBox();
            this.TextTimeLine = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextRateLimits
            // 
            this.TextRateLimits.Dock = System.Windows.Forms.DockStyle.Left;
            this.TextRateLimits.Location = new System.Drawing.Point(0, 0);
            this.TextRateLimits.Multiline = true;
            this.TextRateLimits.Name = "TextRateLimits";
            this.TextRateLimits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextRateLimits.Size = new System.Drawing.Size(507, 450);
            this.TextRateLimits.TabIndex = 0;
            // 
            // TextTimeLine
            // 
            this.TextTimeLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextTimeLine.Location = new System.Drawing.Point(507, 0);
            this.TextTimeLine.Multiline = true;
            this.TextTimeLine.Name = "TextTimeLine";
            this.TextTimeLine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTimeLine.Size = new System.Drawing.Size(860, 450);
            this.TextTimeLine.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 450);
            this.Controls.Add(this.TextTimeLine);
            this.Controls.Add(this.TextRateLimits);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextRateLimits;
        private System.Windows.Forms.TextBox TextTimeLine;
    }
}

