namespace 学生信息管理系统
{
    partial class Login
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
            this.label3 = new System.Windows.Forms.Label();
            this.cob_Type = new System.Windows.Forms.ComboBox();
            this.tet_No = new System.Windows.Forms.TextBox();
            this.tet_Psd = new System.Windows.Forms.TextBox();
            this.lal_ErrorMessage = new System.Windows.Forms.Label();
            this.lal_GetPsd = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "账号：";
            // 
            // cob_Type
            // 
            this.cob_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Type.FormattingEnabled = true;
            this.cob_Type.Location = new System.Drawing.Point(152, 75);
            this.cob_Type.Name = "cob_Type";
            this.cob_Type.Size = new System.Drawing.Size(107, 20);
            this.cob_Type.TabIndex = 3;
            // 
            // tet_No
            // 
            this.tet_No.Location = new System.Drawing.Point(152, 139);
            this.tet_No.Name = "tet_No";
            this.tet_No.Size = new System.Drawing.Size(172, 21);
            this.tet_No.TabIndex = 4;
            // 
            // tet_Psd
            // 
            this.tet_Psd.Location = new System.Drawing.Point(152, 177);
            this.tet_Psd.Name = "tet_Psd";
            this.tet_Psd.PasswordChar = '*';
            this.tet_Psd.Size = new System.Drawing.Size(172, 21);
            this.tet_Psd.TabIndex = 5;
            // 
            // lal_ErrorMessage
            // 
            this.lal_ErrorMessage.AutoSize = true;
            this.lal_ErrorMessage.Location = new System.Drawing.Point(150, 112);
            this.lal_ErrorMessage.Name = "lal_ErrorMessage";
            this.lal_ErrorMessage.Size = new System.Drawing.Size(41, 12);
            this.lal_ErrorMessage.TabIndex = 6;
            this.lal_ErrorMessage.Text = "label4";
            // 
            // lal_GetPsd
            // 
            this.lal_GetPsd.AutoSize = true;
            this.lal_GetPsd.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lal_GetPsd.Location = new System.Drawing.Point(330, 180);
            this.lal_GetPsd.Name = "lal_GetPsd";
            this.lal_GetPsd.Size = new System.Drawing.Size(77, 12);
            this.lal_GetPsd.TabIndex = 7;
            this.lal_GetPsd.Text = "点我找回密码";
            this.lal_GetPsd.Click += new System.EventHandler(this.lal_GetPsd_Click);
            this.lal_GetPsd.MouseLeave += new System.EventHandler(this.lal_GetPsd_MouseLeave);
            this.lal_GetPsd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lal_GetPsd_MouseMove);
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(152, 220);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 8;
            this.btn_Login.Text = "登陆";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 332);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.lal_GetPsd);
            this.Controls.Add(this.lal_ErrorMessage);
            this.Controls.Add(this.tet_Psd);
            this.Controls.Add(this.tet_No);
            this.Controls.Add(this.cob_Type);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cob_Type;
        private System.Windows.Forms.TextBox tet_No;
        private System.Windows.Forms.TextBox tet_Psd;
        private System.Windows.Forms.Label lal_ErrorMessage;
        private System.Windows.Forms.Label lal_GetPsd;
        private System.Windows.Forms.Button btn_Login;
    }
}