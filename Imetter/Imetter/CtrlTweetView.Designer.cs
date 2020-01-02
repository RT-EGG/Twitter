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
            this.UserInfo = new Imetter.CtrlUserInfoView();
            this.ContentsView = new Imetter.CtrlMediaContentListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // LabelTweetText
            // 
            this.LabelTweetText.AutoSize = true;
            this.LabelTweetText.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelTweetText.Location = new System.Drawing.Point(0, 142);
            this.LabelTweetText.Name = "LabelTweetText";
            this.LabelTweetText.Padding = new System.Windows.Forms.Padding(5);
            this.LabelTweetText.Size = new System.Drawing.Size(47, 28);
            this.LabelTweetText.TabIndex = 1;
            this.LabelTweetText.Text = "text";
            // 
            // UserInfo
            // 
            this.UserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserInfo.Location = new System.Drawing.Point(0, 0);
            this.UserInfo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.Size = new System.Drawing.Size(882, 142);
            this.UserInfo.TabIndex = 0;
            this.UserInfo.User = null;
            // 
            // ContentsView
            // 
            this.ContentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsView.Location = new System.Drawing.Point(0, 170);
            this.ContentsView.Medias = null;
            this.ContentsView.Name = "ContentsView";
            this.ContentsView.Size = new System.Drawing.Size(882, 535);
            this.ContentsView.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 620);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 85);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // CtrlTweetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ContentsView);
            this.Controls.Add(this.LabelTweetText);
            this.Controls.Add(this.UserInfo);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "CtrlTweetView";
            this.Size = new System.Drawing.Size(882, 705);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CtrlUserInfoView UserInfo;
        private System.Windows.Forms.Label LabelTweetText;
        private CtrlMediaContentListView ContentsView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
