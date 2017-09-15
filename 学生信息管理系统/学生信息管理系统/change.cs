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
    public partial class change : Form
    {
        public change()
        {
            InitializeComponent();
        }
        DataTable dt_Dept = new DataTable();
        DataTable dt_Class = null;
        DataTable dt_Change = null;
        public string StuName { get; set; }
        public string StuNo { get; set; }
        private void change_Load(object sender, EventArgs e)
        {
            //group_change.Visible = false;
            //
            dt_Change = new DataTable();
            DataTable dt = new DataTable();
            string sqlstr = null;
            string Value = null;
            //
            sqlstr = "select Change_Code,Change_Descriptions from dbo.Change_Config;";
            GetStudentMessage(sqlstr, Value, out dt_Change);
            if (dt_Change.Rows.Count > 0)
            {
                for (int i = 0; i < dt_Change.Rows.Count; i++)
                {
                    cob_Name.Items.Add(dt_Change.Rows[i]["Change_Descriptions"].ToString());
                }
            }
            cob_Name.SelectedIndex = 0;
            //
            sqlstr = "select max(CONVERT(bigint,Change_Id)) Change_Id  from dbo.Change";
            Value = null;
            GetStudentMessage(sqlstr, Value, out dt);
            long Index;
            if (dt.Rows.Count == 0) Index = -1;
            else Index = (long)dt.Rows[0]["Change_Id"];
            string Max_ID = (Index + 1).ToString("00000000");
            lal_ID.Text = Max_ID;
            lal_StuName.Text = StuName;
            lal_StuNo.Text = StuNo;
            lal_Datetime.Text = DateTime.Now.ToShortDateString();
            //
            string Sqlstr_cob_Dept = "select * from dbo.Department;";
            SqlHelper.RunSQLReturnDataTable(Sqlstr_cob_Dept, out dt_Dept);
            for (int i = 0; i < dt_Dept.Rows.Count; i++)
            {
                cob_Dept.Items.Add(dt_Dept.Rows[i]["Department_Name"]);
            }
            cob_Dept.SelectedIndex = 0;
            //
        }

        private void cob_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cob_Name.SelectedItem.ToString().Trim().Equals("转系"))
            {
                group_change.Visible = true;
            }
            else
            {
                tet_Details.Text = string.Empty;
                group_change.Visible = false;
            }
        }


        public void GetStudentMessage(string sqlstr, string Value, out DataTable dt)
        {
            if (Value != null)
            {
                SqlParameter[] parms ={
                 new SqlParameter("@Value",SqlDbType.NChar)
                };
                parms[0].Value = Value;
                SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
            }
            else
            {
                SqlHelper.RunSQLReturnDataTable(sqlstr, out dt);
            }

        }

        private void cob_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Value = null;
            int index = cob_Dept.SelectedIndex;
            Value = dt_Dept.Rows[index]["Department_Id"].ToString().Trim();
            dt_Class = new DataTable();
            string sqlstr = "select Class_Name,Class_Id from dbo.Classes where Department_Id=@Value;";
            GetStudentMessage(sqlstr,Value, out dt_Class);
            cob_Class.Items.Clear();
            if (dt_Class.Rows.Count > 0)
            {
                for (int i = 0; i < dt_Class.Rows.Count; i++)
                {
                    cob_Class.Items.Add(dt_Class.Rows[i]["Class_Name"]);
                }
            }
            cob_Class.SelectedIndex = 0;
        }

        private void cob_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            tet_Details.Text = "于"+DateTime.Now.ToShortDateString()+"转入" + cob_Dept.SelectedItem.ToString().Trim() + cob_Class.SelectedItem.ToString().Trim();
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            string sqlstr = null;
            sqlstr = "insert into dbo.Change values(@Change_Id,@StuNo,@Change_Code,@Create_Date,@Change_Descriptions);";
            SqlParameter[] parms =
            {
                new SqlParameter("@Change_Id",SqlDbType.NChar),
                new SqlParameter("@StuNo",SqlDbType.NChar),
                new SqlParameter("@Change_Code",SqlDbType.NChar),
                new SqlParameter("@Create_Date",SqlDbType.SmallDateTime),
                new SqlParameter("@Change_Descriptions",SqlDbType.NChar)
            };
            int index = cob_Name.SelectedIndex;
            parms[0].Value = lal_ID.Text;
            parms[1].Value = lal_StuNo.Text;
            parms[2].Value = dt_Change.Rows[index]["Change_Code"];
            parms[3].Value = Convert.ToDateTime(lal_Datetime.Text);
            parms[4].Value = tet_Details.Text;
            SqlHelper.RunSQL(sqlstr, parms);
            //
            if (cob_Name.SelectedItem.ToString().Trim().Equals("转系"))
            {
                index = 0;
                index = (int )cob_Class.SelectedIndex;
                string StuClassId = dt_Class.Rows[index]["Class_Id"].ToString().Trim();
                sqlstr = "update dbo.Student set ClassId=@StuClassId where StuNo=@StuNo;";
                SqlParameter[] parms1 =
                {
                    new SqlParameter("@StuClassId",SqlDbType.NChar),
                    new SqlParameter("@StuNo",SqlDbType.NChar)
                };
                parms1[0].Value = StuClassId;
                parms1[1].Value = StuNo;
                SqlHelper.RunSQL(sqlstr, parms1);
            }
            this.Close();
        }
    }
}
