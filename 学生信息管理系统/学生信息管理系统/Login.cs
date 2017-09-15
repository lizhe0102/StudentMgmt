using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UserLoginDemo;

namespace 学生信息管理系统
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lal_GetPsd_Click(object sender, EventArgs e)
        {
            GetPsd getpsd = new GetPsd();
            getpsd.No = tet_No.Text;
            getpsd.SelectedPeople = cob_Type.SelectedItem.ToString().Trim();
            getpsd.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cob_Type.Items.Add("学生");
            cob_Type.Items.Add("老师");
            cob_Type.SelectedIndex = 0;
            lal_ErrorMessage.Text = "所有的初始密码都为：123321";
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if(cob_Type.SelectedItem.ToString().Equals("学生"))
            {
                string sqlstr = "select count(*) from dbo.Student where StuNo=@No and StuPass_Word=@Psd;";
                SqlParameter[] parms =
                {
                    new SqlParameter("@No",SqlDbType.NChar),
                    new SqlParameter("@Psd",SqlDbType.NChar)
                };
                parms[0].Value = tet_No.Text.Trim();
                parms[1].Value = tet_Psd.Text.Trim();
                int i = SqlHelper.RunSQLReturnValue(sqlstr, parms);
                if (i == 1)
                {
                    Student_Message form = new Student_Message();
                    form.No = tet_No.Text.Trim();
                    form.Show();
                    this.Visible = false;

                }
                else
                {
                    lal_ErrorMessage.Text = "用户名或密码错误！";
                }
            }
            else if(cob_Type.SelectedItem.ToString().Equals("老师"))
            {
                string sqlstr = "select count(*) from dbo.DB_Teacher where T_No=@No and T_Pass_Word=@Psd;";
                SqlParameter[] parms =
                {
                    new SqlParameter("@No",SqlDbType.NChar),
                    new SqlParameter("@Psd",SqlDbType.NChar)
                };
                parms[0].Value = tet_No.Text.Trim();
                parms[1].Value = tet_Psd.Text.Trim();
                int i = SqlHelper.RunSQLReturnValue(sqlstr, parms);
                if (i == 1)
                {
                    Student_Message_Seacher form = new Student_Message_Seacher();
                    form.Show();
                    this.Visible = false; 
                    
                }
                else
                {
                    lal_ErrorMessage.Text = "用户名或密码错误！";
                }
            }
        }

        private void lal_GetPsd_MouseMove(object sender, MouseEventArgs e)
        {
            lal_GetPsd.ForeColor = System.Drawing.Color.Green;
        }

        private void lal_GetPsd_MouseLeave(object sender, EventArgs e)
        {
            lal_GetPsd.ForeColor = System.Drawing.Color.Blue ;
        }
    }
}
