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
            this.PanelTweetSlideView = new System.Windows.Forms.Panel();
            this.CtrlTweetView1 = new Imetter.CtrlTweetView();
            this.TimerPanelAnimation = new System.Windows.Forms.Timer(this.components);
            this.LabelLogIndex = new System.Windows.Forms.Label();
            this.PanelTweetViewStage.SuspendLayout();
            this.PanelTweetSlideView.SuspendLayout();
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
            this.PanelTweetViewStage.Controls.Add(this.PanelTweetSlideView);
            this.PanelTweetViewStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTweetViewStage.Location = new System.Drawing.Point(48, 20);
            this.PanelTweetViewStage.Name = "PanelTweetViewStage";
            this.PanelTweetViewStage.Padding = new System.Windows.Forms.Padding(3);
            this.PanelTweetViewStage.Size = new System.Drawing.Size(490, 447);
            this.PanelTweetViewStage.TabIndex = 2;
            // 
            // PanelTweetSlideView
            // 
            this.PanelTweetSlideView.Controls.Add(this.CtrlTweetView1);
            this.PanelTweetSlideView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTweetSlideView.Location = new System.Drawing.Point(3, 3);
            this.PanelTweetSlideView.Name = "PanelTweetSlideView";
            this.PanelTweetSlideView.Size = new System.Drawing.Size(484, 441);
            this.PanelTweetSlideView.TabIndex = 2;
            // 
            // CtrlTweetView1
            // 
            this.CtrlTweetView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CtrlTweetView1.Location = new System.Drawing.Point(0, 0);
            this.CtrlTweetView1.Margin = new System.Windows.Forms.Padding(4);
            this.CtrlTweetView1.Name = "CtrlTweetView1";
            this.CtrlTweetView1.Size = new System.Drawing.Size(484, 441);
            this.CtrlTweetView1.Status = null;
            this.CtrlTweetView1.TabIndex = 0;
            this.CtrlTweetView1.OnMouseClickTweetMedia += new Imetter.MediaMouseClickEvent(this.CtrlTweetView1_OnMouseClickTweetMedia);
            // 
            // TimerPanelAnimation
            // 
            this.TimerPanelAnimation.Interval = 10;
            this.TimerPanelAnimation.Tick += new System.EventHandler(this.TimerPanelAnimation_Tick);
            // 
            // LabelLogIndex
            // 
            this.LabelLogIndex.AutoSize = true;
            this.LabelLogIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelLogIndex.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LabelLogIndex.Location = new System.Drawing.Point(48, 0);
            this.LabelLogIndex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLogIndex.Name = "LabelLogIndex";
            this.LabelLogIndex.Padding = new System.Windows.Forms.Padding(2);
            this.LabelLogIndex.Size = new System.Drawing.Size(62, 20);
            this.LabelLogIndex.TabIndex = 3;
            this.LabelLogIndex.Text = "-- / --";
            // 
            // CtrlTweetLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelTweetViewStage);
            this.Controls.Add(this.LabelLogIndex);
            this.Controls.Add(this.ButtonMoveNext);
            this.Controls.Add(this.ButtonMovePrevious);
            this.Name = "CtrlTweetLogView";
            this.Size = new System.Drawing.Size(586, 467);
            this.PanelTweetViewStage.ResumeLayout(false);
            this.PanelTweetSlideView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonMovePrevious;
        private System.Windows.Forms.Button ButtonMoveNext;
        private System.Windows.Forms.Panel PanelTweetViewStage;
        private CtrlTweetView CtrlTweetView1;
        private System.Windows.Forms.Timer TimerPanelAnimation;
        private System.Windows.Forms.Panel PanelTweetSlideView;
        private System.Windows.Forms.Label LabelLogIndex;
    }
}
