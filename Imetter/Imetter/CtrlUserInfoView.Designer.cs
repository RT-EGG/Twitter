namespace Imetter
{
    partial class CtrlUserInfoView
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
            this.PanelIcon = new System.Windows.Forms.Panel();
            this.LabelUserScreenName = new System.Windows.Forms.Label();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.ColumnCount = 2;
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Panel.Controls.Add(this.PanelIcon, 0, 0);
            this.Panel.Controls.Add(this.LabelUserScreenName, 1, 0);
            this.Panel.Controls.Add(this.LabelUserName, 1, 1);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.RowCount = 2;
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Panel.Size = new System.Drawing.Size(414, 64);
            this.Panel.TabIndex = 0;
            // 
            // PanelIcon
            // 
            this.PanelIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PanelIcon.Location = new System.Drawing.Point(3, 3);
            this.PanelIcon.Name = "PanelIcon";
            this.Panel.SetRowSpan(this.PanelIcon, 2);
            this.PanelIcon.Size = new System.Drawing.Size(58, 58);
            this.PanelIcon.TabIndex = 0;
            // 
            // LabelUserScreenName
            // 
            this.LabelUserScreenName.AutoSize = true;
            this.LabelUserScreenName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelUserScreenName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelUserScreenName.Location = new System.Drawing.Point(67, 14);
            this.LabelUserScreenName.Name = "LabelUserScreenName";
            this.LabelUserScreenName.Padding = new System.Windows.Forms.Padding(1);
            this.LabelUserScreenName.Size = new System.Drawing.Size(344, 16);
            this.LabelUserScreenName.TabIndex = 1;
            this.LabelUserScreenName.Text = "ScreenName";
            // 
            // LabelUserName
            // 
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelUserName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelUserName.Location = new System.Drawing.Point(67, 42);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Padding = new System.Windows.Forms.Padding(3);
            this.LabelUserName.Size = new System.Drawing.Size(344, 22);
            this.LabelUserName.TabIndex = 2;
            this.LabelUserName.Text = "UserName";
            // 
            // CtrlUserInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel);
            this.Name = "CtrlUserInfoView";
            this.Size = new System.Drawing.Size(414, 64);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Panel;
        private System.Windows.Forms.Panel PanelIcon;
        private System.Windows.Forms.Label LabelUserScreenName;
        private System.Windows.Forms.Label LabelUserName;
    }
}
