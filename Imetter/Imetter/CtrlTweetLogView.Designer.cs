namespace Imetter
{
    partial class CtrlTweetLogView
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
            this.components = new System.ComponentModel.Container();
            this.ButtonMovePrevious = new System.Windows.Forms.Button();
            this.ButtonMoveNext = new System.Windows.Forms.Button();
            this.PanelTweetViewStage = new System.Windows.Forms.Panel();
            this.CtrlTweetView1 = new Imetter.CtrlTweetView();
            this.CtrlTweetView2 = new Imetter.CtrlTweetView();
            this.TimerPanelAnimation = new System.Windows.Forms.Timer(this.components);
            this.PanelTweetViewStage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonMovePrevious
            // 
            this.ButtonMovePrevious.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonMovePrevious.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonMovePrevious.Font = new System.Drawing.Font("MS UI Gothic", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonMovePrevious.ForeColor = System.Drawing.Color.Gray;
            this.ButtonMovePrevious.Location = new System.Drawing.Point(0, 0);
            this.ButtonMovePrevious.Name = "ButtonMovePrevious";
            this.ButtonMovePrevious.Size = new System.Drawing.Size(48, 467);
            this.ButtonMovePrevious.TabIndex = 0;
            this.ButtonMovePrevious.Text = "<";
            this.ButtonMovePrevious.UseVisualStyleBackColor = false;
            this.ButtonMovePrevious.Click += new System.EventHandler(this.ButtonMovePrevious_Click);
            // 
            // ButtonMoveNext
            // 
            this.ButtonMoveNext.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonMoveNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonMoveNext.Font = new System.Drawing.Font("MS UI Gothic", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonMoveNext.ForeColor = System.Drawing.Color.Gray;
            this.ButtonMoveNext.Location = new System.Drawing.Point(538, 0);
            this.ButtonMoveNext.Name = "ButtonMoveNext";
            this.ButtonMoveNext.Size = new System.Drawing.Size(48, 467);
            this.ButtonMoveNext.TabIndex = 1;
            this.ButtonMoveNext.Text = ">";
            this.ButtonMoveNext.UseVisualStyleBackColor = false;
            this.ButtonMoveNext.Click += new System.EventHandler(this.ButtonMoveNext_Click);
            // 
            // PanelTweetViewStage
            // 
            this.PanelTweetViewStage.Controls.Add(this.CtrlTweetView2);
            this.PanelTweetViewStage.Controls.Add(this.CtrlTweetView1);
            this.PanelTweetViewStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTweetViewStage.Location = new System.Drawing.Point(48, 0);
            this.PanelTweetViewStage.Name = "PanelTweetViewStage";
            this.PanelTweetViewStage.Padding = new System.Windows.Forms.Padding(3);
            this.PanelTweetViewStage.Size = new System.Drawing.Size(490, 467);
            this.PanelTweetViewStage.TabIndex = 2;
            // 
            // CtrlTweetView1
            // 
            this.CtrlTweetView1.Location = new System.Drawing.Point(0, 0);
            this.CtrlTweetView1.Name = "CtrlTweetView1";
            this.CtrlTweetView1.Size = new System.Drawing.Size(490, 467);
            this.CtrlTweetView1.Status = null;
            this.CtrlTweetView1.TabIndex = 0;
            // 
            // CtrlTweetView2
            // 
            this.CtrlTweetView2.Location = new System.Drawing.Point(0, 0);
            this.CtrlTweetView2.Name = "CtrlTweetView2";
            this.CtrlTweetView2.Size = new System.Drawing.Size(490, 467);
            this.CtrlTweetView2.Status = null;
            this.CtrlTweetView2.TabIndex = 1;
            // 
            // TimerPanelAnimation
            // 
            this.TimerPanelAnimation.Interval = 10;
            this.TimerPanelAnimation.Tick += new System.EventHandler(this.TimerPanelAnimation_Tick);
            // 
            // CtrlTweetLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelTweetViewStage);
            this.Controls.Add(this.ButtonMoveNext);
            this.Controls.Add(this.ButtonMovePrevious);
            this.Name = "CtrlTweetLogView";
            this.Size = new System.Drawing.Size(586, 467);
            this.PanelTweetViewStage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonMovePrevious;
        private System.Windows.Forms.Button ButtonMoveNext;
        private System.Windows.Forms.Panel PanelTweetViewStage;
        private CtrlTweetView CtrlTweetView1;
        private CtrlTweetView CtrlTweetView2;
        private System.Windows.Forms.Timer TimerPanelAnimation;
    }
}
