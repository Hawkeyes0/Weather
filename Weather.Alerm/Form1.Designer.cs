namespace Weather.Alerm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lTime = new System.Windows.Forms.Label();
            this.lTemp = new System.Windows.Forms.Label();
            this.lSd = new System.Windows.Forms.Label();
            this.lLimitNumber = new System.Windows.Forms.Label();
            this.lWind = new System.Windows.Forms.Label();
            this.lAqi = new System.Windows.Forms.Label();
            this.tState = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "灾害天气预警";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 360000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(337, 61);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lAqi);
            this.panel1.Controls.Add(this.lWind);
            this.panel1.Controls.Add(this.lLimitNumber);
            this.panel1.Controls.Add(this.lSd);
            this.panel1.Controls.Add(this.lTemp);
            this.panel1.Controls.Add(this.lTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 87);
            this.panel1.TabIndex = 1;
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(3, 3);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(43, 17);
            this.lTime.TabIndex = 0;
            this.lTime.Text = "label1";
            // 
            // lTemp
            // 
            this.lTemp.AutoSize = true;
            this.lTemp.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lTemp.Location = new System.Drawing.Point(170, 3);
            this.lTemp.Name = "lTemp";
            this.lTemp.Size = new System.Drawing.Size(92, 35);
            this.lTemp.TabIndex = 1;
            this.lTemp.Text = "label1";
            // 
            // lSd
            // 
            this.lSd.AutoSize = true;
            this.lSd.Location = new System.Drawing.Point(3, 45);
            this.lSd.Name = "lSd";
            this.lSd.Size = new System.Drawing.Size(43, 17);
            this.lSd.TabIndex = 2;
            this.lSd.Text = "label1";
            // 
            // lLimitNumber
            // 
            this.lLimitNumber.AutoSize = true;
            this.lLimitNumber.Location = new System.Drawing.Point(3, 64);
            this.lLimitNumber.Name = "lLimitNumber";
            this.lLimitNumber.Size = new System.Drawing.Size(43, 17);
            this.lLimitNumber.TabIndex = 3;
            this.lLimitNumber.Text = "label1";
            // 
            // lWind
            // 
            this.lWind.AutoSize = true;
            this.lWind.Location = new System.Drawing.Point(170, 45);
            this.lWind.Name = "lWind";
            this.lWind.Size = new System.Drawing.Size(43, 17);
            this.lWind.TabIndex = 4;
            this.lWind.Text = "label1";
            // 
            // lAqi
            // 
            this.lAqi.AutoSize = true;
            this.lAqi.Location = new System.Drawing.Point(170, 64);
            this.lAqi.Name = "lAqi";
            this.lAqi.Size = new System.Drawing.Size(43, 17);
            this.lAqi.TabIndex = 5;
            this.lAqi.Text = "label1";
            // 
            // tState
            // 
            this.tState.Tick += new System.EventHandler(this.tState_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 148);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "当前预警";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lAqi;
        private System.Windows.Forms.Label lWind;
        private System.Windows.Forms.Label lLimitNumber;
        private System.Windows.Forms.Label lSd;
        private System.Windows.Forms.Label lTemp;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Timer tState;
    }
}

