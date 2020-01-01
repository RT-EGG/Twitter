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
            this.Panel = new System.Windows.Forms.TableLayoutPanel();
            this.UserInfo = new Imetter.CtrlUserInfoView();
            this.LabelTweetText = new System.Windows.Forms.Label();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.ColumnCount = 1;
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Panel.Controls.Add(this.UserInfo, 0, 0);
            this.Panel.Controls.Add(this.LabelTweetText, 0, 1);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Panel.Name = "Panel";
            this.Panel.RowCount = 3;
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Panel.Size = new System.Drawing.Size(882, 705);
            this.Panel.TabIndex = 0;
            // 
            // UserInfo
            // 
            this.UserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserInfo.Location = new System.Drawing.Point(5, 4);
            this.UserInfo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.Size = new System.Drawing.Size(872, 142);
            this.UserInfo.TabIndex = 0;
            this.UserInfo.User = null;
            // 
            // LabelTweetText
            // 
            this.LabelTweetText.AutoSize = true;
            this.LabelTweetText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelTweetText.Location = new System.Drawing.Point(3, 150);
            this.LabelTweetText.Name = "LabelTweetText";
            this.LabelTweetText.Padding = new System.Windows.Forms.Padding(5);
            this.LabelTweetText.Size = new System.Drawing.Size(876, 495);
            this.LabelTweetText.TabIndex = 1;
            this.LabelTweetText.Text = "text";
            // 
            // CtrlTweetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "CtrlTweetView";
            this.Size = new System.Drawing.Size(882, 705);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Panel;
        private CtrlUserInfoView UserInfo;
        private System.Windows.Forms.Label LabelTweetText;
    }
}
