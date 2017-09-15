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
    public partial class Reward : Form
    {
        public Reward(string StuName,string StuNo)
        {
            this.StuName = StuName;
            this.StuNo = StuNo;
            InitializeComponent();
        }
        public Reward()
        {
            InitializeComponent();
        }
        DataTable dt_ReWard = null;
        public string StuName {get;set;}
        public string StuNo { get; set; }
        public int  Reward_Condition { set; get; }
        private void Reward_Load(object sender, EventArgs e)
        {
            dt_ReWard = new DataTable();
            DataTable dt = new DataTable();
            string sqlstr = null;
            string Value = null;
            //
            sqlstr = "select Reward_Code,Reward_Descriptions from dbo.Reward_Levels_Config;";
            GetStudentMessage(sqlstr,Value,out dt_ReWard);
            if(dt_ReWard.Rows.Count>0)
            {
                for(int i=0;i< dt_ReWard.Rows.Count;i++)
                {
                    cob_Reward_Name.Items.Add(dt_ReWard.Rows[i]["Reward_Descriptions"].ToString());
                }
            }
            cob_Reward_Name.SelectedIndex = 0;
            //
            sqlstr = "select max(CONVERT(bigint,Reward_Id)) Reward_Id  from dbo.Reward";
            Value = null;
            GetStudentMessage(sqlstr,Value,out dt);
            long Index;
            if (dt.Rows.Count == 0) Index = -1;
            else Index = (long)dt.Rows[0]["Reward_Id"];
            string Max_ID = (Index + 1).ToString("00000000");
            lal_Reward_ID.Text = Max_ID;
            lal_StuName.Text = this.StuName;
            lal_StuNo.Text = this.StuNo;
            lal_Datetime.Text = DateTime.Now.ToShortDateString();
        }

        public void GetStudentMessage(string sqlstr, string Value, out DataTable dt)
        {
            if(Value!=null)
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

        private void btn_Reward_Insert_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlstr = null;
            sqlstr = "insert into dbo.Reward values(@Reward_Id,@StuNo,@Reward_Code,@Create_Date,@Reward_Descriptions,@ReWard_Condition);";
            SqlParameter[] parms =
            {
                new SqlParameter("@Reward_Id",SqlDbType.NChar),
                new SqlParameter("@StuNo",SqlDbType.NChar),
                new SqlParameter("@Reward_Code",SqlDbType.NChar),
                new SqlParameter("@Create_Date",SqlDbType.SmallDateTime),
                new SqlParameter("@Reward_Descriptions",SqlDbType.NChar),
                new SqlParameter("@ReWard_Condition",SqlDbType.Int)
            };
            int index = cob_Reward_Name.SelectedIndex;

            parms[0].Value = lal_Reward_ID.Text;
            parms[1].Value = lal_StuNo.Text;
            parms[2].Value = dt_ReWard.Rows[index]["Reward_Code"];
            parms[3].Value = Convert.ToDateTime(lal_Datetime.Text);
            parms[4].Value = tet_Reward_Details.Text;
            parms[5].Value = Reward_Condition;
            SqlHelper.RunSQL(sqlstr,parms);
            tet_Reward_Details.Text = string.Empty;
            cob_Reward_Name.SelectedIndex = 0;
            MessageBox.Show("添加成功");
        }
    }
}
