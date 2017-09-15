namespace 学生信息管理系统
{
    partial class GetPsd
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
            this.btn_GetPsd = new System.Windows.Forms.Button();
            this.tet_Name = new System.Windows.Forms.TextBox();
            this.tet_Psd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入姓名：";
            // 
            // btn_GetPsd
            // 
            this.btn_GetPsd.Location = new System.Drawing.Point(202, 154);
            this.btn_GetPsd.Name = "btn_GetPsd";
            this.btn_GetPsd.Size = new System.Drawing.Size(75, 23);
            this.btn_GetPsd.TabIndex = 1;
            this.btn_GetPsd.Text = "获取密码";
            this.btn_GetPsd.UseVisualStyleBackColor = true;
            this.btn_GetPsd.Click += new System.EventHandler(this.btn_GetPsd_Click);
            // 
            // tet_Name
            // 
            this.tet_Name.Location = new System.Drawing.Point(202, 64);
            this.tet_Name.Name = "tet_Name";
            this.tet_Name.Size = new System.Drawing.Size(152, 21);
            this.tet_Name.TabIndex = 2;
            // 
            // tet_Psd
            // 
            this.tet_Psd.Location = new System.Drawing.Point(120, 114);
            this.tet_Psd.Name = "tet_Psd";
            this.tet_Psd.ReadOnly = true;
            this.tet_Psd.Size = new System.Drawing.Size(234, 21);
            this.tet_Psd.TabIndex = 3;
            // 
            // GetPsd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 247);
            this.Controls.Add(this.tet_Psd);
            this.Controls.Add(this.tet_Name);
            this.Controls.Add(this.btn_GetPsd);
            this.Controls.Add(this.label1);
            this.Name = "GetPsd";
            this.Text = "GetPsd";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GetPsd_FormClosed);
            this.Load += new System.EventHandler(this.GetPsd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_GetPsd;
        private System.Windows.Forms.TextBox tet_Name;
        private System.Windows.Forms.TextBox tet_Psd;
    }
}