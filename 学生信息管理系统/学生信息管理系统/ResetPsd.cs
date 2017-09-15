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
    public partial class ResetPsd : Form
    {
        public ResetPsd()
        {
            InitializeComponent();
        }

        public string No { set; get; }
        private void ResetPsd_Load(object sender, EventArgs e)
        {

        }

        private void btn_ResetPsd_Click(object sender, EventArgs e)
        {
            if(tet_Psd.Text.Trim().Equals(tet_Psd1.Text.Trim()))
            {
                string sqlstr = "update dbo.Student set StuPass_Word=@Value where StuNo=@No;";
                
                SqlParameter[] parms1 =
                {
                    new SqlParameter("@Value",SqlDbType.NChar),
                    new SqlParameter("@No",SqlDbType.NChar)
                };
                parms1[0].Value = tet_Psd.Text.Trim();
                parms1[1].Value = No;
                SqlHelper.RunSQL(sqlstr, parms1);
                tet_Psd.Text = string.Empty;
                tet_Psd1.Text = string.Empty;
                MessageBox.Show("操作成功！");
            }
            else
            {
                MessageBox.Show("两次输入不同！，请重新输入！");
                tet_Psd.Text = string.Empty;
                tet_Psd1.Text = string.Empty;
            }
        }
    }
}
