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
    public partial class GetPsd : Form
    {
        public GetPsd()
        {
            InitializeComponent();
        }
        public string No { set; get; }
        public string SelectedPeople { set; get; }
        private void GetPsd_Load(object sender, EventArgs e)
        {

        }

        private void GetPsd_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btn_GetPsd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (SelectedPeople.Equals("学生"))
            {
                string sqlstr = "select StuPass_Word from dbo.Student where StuName=@Name and StuNo=@No";
                SqlParameter[] parms =
                {
                    new SqlParameter("@Name",SqlDbType.NChar),
                    new SqlParameter("@No",SqlDbType.NChar)
                };
                parms[0].Value = tet_Name.Text.Trim();
                parms[1].Value = No;
                SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
                if (dt.Rows.Count > 0)
                {
                    tet_Psd.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("当前账号不存在，请检查账号！");
                    this.Close();
                }
            }
            else if (SelectedPeople.Equals("老师"))
            {
                string sqlstr = "select T_Pass_Word from dbo.DB_Teacher where T_Name=@Name and T_No=@No";
                SqlParameter[] parms =
                {
                    new SqlParameter("@Name",SqlDbType.NChar),
                    new SqlParameter("@No",SqlDbType.NChar)
                };
                parms[0].Value = tet_Name.Text.Trim();
                parms[1].Value = No;
                SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
                if (dt.Rows.Count > 0)
                {
                    tet_Psd.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("当前账号不存在，请检查账号！");
                    this.Close();
                }
            }
        }
    }
}
