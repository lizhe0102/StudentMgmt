namespace 学生信息管理系统
{
    partial class ResetPsd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tet_Psd = new System.Windows.Forms.TextBox();
            this.tet_Psd1 = new System.Windows.Forms.TextBox();
            this.btn_ResetPsd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请您再次确认您的密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入您即将改成的密码：";
            // 
            // tet_Psd
            // 
            this.tet_Psd.Location = new System.Drawing.Point(274, 129);
            this.tet_Psd.Name = "tet_Psd";
            this.tet_Psd.PasswordChar = '*';
            this.tet_Psd.Size = new System.Drawing.Size(209, 21);
            this.tet_Psd.TabIndex = 2;
            // 
            // tet_Psd1
            // 
            this.tet_Psd1.Location = new System.Drawing.Point(274, 194);
            this.tet_Psd1.Name = "tet_Psd1";
            this.tet_Psd1.PasswordChar = '*';
            this.tet_Psd1.Size = new System.Drawing.Size(209, 21);
            this.tet_Psd1.TabIndex = 3;
            // 
            // btn_ResetPsd
            // 
            this.btn_ResetPsd.Location = new System.Drawing.Point(274, 281);
            this.btn_ResetPsd.Name = "btn_ResetPsd";
            this.btn_ResetPsd.Size = new System.Drawing.Size(75, 23);
            this.btn_ResetPsd.TabIndex = 4;
            this.btn_ResetPsd.Text = "确认修改";
            this.btn_ResetPsd.UseVisualStyleBackColor = true;
            this.btn_ResetPsd.Click += new System.EventHandler(this.btn_ResetPsd_Click);
            // 
            // ResetPsd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 407);
            this.Controls.Add(this.btn_ResetPsd);
            this.Controls.Add(this.tet_Psd1);
            this.Controls.Add(this.tet_Psd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ResetPsd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetPsd";
            this.Load += new System.EventHandler(this.ResetPsd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tet_Psd;
        private System.Windows.Forms.TextBox tet_Psd1;
        private System.Windows.Forms.Button btn_ResetPsd;
    }
}