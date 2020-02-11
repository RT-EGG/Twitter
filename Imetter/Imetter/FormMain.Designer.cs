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
            this.PanelThreadView = new System.Windows.Forms.Panel();
            this.PanelMediaDisplay = new Imetter.CtrlMediaDisplayPanel();
            this.PanelKeyword = new System.Windows.Forms.Panel();
            this.TextBoxKeyword = new System.Windows.Forms.TextBox();
            this.ButtonChangeKeyword = new System.Windows.Forms.Button();
            this.PanelKeyword.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelThreadView
            // 
            this.PanelThreadView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelThreadView.Location = new System.Drawing.Point(105, 29);
            this.PanelThreadView.Margin = new System.Windows.Forms.Padding(2);
            this.PanelThreadView.Name = "PanelThreadView";
            this.PanelThreadView.Size = new System.Drawing.Size(496, 436);
            this.PanelThreadView.TabIndex = 6;
            // 
            // PanelMediaDisplay
            // 
            this.PanelMediaDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.PanelMediaDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMediaDisplay.Location = new System.Drawing.Point(3, 29);
            this.PanelMediaDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.PanelMediaDisplay.Media = null;
            this.PanelMediaDisplay.Name = "PanelMediaDisplay";
            this.PanelMediaDisplay.Size = new System.Drawing.Size(102, 436);
            this.PanelMediaDisplay.TabIndex = 5;
            this.PanelMediaDisplay.Visible = false;
            // 
            // PanelKeyword
            // 
            this.PanelKeyword.Controls.Add(this.TextBoxKeyword);
            this.PanelKeyword.Controls.Add(this.ButtonChangeKeyword);
            this.PanelKeyword.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelKeyword.Location = new System.Drawing.Point(3, 3);
            this.PanelKeyword.Name = "PanelKeyword";
            this.PanelKeyword.Padding = new System.Windows.Forms.Padding(3);
            this.PanelKeyword.Size = new System.Drawing.Size(598, 26);
            this.PanelKeyword.TabIndex = 7;
            // 
            // TextBoxKeyword
            // 
            this.TextBoxKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxKeyword.Location = new System.Drawing.Point(78, 3);
            this.TextBoxKeyword.Name = "TextBoxKeyword";
            this.TextBoxKeyword.Size = new System.Drawing.Size(517, 19);
            this.TextBoxKeyword.TabIndex = 0;
            // 
            // ButtonChangeKeyword
            // 
            this.ButtonChangeKeyword.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonChangeKeyword.Location = new System.Drawing.Point(3, 3);
            this.ButtonChangeKeyword.Name = "ButtonChangeKeyword";
            this.ButtonChangeKeyword.Size = new System.Drawing.Size(75, 20);
            this.ButtonChangeKeyword.TabIndex = 1;
            this.ButtonChangeKeyword.Text = "Change";
            this.ButtonChangeKeyword.UseVisualStyleBackColor = true;
            this.ButtonChangeKeyword.Click += new System.EventHandler(this.ButtonChangeKeyword_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 468);
            this.Controls.Add(this.PanelThreadView);
            this.Controls.Add(this.PanelMediaDisplay);
            this.Controls.Add(this.PanelKeyword);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.PanelKeyword.ResumeLayout(false);
            this.PanelKeyword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CtrlMediaDisplayPanel PanelMediaDisplay;
        private System.Windows.Forms.Panel PanelThreadView;
        private System.Windows.Forms.Panel PanelKeyword;
        private System.Windows.Forms.TextBox TextBoxKeyword;
        private System.Windows.Forms.Button ButtonChangeKeyword;
    }
}

