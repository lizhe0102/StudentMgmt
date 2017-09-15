namespace 学生信息管理系统
{
    partial class change
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
            this.btn_Insert = new System.Windows.Forms.Button();
            this.tet_Details = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cob_Name = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lal_Datetime = new System.Windows.Forms.Label();
            this.lal_ID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lal_StuNo = new System.Windows.Forms.Label();
            this.lal_StuName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.group_change = new System.Windows.Forms.GroupBox();
            this.cob_Class = new System.Windows.Forms.ComboBox();
            this.cob_Dept = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.group_change.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Insert
            // 
            this.btn_Insert.Location = new System.Drawing.Point(435, 300);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(75, 23);
            this.btn_Insert.TabIndex = 25;
            this.btn_Insert.Text = "添加";
            this.btn_Insert.UseVisualStyleBackColor = true;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // tet_Details
            // 
            this.tet_Details.Location = new System.Drawing.Point(345, 163);
            this.tet_Details.Multiline = true;
            this.tet_Details.Name = "tet_Details";
            this.tet_Details.Size = new System.Drawing.Size(165, 131);
            this.tet_Details.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(274, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "详细描述：";
            // 
            // cob_Name
            // 
            this.cob_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Name.FormattingEnabled = true;
            this.cob_Name.Location = new System.Drawing.Point(345, 42);
            this.cob_Name.Name = "cob_Name";
            this.cob_Name.Size = new System.Drawing.Size(165, 20);
            this.cob_Name.TabIndex = 22;
            this.cob_Name.SelectedIndexChanged += new System.EventHandler(this.cob_Name_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(274, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "选择类型：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "日期：";
            // 
            // lal_Datetime
            // 
            this.lal_Datetime.AutoSize = true;
            this.lal_Datetime.Location = new System.Drawing.Point(110, 266);
            this.lal_Datetime.Name = "lal_Datetime";
            this.lal_Datetime.Size = new System.Drawing.Size(41, 12);
            this.lal_Datetime.TabIndex = 19;
            this.lal_Datetime.Text = "label7";
            // 
            // lal_ID
            // 
            this.lal_ID.AutoSize = true;
            this.lal_ID.Location = new System.Drawing.Point(110, 195);
            this.lal_ID.Name = "lal_ID";
            this.lal_ID.Size = new System.Drawing.Size(41, 12);
            this.lal_ID.TabIndex = 18;
            this.lal_ID.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "编号：";
            // 
            // lal_StuNo
            // 
            this.lal_StuNo.AutoSize = true;
            this.lal_StuNo.Location = new System.Drawing.Point(110, 122);
            this.lal_StuNo.Name = "lal_StuNo";
            this.lal_StuNo.Size = new System.Drawing.Size(41, 12);
            this.lal_StuNo.TabIndex = 16;
            this.lal_StuNo.Text = "label4";
            // 
            // lal_StuName
            // 
            this.lal_StuName.AutoSize = true;
            this.lal_StuName.Location = new System.Drawing.Point(110, 50);
            this.lal_StuName.Name = "lal_StuName";
            this.lal_StuName.Size = new System.Drawing.Size(41, 12);
            this.lal_StuName.TabIndex = 15;
            this.lal_StuName.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "学号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "姓名：";
            // 
            // group_change
            // 
            this.group_change.Controls.Add(this.cob_Class);
            this.group_change.Controls.Add(this.cob_Dept);
            this.group_change.Controls.Add(this.label4);
            this.group_change.Controls.Add(this.label3);
            this.group_change.Location = new System.Drawing.Point(276, 68);
            this.group_change.Name = "group_change";
            this.group_change.Size = new System.Drawing.Size(289, 89);
            this.group_change.TabIndex = 26;
            this.group_change.TabStop = false;
            // 
            // cob_Class
            // 
            this.cob_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Class.FormattingEnabled = true;
            this.cob_Class.Location = new System.Drawing.Point(63, 54);
            this.cob_Class.Name = "cob_Class";
            this.cob_Class.Size = new System.Drawing.Size(165, 20);
            this.cob_Class.TabIndex = 30;
            this.cob_Class.SelectedIndexChanged += new System.EventHandler(this.cob_Class_SelectedIndexChanged);
            // 
            // cob_Dept
            // 
            this.cob_Dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Dept.FormattingEnabled = true;
            this.cob_Dept.Location = new System.Drawing.Point(63, 17);
            this.cob_Dept.Name = "cob_Dept";
            this.cob_Dept.Size = new System.Drawing.Size(165, 20);
            this.cob_Dept.TabIndex = 29;
            this.cob_Dept.SelectedIndexChanged += new System.EventHandler(this.cob_Dept_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "选择班级：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "选择院系：";
            // 
            // change
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 354);
            this.Controls.Add(this.group_change);
            this.Controls.Add(this.btn_Insert);
            this.Controls.Add(this.tet_Details);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cob_Name);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lal_Datetime);
            this.Controls.Add(this.lal_ID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lal_StuNo);
            this.Controls.Add(this.lal_StuName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "change";
            this.Text = "change";
            this.Load += new System.EventHandler(this.change_Load);
            this.group_change.ResumeLayout(false);
            this.group_change.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Insert;
        private System.Windows.Forms.TextBox tet_Details;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cob_Name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lal_Datetime;
        private System.Windows.Forms.Label lal_ID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lal_StuNo;
        private System.Windows.Forms.Label lal_StuName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox group_change;
        private System.Windows.Forms.ComboBox cob_Class;
        private System.Windows.Forms.ComboBox cob_Dept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}