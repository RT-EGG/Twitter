namespace TwitterTimeLine
{
    partial class FormApplicaionKeysQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelAPIKey = new System.Windows.Forms.Label();
            this.LabelSecretKey = new System.Windows.Forms.Label();
            this.TextAPIKey = new System.Windows.Forms.TextBox();
            this.TextSecretKey = new System.Windows.Forms.TextBox();
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.ButtonAuthorize = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.PanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TextSecretKey, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelAPIKey, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelSecretKey, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextAPIKey, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 51);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LabelAPIKey
            // 
            this.LabelAPIKey.AutoSize = true;
            this.LabelAPIKey.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelAPIKey.Location = new System.Drawing.Point(40, 0);
            this.LabelAPIKey.Name = "LabelAPIKey";
            this.LabelAPIKey.Size = new System.Drawing.Size(52, 25);
            this.LabelAPIKey.TabIndex = 0;
            this.LabelAPIKey.Text = "API Key :";
            this.LabelAPIKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelSecretKey
            // 
            this.LabelSecretKey.AutoSize = true;
            this.LabelSecretKey.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelSecretKey.Location = new System.Drawing.Point(3, 25);
            this.LabelSecretKey.Name = "LabelSecretKey";
            this.LabelSecretKey.Size = new System.Drawing.Size(89, 26);
            this.LabelSecretKey.TabIndex = 1;
            this.LabelSecretKey.Text = "API Secret Key :";
            this.LabelSecretKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextAPIKey
            // 
            this.TextAPIKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextAPIKey.Location = new System.Drawing.Point(98, 3);
            this.TextAPIKey.Name = "TextAPIKey";
            this.TextAPIKey.Size = new System.Drawing.Size(230, 19);
            this.TextAPIKey.TabIndex = 2;
            // 
            // TextSecretKey
            // 
            this.TextSecretKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextSecretKey.Location = new System.Drawing.Point(98, 28);
            this.TextSecretKey.Name = "TextSecretKey";
            this.TextSecretKey.Size = new System.Drawing.Size(230, 19);
            this.TextSecretKey.TabIndex = 3;
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.ButtonAuthorize);
            this.PanelButtons.Controls.Add(this.ButtonCancel);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelButtons.Location = new System.Drawing.Point(0, 54);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Padding = new System.Windows.Forms.Padding(3);
            this.PanelButtons.Size = new System.Drawing.Size(331, 29);
            this.PanelButtons.TabIndex = 1;
            // 
            // ButtonAuthorize
            // 
            this.ButtonAuthorize.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonAuthorize.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonAuthorize.Location = new System.Drawing.Point(178, 3);
            this.ButtonAuthorize.Name = "ButtonAuthorize";
            this.ButtonAuthorize.Size = new System.Drawing.Size(75, 23);
            this.ButtonAuthorize.TabIndex = 0;
            this.ButtonAuthorize.Text = "Authorize";
            this.ButtonAuthorize.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonCancel.Location = new System.Drawing.Point(253, 3);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // FormApplicaionKeysQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 83);
            this.ControlBox = false;
            this.Controls.Add(this.PanelButtons);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormApplicaionKeysQuery";
            this.Text = "Application key authorization";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.PanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TextSecretKey;
        private System.Windows.Forms.Label LabelAPIKey;
        private System.Windows.Forms.Label LabelSecretKey;
        private System.Windows.Forms.TextBox TextAPIKey;
        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.Button ButtonAuthorize;
        private System.Windows.Forms.Button ButtonCancel;
    }
}