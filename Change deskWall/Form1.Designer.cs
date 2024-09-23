
namespace Change_deskWall
{
    partial class Form1
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
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnChange = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDelTxt = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.txt2 = new System.Windows.Forms.TextBox();
            this.changeTimer = new System.Windows.Forms.CheckBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.change = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.putInTray = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(23, 123);
            this.btnChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(88, 56);
            this.btnChange.TabIndex = 0;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 52);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 42);
            this.textBox1.TabIndex = 1;
            // 
            // btnDelTxt
            // 
            this.btnDelTxt.Location = new System.Drawing.Point(139, 123);
            this.btnDelTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelTxt.Name = "btnDelTxt";
            this.btnDelTxt.Size = new System.Drawing.Size(88, 56);
            this.btnDelTxt.TabIndex = 2;
            this.btnDelTxt.Text = "Delete";
            this.btnDelTxt.UseVisualStyleBackColor = true;
            this.btnDelTxt.Click += new System.EventHandler(this.BtnDelTxt_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(177, 11);
            this.btnSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(49, 37);
            this.btnSet.TabIndex = 3;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(23, 11);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 37);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.BtnChange_Click);
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(32, 99);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(70, 20);
            this.txt2.TabIndex = 6;
            this.txt2.Text = "1";
            this.txt2.TextChanged += new System.EventHandler(this.Txt2_TextChanged);
            // 
            // changeTimer
            // 
            this.changeTimer.AutoSize = true;
            this.changeTimer.Location = new System.Drawing.Point(155, 102);
            this.changeTimer.Name = "changeTimer";
            this.changeTimer.Size = new System.Drawing.Size(52, 17);
            this.changeTimer.TabIndex = 7;
            this.changeTimer.Text = "Timer";
            this.changeTimer.UseVisualStyleBackColor = true;
            this.changeTimer.CheckedChanged += new System.EventHandler(this.ChangeTimer_CheckedChanged);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "text";
            this.notifyIcon.BalloonTipTitle = "titty";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Change Wallpaper";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.change,
            this.deleteToolStripMenuItem,
            this.exit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(91, 70);
            // 
            // change
            // 
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(90, 22);
            this.change.Text = "Change";
            this.change.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.BtnDelTxt_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(90, 22);
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.Exit);
            // 
            // putInTray
            // 
            this.putInTray.AutoSize = true;
            this.putInTray.Checked = true;
            this.putInTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.putInTray.Location = new System.Drawing.Point(121, 22);
            this.putInTray.Name = "putInTray";
            this.putInTray.Size = new System.Drawing.Size(47, 17);
            this.putInTray.TabIndex = 8;
            this.putInTray.Text = "Tray";
            this.putInTray.UseVisualStyleBackColor = true;
            this.putInTray.CheckedChanged += new System.EventHandler(this.PutInTray_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 206);
            this.Controls.Add(this.putInTray);
            this.Controls.Add(this.changeTimer);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnDelTxt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Wallpaper V2.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDelTxt;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.CheckBox changeTimer;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox putInTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem change;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

