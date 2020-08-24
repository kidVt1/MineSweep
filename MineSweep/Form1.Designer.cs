namespace MineSweep
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.设置 = new System.Windows.Forms.GroupBox();
            this.lbTimer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainContainer = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.设置.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 设置
            // 
            this.设置.Controls.Add(this.cmbLevel);
            this.设置.Controls.Add(this.label2);
            this.设置.Controls.Add(this.lbTimer);
            this.设置.Controls.Add(this.label1);
            this.设置.Controls.Add(this.btnRestart);
            this.设置.Dock = System.Windows.Forms.DockStyle.Top;
            this.设置.Location = new System.Drawing.Point(0, 0);
            this.设置.Name = "设置";
            this.设置.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.设置.Size = new System.Drawing.Size(851, 55);
            this.设置.TabIndex = 0;
            this.设置.TabStop = false;
            this.设置.Text = "设置";
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Location = new System.Drawing.Point(328, 17);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(11, 12);
            this.lbTimer.TabIndex = 2;
            this.lbTimer.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "计时：";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(176, 12);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "重新开始";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.mainContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 321);
            this.panel1.TabIndex = 0;
            // 
            // mainContainer
            // 
            this.mainContainer.AutoSize = true;
            this.mainContainer.Location = new System.Drawing.Point(3, 3);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(200, 100);
            this.mainContainer.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "难度";
            // 
            // cmbLevel
            // 
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Items.AddRange(new object[] {
            "初级",
            "中级",
            "高级",
            "极难",
            "地狱"});
            this.cmbLevel.Location = new System.Drawing.Point(49, 11);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(121, 20);
            this.cmbLevel.TabIndex = 4;
            this.cmbLevel.SelectedIndexChanged += new System.EventHandler(this.cmbLevel_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 376);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.设置);
            this.Name = "Form1";
            this.Text = "扫雷";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.设置.ResumeLayout(false);
            this.设置.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox 设置;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.Label label2;
    }
}

