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
            this.PanelThreadView = new System.Windows.Forms.Panel();
            this.PanelKeyword = new System.Windows.Forms.Panel();
            this.TextBoxKeyword = new System.Windows.Forms.TextBox();
            this.ButtonChangeKeyword = new System.Windows.Forms.Button();
            this.PanelActionsForTweet = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonFav = new System.Windows.Forms.Button();
            this.PanelSaveImage = new System.Windows.Forms.Panel();
            this.PanelSaveImageButton = new System.Windows.Forms.Panel();
            this.ButtonSaveImage = new System.Windows.Forms.Button();
            this.ComboSaveImageDirectories = new System.Windows.Forms.ComboBox();
            this.ButtonRT = new System.Windows.Forms.Button();
            this.TimerActionButtonUpdate = new System.Windows.Forms.Timer(this.components);
            this.PanelMediaDisplay = new Imetter.CtrlMediaDisplayPanel();
            this.PanelKeyword.SuspendLayout();
            this.PanelActionsForTweet.SuspendLayout();
            this.PanelSaveImage.SuspendLayout();
            this.PanelSaveImageButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelThreadView
            // 
            this.PanelThreadView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelThreadView.Location = new System.Drawing.Point(3, 29);
            this.PanelThreadView.Margin = new System.Windows.Forms.Padding(2);
            this.PanelThreadView.Name = "PanelThreadView";
            this.PanelThreadView.Size = new System.Drawing.Size(964, 443);
            this.PanelThreadView.TabIndex = 6;
            // 
            // PanelKeyword
            // 
            this.PanelKeyword.Controls.Add(this.TextBoxKeyword);
            this.PanelKeyword.Controls.Add(this.ButtonChangeKeyword);
            this.PanelKeyword.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelKeyword.Location = new System.Drawing.Point(3, 3);
            this.PanelKeyword.Name = "PanelKeyword";
            this.PanelKeyword.Padding = new System.Windows.Forms.Padding(3);
            this.PanelKeyword.Size = new System.Drawing.Size(964, 26);
            this.PanelKeyword.TabIndex = 7;
            // 
            // TextBoxKeyword
            // 
            this.TextBoxKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxKeyword.Location = new System.Drawing.Point(78, 3);
            this.TextBoxKeyword.Name = "TextBoxKeyword";
            this.TextBoxKeyword.Size = new System.Drawing.Size(883, 19);
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
            // PanelActionsForTweet
            // 
            this.PanelActionsForTweet.ColumnCount = 3;
            this.PanelActionsForTweet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelActionsForTweet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.PanelActionsForTweet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.PanelActionsForTweet.Controls.Add(this.ButtonFav, 2, 0);
            this.PanelActionsForTweet.Controls.Add(this.PanelSaveImage, 0, 0);
            this.PanelActionsForTweet.Controls.Add(this.ButtonRT, 1, 0);
            this.PanelActionsForTweet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelActionsForTweet.Location = new System.Drawing.Point(3, 472);
            this.PanelActionsForTweet.Name = "PanelActionsForTweet";
            this.PanelActionsForTweet.RowCount = 1;
            this.PanelActionsForTweet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PanelActionsForTweet.Size = new System.Drawing.Size(964, 59);
            this.PanelActionsForTweet.TabIndex = 0;
            // 
            // ButtonFav
            // 
            this.ButtonFav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonFav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFav.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonFav.Location = new System.Drawing.Point(867, 3);
            this.ButtonFav.Name = "ButtonFav";
            this.ButtonFav.Size = new System.Drawing.Size(94, 53);
            this.ButtonFav.TabIndex = 2;
            this.ButtonFav.Text = "Fav";
            this.ButtonFav.UseVisualStyleBackColor = true;
            this.ButtonFav.Click += new System.EventHandler(this.ButtonFav_Click);
            // 
            // PanelSaveImage
            // 
            this.PanelSaveImage.Controls.Add(this.PanelSaveImageButton);
            this.PanelSaveImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSaveImage.Location = new System.Drawing.Point(3, 3);
            this.PanelSaveImage.Name = "PanelSaveImage";
            this.PanelSaveImage.Padding = new System.Windows.Forms.Padding(3);
            this.PanelSaveImage.Size = new System.Drawing.Size(758, 53);
            this.PanelSaveImage.TabIndex = 0;
            // 
            // PanelSaveImageButton
            // 
            this.PanelSaveImageButton.Controls.Add(this.ButtonSaveImage);
            this.PanelSaveImageButton.Controls.Add(this.ComboSaveImageDirectories);
            this.PanelSaveImageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSaveImageButton.Location = new System.Drawing.Point(3, 3);
            this.PanelSaveImageButton.Name = "PanelSaveImageButton";
            this.PanelSaveImageButton.Size = new System.Drawing.Size(752, 47);
            this.PanelSaveImageButton.TabIndex = 2;
            // 
            // ButtonSaveImage
            // 
            this.ButtonSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSaveImage.Location = new System.Drawing.Point(0, 0);
            this.ButtonSaveImage.Name = "ButtonSaveImage";
            this.ButtonSaveImage.Size = new System.Drawing.Size(734, 20);
            this.ButtonSaveImage.TabIndex = 2;
            this.ButtonSaveImage.Text = "---";
            this.ButtonSaveImage.UseVisualStyleBackColor = true;
            // 
            // ComboSaveImageDirectories
            // 
            this.ComboSaveImageDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboSaveImageDirectories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSaveImageDirectories.FormattingEnabled = true;
            this.ComboSaveImageDirectories.ItemHeight = 12;
            this.ComboSaveImageDirectories.Location = new System.Drawing.Point(0, 0);
            this.ComboSaveImageDirectories.Name = "ComboSaveImageDirectories";
            this.ComboSaveImageDirectories.Size = new System.Drawing.Size(752, 20);
            this.ComboSaveImageDirectories.TabIndex = 1;
            // 
            // ButtonRT
            // 
            this.ButtonRT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonRT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRT.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonRT.Location = new System.Drawing.Point(767, 3);
            this.ButtonRT.Name = "ButtonRT";
            this.ButtonRT.Size = new System.Drawing.Size(94, 53);
            this.ButtonRT.TabIndex = 1;
            this.ButtonRT.Text = "RT";
            this.ButtonRT.UseVisualStyleBackColor = true;
            this.ButtonRT.Click += new System.EventHandler(this.ButtonRT_Click);
            // 
            // TimerActionButtonUpdate
            // 
            this.TimerActionButtonUpdate.Enabled = true;
            this.TimerActionButtonUpdate.Interval = 3000;
            // 
            // PanelMediaDisplay
            // 
            this.PanelMediaDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.PanelMediaDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMediaDisplay.Location = new System.Drawing.Point(3, 29);
            this.PanelMediaDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.PanelMediaDisplay.Media = null;
            this.PanelMediaDisplay.Name = "PanelMediaDisplay";
            this.PanelMediaDisplay.Size = new System.Drawing.Size(964, 443);
            this.PanelMediaDisplay.TabIndex = 5;
            this.PanelMediaDisplay.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 534);
            this.Controls.Add(this.PanelThreadView);
            this.Controls.Add(this.PanelMediaDisplay);
            this.Controls.Add(this.PanelActionsForTweet);
            this.Controls.Add(this.PanelKeyword);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.PanelKeyword.ResumeLayout(false);
            this.PanelKeyword.PerformLayout();
            this.PanelActionsForTweet.ResumeLayout(false);
            this.PanelSaveImage.ResumeLayout(false);
            this.PanelSaveImageButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CtrlMediaDisplayPanel PanelMediaDisplay;
        private System.Windows.Forms.Panel PanelThreadView;
        private System.Windows.Forms.Panel PanelKeyword;
        private System.Windows.Forms.TextBox TextBoxKeyword;
        private System.Windows.Forms.Button ButtonChangeKeyword;
        private System.Windows.Forms.TableLayoutPanel PanelActionsForTweet;
        private System.Windows.Forms.Button ButtonFav;
        private System.Windows.Forms.Panel PanelSaveImage;
        private System.Windows.Forms.Panel PanelSaveImageButton;
        private System.Windows.Forms.Button ButtonSaveImage;
        private System.Windows.Forms.ComboBox ComboSaveImageDirectories;
        private System.Windows.Forms.Button ButtonRT;
        private System.Windows.Forms.Timer TimerActionButtonUpdate;
    }
}

