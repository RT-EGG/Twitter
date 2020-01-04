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
            this.PanelAction = new System.Windows.Forms.TableLayoutPanel();
            this.ContentsView = new Imetter.CtrlMediaContentListView();
            this.UserInfo = new Imetter.CtrlUserInfoView();
            this.SuspendLayout();
            // 
            // LabelTweetText
            // 
            this.LabelTweetText.AutoSize = true;
            this.LabelTweetText.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelTweetText.Location = new System.Drawing.Point(0, 95);
            this.LabelTweetText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTweetText.Name = "LabelTweetText";
            this.LabelTweetText.Padding = new System.Windows.Forms.Padding(3);
            this.LabelTweetText.Size = new System.Drawing.Size(31, 18);
            this.LabelTweetText.TabIndex = 1;
            this.LabelTweetText.Text = "text";
            // 
            // PanelAction
            // 
            this.PanelAction.ColumnCount = 4;
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PanelAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PanelAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelAction.Location = new System.Drawing.Point(0, 413);
            this.PanelAction.Margin = new System.Windows.Forms.Padding(2);
            this.PanelAction.Name = "PanelAction";
            this.PanelAction.RowCount = 1;
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.PanelAction.Size = new System.Drawing.Size(529, 57);
            this.PanelAction.TabIndex = 3;
            // 
            // ContentsView
            // 
            this.ContentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsView.Location = new System.Drawing.Point(0, 113);
            this.ContentsView.Margin = new System.Windows.Forms.Padding(1);
            this.ContentsView.Medias = null;
            this.ContentsView.Name = "ContentsView";
            this.ContentsView.Size = new System.Drawing.Size(529, 357);
            this.ContentsView.TabIndex = 2;
            this.ContentsView.Click += new System.EventHandler(this.ContentsView_Click);
            this.ContentsView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ContentsView_MouseClick);
            // 
            // UserInfo
            // 
            this.UserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserInfo.Location = new System.Drawing.Point(0, 0);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.Size = new System.Drawing.Size(529, 95);
            this.UserInfo.TabIndex = 0;
            this.UserInfo.User = null;
            // 
            // CtrlTweetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelAction);
            this.Controls.Add(this.ContentsView);
            this.Controls.Add(this.LabelTweetText);
            this.Controls.Add(this.UserInfo);
            this.Name = "CtrlTweetView";
            this.Size = new System.Drawing.Size(529, 470);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CtrlUserInfoView UserInfo;
        private System.Windows.Forms.Label LabelTweetText;
        private CtrlMediaContentListView ContentsView;
        private System.Windows.Forms.TableLayoutPanel PanelAction;
    }
}
