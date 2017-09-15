namespace 学生信息管理系统
{
    partial class Student_Message
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.学生信息总览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.奖励申请ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.密码修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.学生信息总览ToolStripMenuItem,
            this.奖励申请ToolStripMenuItem,
            this.密码修改ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 学生信息总览ToolStripMenuItem
            // 
            this.学生信息总览ToolStripMenuItem.Name = "学生信息总览ToolStripMenuItem";
            this.学生信息总览ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.学生信息总览ToolStripMenuItem.Text = "信息总览";
            this.学生信息总览ToolStripMenuItem.Click += new System.EventHandler(this.学生信息总览ToolStripMenuItem_Click);
            // 
            // 奖励申请ToolStripMenuItem
            // 
            this.奖励申请ToolStripMenuItem.Name = "奖励申请ToolStripMenuItem";
            this.奖励申请ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.奖励申请ToolStripMenuItem.Text = "奖励申请";
            this.奖励申请ToolStripMenuItem.Click += new System.EventHandler(this.奖励申请ToolStripMenuItem_Click);
            // 
            // 密码修改ToolStripMenuItem
            // 
            this.密码修改ToolStripMenuItem.Name = "密码修改ToolStripMenuItem";
            this.密码修改ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.密码修改ToolStripMenuItem.Text = "密码修改";
            this.密码修改ToolStripMenuItem.Click += new System.EventHandler(this.密码修改ToolStripMenuItem_Click);
            // 
            // Student_Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 407);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Student_Message";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student_Message";
            this.Load += new System.EventHandler(this.Student_Message_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 学生信息总览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 奖励申请ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 密码修改ToolStripMenuItem;
    }
}