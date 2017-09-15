using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserLoginDemo;

namespace 学生信息管理系统
{
    public partial class Student_Message : Form
    {
        public Student_Message()
        {
            InitializeComponent();
        }
        Stu_Message St_M = new Stu_Message();
        ResetPsd rp = new ResetPsd();
        Reward rd=null;
        public string No { get; set; }
        private void Student_Message_Load(object sender, EventArgs e)
        {
            this.Text = "您好！" + No;
            //No = "邹明";
            St_M.FormBorderStyle =FormBorderStyle.None;
            St_M.Show();
            St_M.MdiParent = this;
            ShowStudentMessga(No);

        }

        private void 学生信息总览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            St_M.Visible = true;
            rp.Visible = false;
            if(rd!=null)
            rd.Visible = false;

            St_M.tet_ChangeT.Text = string.Empty;
            St_M.tet_PulishT.Text = string.Empty;
            St_M.tet_RewardT.Text = string.Empty;
            St_M.FormBorderStyle = FormBorderStyle.None;
            St_M.Show();
            St_M.MdiParent = this;
            ShowStudentMessga(No);

        }

        private void 奖励申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取学生姓名
            DataTable dt = new DataTable();
            string sqlstr = "select StuName from dbo.Student where StuNo=@No;";
            SqlParameter[] parms = {
                new SqlParameter("@No",SqlDbType.NChar)
            };
            parms[0].Value = No;
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);

            //
            rd = new Reward(dt.Rows[0][0].ToString().Trim(), No);
            rd.Visible = true;
            St_M.Visible = false;
            rp.Visible = false;
            rd.Reward_Condition = 0;
            //rd.StuNo = No;
            //rd.StuName = dt.Rows[0][0].ToString().Trim();
            rd.MdiParent = this;
            rd.FormBorderStyle = FormBorderStyle.None;
            rd.Show();
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rp.Visible = true;
            St_M.Visible = false;
            if (rd != null)
                rd.Visible = false;
            rp.No = No;
            rp.FormBorderStyle = FormBorderStyle.None;
            rp.Show();
            rp.MdiParent = this;
        }

        public void ShowStudentMessga(string No)
        {
            DataTable dt = new DataTable();
            string sqlstr = "select * from dbo.Student where StuNo=@No;";
            SqlParameter[] parms = {
                new SqlParameter("@No",SqlDbType.NChar)
            };
            parms[0].Value = No;
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
            St_M.lal_StuNameT.Text = dt.Rows[0][1].ToString().Trim();
            St_M.lal_StuNoT.Text = dt.Rows[0][0].ToString().Trim();
            St_M.lal_SexT.Text = dt.Rows[0][3].ToString().Trim();
            St_M.lal_Native_PlaceT.Text = dt.Rows[0][6].ToString().Trim();
            St_M.lal_BirthdayT.Text = dt.Rows[0][5].ToString().Trim();
            string seacherStr_StuNo = No;
            //获取班级id
            dt = new DataTable();
            sqlstr = "select distinct ClassId from dbo.Student where StuNo=@StuNo; ";
            SqlParameter[] parms1 = {
                new SqlParameter("@StuNo",SqlDbType.NChar)
            };
            parms1[0].Value = seacherStr_StuNo;
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms1);
            DataRow dr = dt.Rows[0];
            string seacherStr_ClassId = dr["ClassId"].ToString();
            //获取班级，学院
            sqlstr = "select c.Class_Name,d.Department_Name from dbo.Classes as c join dbo.Department as d on c.Department_Id=d.Department_Id where c.Class_Id = @Class_Id";
            SqlParameter[] parms2 = {
                new SqlParameter("@Class_Id",SqlDbType.NChar)
            };
            parms2[0].Value = seacherStr_ClassId;
            dt.Clear();
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms2);
            St_M.lal_ClassT.Text = dt.Rows[0]["Class_Name"].ToString();
            St_M.lal_DeptT.Text = dt.Rows[0]["Department_Name"].ToString();
            //获取学籍变动信息
            sqlstr = "select Create_Date,Change_Descriptions from dbo.Change where StuNo=@StuNo;";
            dt.Clear();
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms1);
            if (dt.Rows.Count == 0)
                St_M.tet_ChangeT.Text = "无";
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    St_M.tet_ChangeT.Text += "创建日期：" + dt.Rows[i]["Create_Date"].ToString().Trim() + "\r\n";
                    St_M.tet_ChangeT.Text += "改动描述：" + dt.Rows[i]["Change_Descriptions"].ToString().Trim() + "\r\n" + "\r\n";
                }
            }
            
            //奖励，
            sqlstr = "select Create_Date,Reward_Descriptions,ReWard_Condition from dbo.Reward where StuNo=@StuNo ;";
            dt.Clear();
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms1);
            if (dt.Rows.Count == 0)
                St_M.tet_RewardT.Text = "无";
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((int)dt.Rows[i]["ReWard_Condition"] == 1)
                    {
                        St_M.tet_RewardT.Text += "创建日期：" + dt.Rows[i]["Create_Date"].ToString().Trim() + "\r\n";
                        St_M.tet_RewardT.Text += "奖励描述：" + dt.Rows[i]["Reward_Descriptions"].ToString().Trim() + "\r\n" + "\r\n";
                    }
                }
            }

            //惩罚，
            sqlstr = "select Create_Date, Punishment_Descriptions from dbo.Punishment where StuNo=@StuNo;";
            dt.Clear();
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms1);
            if (dt.Rows.Count == 0)
                St_M.tet_PulishT.Text = "无";
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    St_M.tet_PulishT.Text += "创建日期：" + dt.Rows[i]["Create_Date"].ToString().Trim() + "\r\n";
                    St_M.tet_PulishT.Text += "惩罚描述：" + dt.Rows[i]["Punishment_Descriptions"].ToString().Trim() + "\r\n" + "\r\n";
                }
            }
        }
    }
}
