namespace 学生信息管理系统
{
    partial class pulishment
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
            this.btn_Pulishment_Insert = new System.Windows.Forms.Button();
            this.tet__Details = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cob_Name = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lal_Datetime = new System.Windows.Forms.Label();
            this.lal__ID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lal_StuNo = new System.Windows.Forms.Label();
            this.lal_StuName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Pulishment_Insert
            // 
            this.btn_Pulishment_Insert.Location = new System.Drawing.Point(424, 250);
            this.btn_Pulishment_Insert.Name = "btn_Pulishment_Insert";
            this.btn_Pulishment_Insert.Size = new System.Drawing.Size(75, 23);
            this.btn_Pulishment_Insert.TabIndex = 25;
            this.btn_Pulishment_Insert.Text = "添加";
            this.btn_Pulishment_Insert.UseVisualStyleBackColor = true;
            this.btn_Pulishment_Insert.Click += new System.EventHandler(this.btn_Pulishment_Insert_Click);
            // 
            // tet__Details
            // 
            this.tet__Details.Location = new System.Drawing.Point(334, 97);
            this.tet__Details.Multiline = true;
            this.tet__Details.Name = "tet__Details";
            this.tet__Details.Size = new System.Drawing.Size(165, 131);
            this.tet__Details.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(263, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "详细描述：";
            // 
            // cob_Name
            // 
            this.cob_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cob_Name.FormattingEnabled = true;
            this.cob_Name.Location = new System.Drawing.Point(334, 32);
            this.cob_Name.Name = "cob_Name";
            this.cob_Name.Size = new System.Drawing.Size(165, 20);
            this.cob_Name.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "选择类型：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "日期：";
            // 
            // lal_Datetime
            // 
            this.lal_Datetime.AutoSize = true;
            this.lal_Datetime.Location = new System.Drawing.Point(99, 216);
            this.lal_Datetime.Name = "lal_Datetime";
            this.lal_Datetime.Size = new System.Drawing.Size(41, 12);
            this.lal_Datetime.TabIndex = 19;
            this.lal_Datetime.Text = "label7";
            // 
            // lal__ID
            // 
            this.lal__ID.AutoSize = true;
            this.lal__ID.Location = new System.Drawing.Point(99, 156);
            this.lal__ID.Name = "lal__ID";
            this.lal__ID.Size = new System.Drawing.Size(41, 12);
            this.lal__ID.TabIndex = 18;
            this.lal__ID.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "编号：";
            // 
            // lal_StuNo
            // 
            this.lal_StuNo.AutoSize = true;
            this.lal_StuNo.Location = new System.Drawing.Point(99, 97);
            this.lal_StuNo.Name = "lal_StuNo";
            this.lal_StuNo.Size = new System.Drawing.Size(41, 12);
            this.lal_StuNo.TabIndex = 16;
            this.lal_StuNo.Text = "label4";
            // 
            // lal_StuName
            // 
            this.lal_StuName.AutoSize = true;
            this.lal_StuName.Location = new System.Drawing.Point(99, 32);
            this.lal_StuName.Name = "lal_StuName";
            this.lal_StuName.Size = new System.Drawing.Size(41, 12);
            this.lal_StuName.TabIndex = 15;
            this.lal_StuName.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "学号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "姓名：";
            // 
            // pulishment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 313);
            this.Controls.Add(this.btn_Pulishment_Insert);
            this.Controls.Add(this.tet__Details);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cob_Name);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lal_Datetime);
            this.Controls.Add(this.lal__ID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lal_StuNo);
            this.Controls.Add(this.lal_StuName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "pulishment";
            this.Text = "pulishment";
            this.Load += new System.EventHandler(this.pulishment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Pulishment_Insert;
        private System.Windows.Forms.TextBox tet__Details;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cob_Name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lal_Datetime;
        private System.Windows.Forms.Label lal__ID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lal_StuNo;
        private System.Windows.Forms.Label lal_StuName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}