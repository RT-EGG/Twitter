namespace Imetter
{
    partial class FormUserPincodeQuery
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
            this.TextPincode = new System.Windows.Forms.TextBox();
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.ButtonAuthorize = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.LabelReaccess = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.PanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LabelAPIKey, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextPincode, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(496, 27);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // LabelAPIKey
            // 
            this.LabelAPIKey.AutoSize = true;
            this.LabelAPIKey.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelAPIKey.Location = new System.Drawing.Point(3, 0);
            this.LabelAPIKey.Name = "LabelAPIKey";
            this.LabelAPIKey.Size = new System.Drawing.Size(51, 27);
            this.LabelAPIKey.TabIndex = 0;
            this.LabelAPIKey.Text = "Pincode :";
            this.LabelAPIKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextPincode
            // 
            this.TextPincode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextPincode.Location = new System.Drawing.Point(60, 3);
            this.TextPincode.Name = "TextPincode";
            this.TextPincode.Size = new System.Drawing.Size(433, 19);
            this.TextPincode.TabIndex = 2;
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.ButtonAuthorize);
            this.PanelButtons.Controls.Add(this.ButtonCancel);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelButtons.Location = new System.Drawing.Point(0, 46);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Padding = new System.Windows.Forms.Padding(3);
            this.PanelButtons.Size = new System.Drawing.Size(496, 29);
            this.PanelButtons.TabIndex = 3;
            // 
            // ButtonAuthorize
            // 
            this.ButtonAuthorize.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonAuthorize.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonAuthorize.Location = new System.Drawing.Point(343, 3);
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
            this.ButtonCancel.Location = new System.Drawing.Point(418, 3);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // LabelReaccess
            // 
            this.LabelReaccess.AutoSize = true;
            this.LabelReaccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelReaccess.Location = new System.Drawing.Point(0, 0);
            this.LabelReaccess.Name = "LabelReaccess";
            this.LabelReaccess.Padding = new System.Windows.Forms.Padding(3);
            this.LabelReaccess.Size = new System.Drawing.Size(125, 18);
            this.LabelReaccess.TabIndex = 4;
            this.LabelReaccess.TabStop = true;
            this.LabelReaccess.Text = "Reaccess to authorize";
            this.LabelReaccess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelReaccess_LinkClicked);
            // 
            // FormUserPincodeQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 75);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.LabelReaccess);
            this.Controls.Add(this.PanelButtons);
            this.Name = "FormUserPincodeQuery";
            this.Text = "FormUserPincodeQuery";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.PanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelAPIKey;
        private System.Windows.Forms.TextBox TextPincode;
        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.Button ButtonAuthorize;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.LinkLabel LabelReaccess;
    }
}