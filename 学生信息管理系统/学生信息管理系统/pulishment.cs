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
    public partial class pulishment : Form
    {
        public pulishment()
        {
            InitializeComponent();
        }
        DataTable dt_Pulishment = null;
        public string StuName { get; set; }
        public string StuNo { get; set; }
        private void btn_Pulishment_Insert_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlstr = null;
            sqlstr = "insert into dbo.Punishment values(@Punishment_Id,@StuNo,@Punishment_Code,@Create_Date,@Punishment_Enable,@Punishment_Descriptions);";
            SqlParameter[] parms =
            {
                new SqlParameter("@Punishment_Id",SqlDbType.NChar),
                new SqlParameter("@StuNo",SqlDbType.NChar),
                new SqlParameter("@Punishment_Code",SqlDbType.NChar),
                new SqlParameter("@Create_Date",SqlDbType.SmallDateTime),
                new SqlParameter("@Punishment_Enable",SqlDbType.NChar),
                new SqlParameter("@Punishment_Descriptions",SqlDbType.NChar)
            };
            int index = cob_Name.SelectedIndex;

            parms[0].Value = lal__ID.Text;
            parms[1].Value = lal_StuNo.Text;
            parms[2].Value = dt_Pulishment.Rows[index]["Punish_Code"];
            parms[3].Value = Convert.ToDateTime(lal_Datetime.Text);
            parms[5].Value = tet__Details.Text;
            parms[4].Value = "Y";
            SqlHelper.RunSQL(sqlstr, parms);
            this.Close();
        }

        private void pulishment_Load(object sender, EventArgs e)
        {
            dt_Pulishment = new DataTable();
            DataTable dt = new DataTable();
            string sqlstr = null;
            string Value = null;
            //
            sqlstr = "select Punish_Code,Punish_Descriptions from dbo.Punish_Levels_Config;";
            GetStudentMessage(sqlstr, Value, out dt_Pulishment);
            if (dt_Pulishment.Rows.Count > 0)
            {
                for (int i = 0; i < dt_Pulishment.Rows.Count; i++)
                {
                    cob_Name.Items.Add(dt_Pulishment.Rows[i]["Punish_Descriptions"].ToString());
                }
            }
            cob_Name.SelectedIndex = 0;
            //
            sqlstr = "select max(CONVERT(bigint,Punishment_Id)) Punishment_Id  from dbo.Punishment";
            Value = null;
            GetStudentMessage(sqlstr, Value, out dt);
            long Index;
            if (dt.Rows.Count == 0) Index = -1;
            else Index= (long)dt.Rows[0]["Punishment_Id"];
            string Max_ID = (Index + 1).ToString("00000000");
            lal__ID.Text = Max_ID;
            lal_StuName.Text = StuName;
            lal_StuNo.Text = StuNo;
            lal_Datetime.Text = DateTime.Now.ToShortDateString();
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
    }
}
