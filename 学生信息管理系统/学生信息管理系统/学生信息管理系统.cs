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
using System.Text.RegularExpressions;

namespace 学生信息管理系统
{
    public partial class Student_Message_Seacher : Form
    {
        public Student_Message_Seacher()
        {
            InitializeComponent();
        }
        DataTable dt_schoolName = new DataTable();
        DataTable dt_DeptID = null;
        DataTable dt_ClassID = null;

        //tab_Student_Management
        private void Student_Message_Seacher_Load(object sender, EventArgs e)
        {
            
            //tab_Student_Management
            dt_ClassID = new DataTable();
            dt_DeptID = new DataTable();
            cob_Way.Items.Add("姓名精确查找");
            cob_Way.Items.Add("学号精确查找");
            cob_Way.Items.Add("学号缺省查找");
            cob_Way.Items.Add("姓名缺省查找");
            cob_Way.SelectedIndex = 0;
            //初始化cob_Dpt_ID控件
            string Sqlstr_cob_Dept = "select * from dbo.Department;";
            SqlHelper.RunSQLReturnDataTable(Sqlstr_cob_Dept, out dt_DeptID);
            cob_Dpt_ID.Items.Add("不限");
            for(int i=0;i< dt_DeptID.Rows.Count;i++)
            {
                cob_Dpt_ID.Items.Add(dt_DeptID.Rows[i]["Department_Name"]);
            }
            cob_Dpt_ID.SelectedIndex = 0;
            //初始化cob_ClassId，加载班级信息
            string Sqlstr_cob_Class = "select * from dbo.Classes;";
            SqlHelper.RunSQLReturnDataTable(Sqlstr_cob_Class, out dt_ClassID);
            cob_ClassId.Items.Add("不限");
            for (int i = 0; i < dt_ClassID.Rows.Count; i++)
            {
                cob_ClassId.Items.Add(dt_ClassID.Rows[i]["Class_Name"]);
            }
            cob_ClassId.SelectedIndex = 0;
            //初始化加载学生基本信息
            DataTable dt = new DataTable();
            string sqlstr = "select distinct StuNo 学号,StuName 姓名,Sex 性别,Birthday 生日,Native_Place 籍贯 from dbo.Student; ";
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt);
            dgv_Stu_Result.DataSource = dt;
            
            tabControl1.SelectedTab = tab_Student_Management;

        }
       
        private void tSMenuItem_Details_Click(object sender, EventArgs e)
        {
            //实例化一个显示窗口
            Stu_Message St_M = new Stu_Message();
            //显示学号，姓名，性别，籍贯，生日信息
            St_M.lal_StuNameT.Text = dgv_Stu_Result.SelectedRows[0].Cells["姓名"].Value.ToString();
            St_M.lal_StuNoT.Text = dgv_Stu_Result.SelectedRows[0].Cells["学号"].Value.ToString();
            St_M.lal_SexT.Text = dgv_Stu_Result.SelectedRows[0].Cells["性别"].Value.ToString();
            St_M.lal_Native_PlaceT.Text = dgv_Stu_Result.SelectedRows[0].Cells["籍贯"].Value.ToString();
            St_M.lal_BirthdayT.Text = dgv_Stu_Result.SelectedRows[0].Cells["生日"].Value.ToString();

            //
            string seacherStr_StuNo = dgv_Stu_Result.SelectedRows[0].Cells["学号"].Value.ToString();
            //获取班级id
            DataTable dt = new DataTable();
            string sqlstr = "select distinct ClassId from dbo.Student where StuNo=@StuNo; ";
            SqlParameter[] parms1 = {
                new SqlParameter("@StuNo",SqlDbType.NChar)
            };
            parms1[0].Value = seacherStr_StuNo;
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt,parms1);
            DataRow dr = dt.Rows[0];
            string seacherStr_ClassId = dr["ClassId"].ToString();
            //获取班级，学院
            sqlstr= "select c.Class_Name,d.Department_Name from dbo.Classes as c join dbo.Department as d on c.Department_Id=d.Department_Id where c.Class_Id = @Class_Id";
            SqlParameter[] parms2 = {
                new SqlParameter("@Class_Id",SqlDbType.NChar)
            };
            parms2[0].Value = seacherStr_ClassId;
            dt.Clear();
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt,parms2);
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
                    if((int)dt.Rows[i]["ReWard_Condition"]==1)
                    {
                        St_M.tet_RewardT.Text += "创建日期："+  dt.Rows[i]["Create_Date"].ToString().Trim() + "\r\n";
                        St_M.tet_RewardT.Text += "奖励描述：" + dt.Rows[i]["Reward_Descriptions"].ToString().Trim() + "\r\n"+ "\r\n";
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
            
            St_M.Show();
        }

        private void tSMenuItem_Reward_Click(object sender, EventArgs e)
        {
            Reward rd = new Reward();
            rd.StuName = dgv_Stu_Result.SelectedRows[0].Cells["姓名"].Value.ToString();
            rd.StuNo = dgv_Stu_Result.SelectedRows[0].Cells["学号"].Value.ToString();
            rd.Reward_Condition = 1;
            rd.Show();
        }

        private void tSMenuItem_pulish_Click(object sender, EventArgs e)
        {
            pulishment pt = new pulishment();
            pt.StuName = dgv_Stu_Result.SelectedRows[0].Cells["姓名"].Value.ToString();
            pt.StuNo = dgv_Stu_Result.SelectedRows[0].Cells["学号"].Value.ToString();
            pt.Show();
        }

        private void tSMenuItem_ReSet_Change_Click(object sender, EventArgs e)
        {
            change ce = new change();
            ce.StuName = dgv_Stu_Result.SelectedRows[0].Cells["姓名"].Value.ToString();
            ce.StuNo = dgv_Stu_Result.SelectedRows[0].Cells["学号"].Value.ToString();
            ce.Show();
        }
        
        private void cob_Dpt_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            cob_ClassId.Items.Clear();
            //查找所选部门部门ID
            string str_Dept_No = null;
            if (cob_Dpt_ID.SelectedIndex != 0)
            {
                for (int i = 0; i < dt_DeptID.Rows.Count; i++)
                {
                    if (dt_DeptID.Rows[i]["Department_Name"].ToString().Equals(cob_Dpt_ID.SelectedItem.ToString()))
                    {
                        str_Dept_No = dt_DeptID.Rows[i]["Department_Id"].ToString();
                        break;
                    }
                }
                //查找与部门先对应的班级
                SqlParameter[] parms ={
                 new SqlParameter("@Department_Id",SqlDbType.NChar)
                };
                parms[0].Value = str_Dept_No;
                string sqlstr = "select Class_Name from dbo.Classes where Department_Id=@Department_Id;";
                SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
                cob_ClassId.Items.Add("不限");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cob_ClassId.Items.Add(dt.Rows[i]["Class_Name"]);
                    }
                }
                cob_ClassId.SelectedIndex = 0;

                SelectStudentByDepartmentId(str_Dept_No);
            }
            else
            {
                //输出所有学生
                string sqlstr = "select distinct StuNo 学号,StuName 姓名,Sex 性别,Birthday 生日,Native_Place 籍贯 from dbo.Student; ";
                SqlHelper.RunSQLReturnDataTable(sqlstr, out dt);
                dgv_Stu_Result.DataSource = dt;
                //填充控件cob_ClassId
                cob_ClassId.Items.Add("不限");
                if (dt_ClassID.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_ClassID.Rows.Count; i++)
                    {
                        cob_ClassId.Items.Add(dt_ClassID.Rows[i]["Class_Name"]);
                    }
                }
                cob_ClassId.SelectedIndex = 0;
            }
        }

        private void cob_ClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cob_ClassId.SelectedIndex==0)
            {
                DataTable dt = new DataTable();
                string str_Dept_No = null;
                if (cob_Dpt_ID.SelectedIndex != 0)
                {
                    for (int i = 0; i < dt_DeptID.Rows.Count; i++)
                    {
                        if (dt_DeptID.Rows[i]["Department_Name"].ToString().Equals(cob_Dpt_ID.SelectedItem.ToString()))
                        {
                            str_Dept_No = dt_DeptID.Rows[i]["Department_Id"].ToString();
                            break;
                        }
                    }

                    SqlParameter[] parms ={
                                 new SqlParameter("@Department_Id",SqlDbType.NChar)
                           };
                    parms[0].Value = str_Dept_No;
                    string sqlstr = "select Class_Name from dbo.Classes where Department_Id=@Department_Id;";
                    SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
                    SelectStudentByDepartmentId(str_Dept_No);
                }
                else
                {
                    //输出所有学生
                    string sqlstr = "select distinct StuNo 学号,StuName 姓名,Sex 性别,Birthday 生日,Native_Place 籍贯 from dbo.Student; ";
                    SqlHelper.RunSQLReturnDataTable(sqlstr, out dt);
                    dgv_Stu_Result.DataSource = dt;
                }
            }
            else
            {
                this.SelectStudentByClassId();
            }
        }

        private void  SelectStudentByClassId()
        {
            DataTable dt = new DataTable();
            string str_ClassId = null;
            for (int i = 0; i < dt_ClassID.Rows.Count; i++)
            {
                if (dt_ClassID.Rows[i]["Class_Name"].ToString().Equals(cob_ClassId.SelectedItem.ToString()))
                {

                    str_ClassId = dt_ClassID.Rows[i]["Class_Id"].ToString();
                    break;
                }
            }
            SqlParameter[] parms ={
                 new SqlParameter("@Class_Id",SqlDbType.NChar)
                };
            parms[0].Value = str_ClassId;
            string sqlstr = "select distinct StuNo 学号,StuName 姓名,Sex 性别,Birthday 生日,Native_Place 籍贯 from dbo.Student where ClassId=@Class_Id; ";
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
            dgv_Stu_Result.DataSource = dt;
        }

        private void  SelectStudentByDepartmentId(string str_Dept_Id)
        {
            DataTable dt = new DataTable();
            if (cob_Dpt_ID.SelectedIndex == 0)
            {
               
            }
            else
            {
                SqlParameter[] parms ={
                 new SqlParameter("@Department_Id",SqlDbType.NChar)
                };
                parms[0].Value = str_Dept_Id;
                string sqlstr = "select distinct StuNo 学号,StuName 姓名,Sex 性别,Birthday 生日,Native_Place 籍贯 from dbo.Student where ClassId in(select Class_Id from dbo.Classes where Department_Id=@Department_Id)  ";
                SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
                dgv_Stu_Result.DataSource = dt;
            }
            
        }

        private void btn_Seacher_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlstr = null;
            cob_Dpt_ID.SelectedIndex = 0;
            cob_ClassId.SelectedIndex = 0;
            SqlParameter[] parms = {
                new SqlParameter("@Value",SqlDbType.NChar)
            };
            parms[0].Value = txt_StuName_or_StuNo.Text;
            if(cob_Way.SelectedItem.ToString().Equals("姓名精确查找"))
            {
                parms[0].Value = txt_StuName_or_StuNo.Text;
                sqlstr = "select distinct StuNo 学号,StuName 姓名,Sex 性别,Birthday 生日,Native_Place 籍贯 from dbo.Student where StuName=@Value;";
            }
            else if(cob_Way.SelectedItem.ToString().Equals("学号精确查找"))
            {
                parms[0].Value = txt_StuName_or_StuNo.Text;
                sqlstr = "select distinct StuNo 学号,StuName 姓名,Sex 性别,Birthday 生日,Native_Place 籍贯 from dbo.Student where StuNo=@Value;";
            }
            else if (cob_Way.SelectedItem.ToString().Equals("姓名缺省查找"))
            {
                parms[0].Value = txt_StuName_or_StuNo.Text+"%";
                sqlstr = "select distinct StuNo 学号,StuName 姓名,Sex 性别,Birthday 生日,Native_Place 籍贯 from dbo.Student where StuName like @Value;";
            }
            else if (cob_Way.SelectedItem.ToString().Equals("学号缺省查找"))
            {
                parms[0].Value = txt_StuName_or_StuNo.Text+"%";
                sqlstr = "select distinct StuNo 学号,StuName 姓名,Sex 性别,Birthday 生日,Native_Place 籍贯 from dbo.Student where StuNo like @Value;";
            }
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
            dgv_Stu_Result.DataSource = dt;
            txt_StuName_or_StuNo.Text = string.Empty;
        }



        //tab_Message_Search
        private void tab_Message_Search_Enter(object sender, EventArgs e)
        {
            tSMenuItem_Approval.Visible = false;
            //初始化cob_Selection
            cob_Selection.Items.Add("奖励信息查询");
            cob_Selection.Items.Add("惩罚信息查询");
            cob_Selection.Items.Add("学生奖励审批");
            cob_Selection.Items.Add("学籍改变信息查询");
            cob_Selection.SelectedIndex = 0;
            //初始化cob_Dept
            cob_Dept.Items.Add("不限");
            for (int i = 0; i < dt_DeptID.Rows.Count; i++)
            {
                cob_Dept.Items.Add(dt_DeptID.Rows[i]["Department_Name"]);
            }
            cob_Dept.SelectedIndex = 0;
            //初始化cob_Class
            cob_Class.Items.Add("不限");
            for (int i = 0; i < dt_ClassID.Rows.Count; i++)
            {
                cob_Class.Items.Add(dt_ClassID.Rows[i]["Class_Name"]);
            }
            cob_Class.SelectedIndex = 0;
            //初始化cob_NoOrName
            cob_NoOrName.Items.Add("姓名精确查找");
            cob_NoOrName.Items.Add("学号精确查找");
            cob_NoOrName.Items.Add("学号缺省查找");
            cob_NoOrName.Items.Add("姓名缺省查找");
            cob_NoOrName.SelectedIndex = 0;
            //向dgv_Stu_Result添加数据
            
        }

        private void tab_Message_Search_Leave(object sender, EventArgs e)
        {
            cob_NoOrName.Items.Clear();
            cob_Selection.Items.Clear();
            cob_Class.Items.Clear();
            cob_Dept.Items.Clear();
        }

        private void cob_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string operateType = cob_Selection.SelectedItem.ToString();
            IOperate operate = null;
            if (cob_Dept.SelectedItem.ToString().Equals("不限"))
            {
                //填充cob_Class
                cob_Class.Items.Clear();
                cob_Class.Items.Add("不限");
                for (int i = 0; i < dt_ClassID.Rows.Count; i++)
                {
                    cob_Class.Items.Add(dt_ClassID.Rows[i]["Class_Name"]);
                }
                cob_Class.SelectedIndex = 0;
                //选择项目
                operate = Factory.CreateOperate(operateType);
                dgv_Message_Search_Result.DataSource=operate.Operate(null, null);
            }
            else
            {
                DataTable dt = new DataTable();
                //找到与该部门对应的ID
                string StrDept = null;
                for (int i = 0; i < dt_DeptID.Rows.Count; i++)
                {
                    if (cob_Dept.SelectedItem.ToString().Equals(dt_DeptID.Rows[i]["Department_Name"].ToString()))
                    {
                        StrDept = dt_DeptID.Rows[i]["Department_Id"].ToString();
                        break;
                    }
                }
              
                //为cob_Class添加与部门对应的班级
                SqlParameter[] parms ={
                 new SqlParameter("@Department_Id",SqlDbType.NChar)
                };
                dt.Clear();
                parms[0].Value = StrDept;
                string sqlstr = "select Class_Name from dbo.Classes where Department_Id=@Department_Id;";
                SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
                cob_Class.Items.Clear();
                cob_Class.Items.Add("不限");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cob_Class.Items.Add(dt.Rows[i]["Class_Name"]);
                    }
                }
                cob_Class.SelectedIndex = 0;
                //改后代码
                operate = Factory.CreateOperate(operateType);
                dgv_Message_Search_Result.DataSource = operate.Operate(StrDept, null);
            }
                //像dgv_Message_Result中添加数据

                /*
                DataTable dt0 = new DataTable();
                if(cob_Dept.SelectedItem.ToString().Equals("不限"))
                {
                    //填充cob_Class
                    cob_Class.Items.Clear();
                    cob_Class.Items.Add("不限");
                    for (int i = 0; i < dt_ClassID.Rows.Count; i++)
                    {
                        cob_Class.Items.Add(dt_ClassID.Rows[i]["Class_Name"]);
                    }
                    cob_Class.SelectedIndex = 0;
                    //选择项目
                    if (cob_Selection.SelectedItem.ToString().Equals("惩罚信息查询"))
                    {
                        string sqlstr = "select Punishment_Id 编号,s.StuNo 学号,StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述 from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code";
                        dgv_Message_Search_Result.DataSource = GetMessageBy_cob_Selection(sqlstr);
                    }
                    else if (cob_Selection.SelectedItem.ToString().Equals("奖励信息查询"))
                    {
                        string sqlstr = "select Reward_Id 编号, s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=1";
                        dgv_Message_Search_Result.DataSource = GetMessageBy_cob_Selection(sqlstr);
                    }
                    else if (cob_Selection.SelectedItem.ToString().Equals("学生奖励审批"))
                    {
                        string sqlstr = "select Reward_Id 编号, s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=0";
                        dgv_Message_Search_Result.DataSource = GetMessageBy_cob_Selection(sqlstr);
                    }
                    else
                    {
                        string sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions 学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo and c.Change_Code = cc.Change_Code";
                        dgv_Message_Search_Result.DataSource = GetMessageBy_cob_Selection(sqlstr);
                    }
                }
                else
                {
                    DataTable dt = new DataTable();
                    //找到与该部门对应的班级
                    string StrDept=null;
                    //string StrClass=null;
                    for(int i=0;i<dt_DeptID.Rows.Count;i++)
                    {
                        if (cob_Dept.SelectedItem.ToString().Equals(dt_DeptID.Rows[i]["Department_Name"].ToString()))
                        {
                            StrDept = dt_DeptID.Rows[i]["Department_Id"].ToString();
                            break;
                        }
                    }
                    //为cob_Class添加与部门对应的班级
                    SqlParameter[] parms ={
                     new SqlParameter("@Department_Id",SqlDbType.NChar)
                    };
                    dt.Clear();
                    parms[0].Value = StrDept;
                    string sqlstr = "select Class_Name from dbo.Classes where Department_Id=@Department_Id;";
                    SqlHelper.RunSQLReturnDataTable(sqlstr, out dt, parms);
                    cob_Class.Items.Clear();
                    cob_Class.Items.Add("不限");
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cob_Class.Items.Add(dt.Rows[i]["Class_Name"]);
                        }
                    }
                    cob_Class.SelectedIndex = 0;
                    //像dgv_Message_Result中添加数据
                    if (cob_Selection.SelectedItem.ToString().Equals("惩罚信息查询"))
                    {
                        sqlstr = "select Punishment_Id 编号, s.StuNo 学号,s.StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述 from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code and s.ClassId in (select Class_Id from dbo.Classes where Department_Id = @Department_Id); ";
                        GetStudentByDeptIdOrClassId(sqlstr, StrDept,out dt0);
                        dgv_Message_Search_Result.DataSource = dt0; 
                    }
                    else if (cob_Selection.SelectedItem.ToString().Equals("奖励信息查询"))
                    {
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=1 and s.ClassId in (select Class_Id from dbo.Classes where Department_Id = @Department_Id); ";
                        GetStudentByDeptIdOrClassId(sqlstr, StrDept, out dt0);
                        dgv_Message_Search_Result.DataSource = dt0;
                    }
                    else if (cob_Selection.SelectedItem.ToString().Equals("学生奖励审批"))
                    {
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=0 and s.ClassId in (select Class_Id from dbo.Classes where Department_Id = @Department_Id); ";
                        GetStudentByDeptIdOrClassId(sqlstr, StrDept, out dt0);
                        dgv_Message_Search_Result.DataSource = dt0;
                    }
                    else
                    {
                        sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions 学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo and c.Change_Code = cc.Change_Code and s.ClassId in (select Class_Id from dbo.Classes where Department_Id = @Department_Id); ";
                        GetStudentByDeptIdOrClassId(sqlstr, StrDept, out dt0);
                        dgv_Message_Search_Result.DataSource = dt0;
                    }
                }
                */
            }

        private void cob_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            string operateType = cob_Selection.SelectedItem.ToString();
            IOperate operate = null;
            DataTable dt = new DataTable();
            
            string StrDept = null;
            string StrClass = null;
            if (cob_Class.SelectedItem.ToString().Equals("不限"))
            {
                if (cob_Dept.SelectedItem.ToString().Equals("不限"))
                {
                    cob_Dept.SelectedIndex = 0;
                }
                else
                {
                    //获取此时所选中的部门号
                    
                    for (int i = 0; i < dt_DeptID.Rows.Count; i++)
                    {
                        if (cob_Dept.SelectedItem.ToString().Equals(dt_DeptID.Rows[i]["Department_Name"].ToString()))
                        {
                            StrDept = dt_DeptID.Rows[i]["Department_Id"].ToString();
                            break;
                        }
                    }
                    //改后代码
                    operate = Factory.CreateOperate(operateType);
                    dgv_Message_Search_Result.DataSource = operate.Operate(StrDept, null);
                }
            }
            else
            {
                //获取此时选中的班级Id
                for (int i = 0; i < dt_ClassID.Rows.Count; i++)
                {
                    if (dt_ClassID.Rows[i]["Class_Name"].ToString().Equals(cob_Class.SelectedItem.ToString()))
                    {
                        StrClass = dt_ClassID.Rows[i]["Class_Id"].ToString();
                        break;
                    }
                }
                //向cob_Class添加项目
                operate = Factory.CreateOperate(operateType);
                dgv_Message_Search_Result.DataSource = operate.Operate(null, StrClass);
            }
            /*
            DataTable dt = new DataTable();
            string sqlstr = null;
            string StrDept = null;
            string StrClass = null;
            if (cob_Class.SelectedItem.ToString().Equals("不限"))
            {
                if(cob_Dept.SelectedItem.ToString().Equals("不限"))
                {
                    cob_Dept.SelectedIndex = 0;
                }
                else
                {
                    //获取此时所选中的部门号
                    for (int i = 0; i < dt_DeptID.Rows.Count; i++)
                    {
                        if (cob_Dept.SelectedItem.ToString().Equals(dt_DeptID.Rows[i]["Department_Name"].ToString()))
                        {
                            StrDept = dt_DeptID.Rows[i]["Department_Id"].ToString();
                            break;
                        }
                    }
                    //向cob_Dept添加项目
                    if (cob_Selection.SelectedItem.ToString().Equals("惩罚信息查询"))
                    {
                        sqlstr = "select Punishment_Id 编号, s.StuNo 学号,s.StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述 from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code and s.ClassId in (select Class_Id from dbo.Classes where Department_Id = @Department_Id); ";
                        GetStudentByDeptIdOrClassId(sqlstr, StrDept, out dt);
                        dgv_Message_Search_Result.DataSource = dt;
                    }
                    else if (cob_Selection.SelectedItem.ToString().Equals("奖励信息查询"))
                    {
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=1 and s.ClassId in (select Class_Id from dbo.Classes where Department_Id = @Department_Id); ";
                        GetStudentByDeptIdOrClassId(sqlstr, StrDept, out dt);
                        dgv_Message_Search_Result.DataSource = dt;
                    }
                    else if (cob_Selection.SelectedItem.ToString().Equals("学生奖励审批"))
                    {
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=0 and s.ClassId in (select Class_Id from dbo.Classes where Department_Id = @Department_Id); ";
                        GetStudentByDeptIdOrClassId(sqlstr, StrDept, out dt);
                        dgv_Message_Search_Result.DataSource = dt;
                    }
                    else
                    {
                        sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions 学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo and c.Change_Code = cc.Change_Code and s.ClassId in (select Class_Id from dbo.Classes where Department_Id = @Department_Id); ";
                        GetStudentByDeptIdOrClassId(sqlstr, StrDept, out dt);
                        dgv_Message_Search_Result.DataSource = dt;
                    }
                }
            }
            else
            {
                //获取此时选中的班级Id
                for (int i = 0; i < dt_ClassID.Rows.Count; i++)
                {
                    if (dt_ClassID.Rows[i]["Class_Name"].ToString().Equals(cob_Class.SelectedItem.ToString()))
                    {
                        StrClass = dt_ClassID.Rows[i]["Class_Id"].ToString();
                        break;
                    }
                }
                //向cob_Class添加项目
                if (cob_Selection.SelectedItem.ToString().Equals("惩罚信息查询"))
                {
                    sqlstr = "select Punishment_Id 编号, s.StuNo 学号,s.StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述 from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code and s.ClassId  = @Department_Id; ";
                    GetStudentByDeptIdOrClassId(sqlstr, StrClass, out dt);
                    dgv_Message_Search_Result.DataSource = dt;
                }
                else if (cob_Selection.SelectedItem.ToString().Equals("奖励信息查询"))
                {
                    sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=1 and s.ClassId = @Department_Id; ";
                    GetStudentByDeptIdOrClassId(sqlstr, StrClass, out dt);
                    dgv_Message_Search_Result.DataSource = dt;
                }
                else if (cob_Selection.SelectedItem.ToString().Equals("学生奖励审批"))
                {
                    sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=0 and s.ClassId = @Department_Id; ";
                    GetStudentByDeptIdOrClassId(sqlstr, StrClass, out dt);
                    dgv_Message_Search_Result.DataSource = dt;
                }
                else
                {
                    sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions 学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo and c.Change_Code = cc.Change_Code and s.ClassId  = @Department_Id; ";
                    GetStudentByDeptIdOrClassId(sqlstr, StrClass, out dt);
                    dgv_Message_Search_Result.DataSource = dt;
                }
            }
            */
        }

        public void GetStudentByDeptIdOrClassId(string SqlStr,string StrDept,out DataTable dt)
        {
            SqlParameter[] parms ={
                 new SqlParameter("@Department_Id",SqlDbType.NChar)
                };
            parms[0].Value = StrDept;
            SqlHelper.RunSQLReturnDataTable(SqlStr, out dt, parms);
        }

        public DataTable GetMessageBy_cob_Selection(string sqlstr)
        {
            DataTable dt = new DataTable();
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt);
            return dt;
        }

        private void dgv_Message_Search_Result_SelectionChanged(object sender, EventArgs e)
        {
            tet_Detial_Message.Text = "无";
            string SqlStr = null;
            DataTable dt = new DataTable();
            string Str_ID=null ;
            if (dgv_Message_Search_Result.Rows[0].Cells[0].Value==null ) tet_Detial_Message.Text = "无";

            if (dgv_Message_Search_Result.Rows.Count>0&& dgv_Message_Search_Result.SelectedRows.Count>0)
            {
                Str_ID = dgv_Message_Search_Result.SelectedRows[0].Cells["编号"].Value.ToString();

                if (cob_Selection.SelectedItem.ToString().Equals("惩罚信息查询"))
                {
                    SqlStr = "select Punishment_Descriptions from dbo.Punishment where Punishment_Id=@Department_Id";
                    GetStudentByDeptIdOrClassId(SqlStr, Str_ID, out dt);
                    if ((dt).Rows.Count > 0)
                    {
                        tet_Detial_Message.Text = dt.Rows[0][0].ToString();
                    }
                    else tet_Detial_Message.Text = "无";
                }
                else if (cob_Selection.SelectedItem.ToString().Equals("奖励信息查询"))
                {
                    SqlStr = "select Reward_Descriptions from dbo.Reward where Reward_Id=@Department_Id";
                    dt.Clear();
                    GetStudentByDeptIdOrClassId(SqlStr, Str_ID, out dt);
                    if ((dt).Rows.Count > 0)
                    {
                        tet_Detial_Message.Text = dt.Rows[0][0].ToString();
                    }
                    else tet_Detial_Message.Text = "无";
                }
                else if (cob_Selection.SelectedItem.ToString().Equals("学生奖励审批"))
                {
                    SqlStr = "select Reward_Descriptions from dbo.Reward where Reward_Id=@Department_Id";
                    dt.Clear();
                    GetStudentByDeptIdOrClassId(SqlStr, Str_ID, out dt);
                    if ((dt).Rows.Count > 0)
                    {
                        tet_Detial_Message.Text = dt.Rows[0][0].ToString();
                    }
                    else tet_Detial_Message.Text = "无";
                }
                else
                {
                    SqlStr = "select Change_Descriptions from dbo.Change where Change_Id=@Department_Id";
                    dt.Clear();
                    GetStudentByDeptIdOrClassId(SqlStr, Str_ID, out dt);
                    if ((dt).Rows.Count > 0)
                    {
                        tet_Detial_Message.Text = dt.Rows[0][0].ToString();
                    }
                    else tet_Detial_Message.Text = "无";
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            //dgv_Message_Search_Result.Rows.Clear();
            DataTable dt = new DataTable();
            cob_Class.SelectedIndex = 0;
            cob_Dept.SelectedIndex = 0;
            string Search_Value = null;
            string sqlstr = null;
            if(tet_StuNo_StuName.Text!= null)
            {
                if (cob_Selection.SelectedItem.ToString().Equals("惩罚信息查询"))
                {
                    if (cob_NoOrName.SelectedItem.ToString().Equals("姓名精确查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text;
                        sqlstr = "select Punishment_Id 编号, s.StuNo 学号,s.StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述 from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code and s.StuName=@Department_Id;";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("学号精确查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text;
                        sqlstr = "select Punishment_Id 编号, s.StuNo 学号,s.StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述 from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code and s.StuNo=@Department_Id; ";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("姓名缺省查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text+"%";
                        sqlstr = "select Punishment_Id 编号, s.StuNo 学号,s.StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述 from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code and s.StuName like @Department_Id;";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("学号缺省查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text + "%";
                        sqlstr = "select Punishment_Id 编号, s.StuNo 学号,s.StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述 from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code and s.StuNo like @Department_Id; ";
                    }
                }
                else if (cob_Selection.SelectedItem.ToString().Equals("奖励信息查询"))
                {
                    if (cob_NoOrName.SelectedItem.ToString().Equals("姓名精确查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text ;
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=1 and s.StuName=@Department_Id; ";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("学号精确查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text;
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=1 and s.StuNo=@Department_Id; ";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("姓名缺省查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text+"%";
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=1 and s.StuName like @Department_Id; ";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("学号缺省查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text + "%";
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=1 and s.StuNo like @Department_Id; ";
                    }
                }
                else if (cob_Selection.SelectedItem.ToString().Equals("学生奖励审批"))
                {
                    if (cob_NoOrName.SelectedItem.ToString().Equals("姓名精确查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text;
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=0 and s.StuName=@Department_Id; ";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("学号精确查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text;
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=0 and s.StuNo = @Department_Id; ";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("姓名缺省查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text + "%".ToString();
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=0 and s.StuName like @Department_Id; ";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("学号缺省查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text + "%";
                        sqlstr = "select Reward_Id 编号,s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=0 and s.StuNo like @Department_Id; ";
                    }
                }
                else
                {
                    if (cob_NoOrName.SelectedItem.ToString().Equals("姓名精确查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text;
                        sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions 学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo and c.Change_Code = cc.Change_Code and s.StuName=@Department_Id;";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("学号精确查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text;
                        sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions 学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo and c.Change_Code = cc.Change_Code and s.StuNo=@Department_Id; ";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("姓名缺省查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text + "%";
                        sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions 学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo and c.Change_Code = cc.Change_Code and s.StuName like @Department_Id; ";
                    }
                    else if (cob_NoOrName.SelectedItem.ToString().Equals("学号缺省查找"))
                    {
                        Search_Value = tet_StuNo_StuName.Text + "%";
                        sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions 学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo and c.Change_Code = cc.Change_Code and s.StuNo like @Department_Id; ";
                    }
                }
                GetStudentByDeptIdOrClassId(sqlstr, Search_Value, out dt);
                dgv_Message_Search_Result.DataSource = dt;
            }
            else
            {
                MessageBox.Show("请输入查询关键字");
            }
            tet_StuNo_StuName.Text = string.Empty;
        }

        private void cob_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cob_Selection.SelectedItem.ToString().Equals("学生奖励审批"))
            {
                tSMenuItem_Approval.Visible = true;
                lal_tishi.Visible = true;
            }
            else
            {
                tSMenuItem_Approval.Visible = false;
                lal_tishi.Visible = false;
            }
        }

        private void tSMenuItem_Approval_Click(object sender, EventArgs e)
        {
            string ID = null;
            DataTable dt = new DataTable();
            string sqlstr = null;
            ID = dgv_Message_Search_Result.SelectedRows[0].Cells[0].Value.ToString();
            if(ID!=null)
            {
                sqlstr = "update dbo.Reward set ReWard_Condition=1 where Reward_Id=@ID";
                SqlParameter[] parms =
                {
                    new SqlParameter("@ID",SqlDbType.NChar)
                };
                parms[0].Value = ID;

                SqlHelper.RunSQL(sqlstr, parms);
                MessageBox.Show("审批成功");
                cob_Dept.SelectedIndex = 0;
            }
        }



        //cob_Register_Class
        DataTable dt_Register_Class = null;

        private void tab_Message_Registered_Enter(object sender, EventArgs e)
        {
            
            cob_Sex.Items.Add("M");
            cob_Sex.Items.Add("F");
            cob_Sex.SelectedIndex = 0;
            lal_psd.Text = "123321";
            lal_StuNo.Text = string.Empty;
            for (int i = 0; i < dt_DeptID.Rows.Count; i++)
            {
                cob_Register_Dept.Items.Add(dt_DeptID.Rows[i]["Department_Name"]);
            }
            cob_Register_Dept.SelectedIndex = 0;

            //读入cob_schoolName
            string Sqlstr_cob_Dept = "select * from dbo.school;";
            SqlHelper.RunSQLReturnDataTable(Sqlstr_cob_Dept, out dt_schoolName);
            cob_schoolName.Items.Add("不限");
            for (int i = 0; i < dt_schoolName.Rows.Count; i++)
            {
                cob_schoolName.Items.Add(dt_schoolName.Rows[i]["schoolName"]);
            }
            cob_schoolName.SelectedIndex = 0;


        }

        private void tab_Message_Registered_Leave(object sender, EventArgs e)
        {
            cob_Register_Dept.Items.Clear();
            cob_Register_Class.Items.Clear();
            cob_Sex.Items.Clear();
        }
        
        private void cob_Register_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Value = null;
            int index = cob_Register_Dept.SelectedIndex;
            Value = dt_DeptID.Rows[index]["Department_Id"].ToString().Trim();
            dt_Register_Class = new DataTable();
            string sqlstr = "select Class_Name,Class_Id from dbo.Classes where Department_Id=@Value;";
            GetStudentMessage(sqlstr, Value, out dt_Register_Class);
            cob_Register_Class.Items.Clear();
            if (dt_Register_Class.Rows.Count > 0)
            {
                for (int i = 0; i < dt_Register_Class.Rows.Count; i++)
                {
                    cob_Register_Class.Items.Add(dt_Register_Class.Rows[i]["Class_Name"]);
                }
            }
            cob_Register_Class.SelectedIndex = 0;
        }

        private void cob_Register_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (int)cob_Register_Dept.SelectedIndex;
            string strMaxStuNo = GetCurrentMaxStuNo(dt_DeptID.Rows[index]["Department_Id"].ToString().Trim());
            lal_StuNo.Text = GetNextStuNo(strMaxStuNo);
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

        public string GetCurrentMaxStuNo(string department_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select max(s.StuNo) as maxStuNo ");
            builder.Append("from Student as s inner join Classes as c on s.ClassId = c.Class_Id ");
            builder.Append("where c.Department_Id = @deptId");

            SqlParameter[] parms = {
                new SqlParameter("@deptId",SqlDbType.Char)
            };

            parms[0].Value = department_id;

            return SqlHelper.RunSQLReturnString(builder.ToString(), parms);
        }

        private string GetNextStuNo(string currentStuNo)
        {
            string pattern = "^0+";
            string StuPrefix = currentStuNo.Substring(0, 3);
            string StuNo = currentStuNo.Substring(3, 3);
            StuNo = StuNo.Replace(Regex.Match(StuNo, pattern).Value, string.Empty);
            int iNextValue = int.Parse(StuNo) + 1;
            string nextStuNo = iNextValue.ToString().PadLeft(3, '0');

            return StuPrefix + nextStuNo;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if(tet_Name.Text==""||tet_place.Text=="")
            {
                MessageBox.Show("请填写姓名或学号");
            }
            else
            {
                string sqlstr = null;
                sqlstr = "insert into dbo.Student values(@StuNo,@StuName,@StuPass_Word,@Sex,@ClassId,@Birthday,@Native_Place,@School);";
                SqlParameter[] parms =
                {
                new SqlParameter("@StuNo",SqlDbType.NChar),
                new SqlParameter("@StuName",SqlDbType.NChar),
                new SqlParameter("@StuPass_Word",SqlDbType.NChar),
                new SqlParameter("@Sex",SqlDbType.Char),
                new SqlParameter("@ClassId",SqlDbType.NChar),
                new SqlParameter("@Birthday",SqlDbType.SmallDateTime),
                new SqlParameter("@Native_Place",SqlDbType.NChar),
                new SqlParameter("@School",SqlDbType.NChar)

            };
                int index = cob_Register_Class.SelectedIndex;
                parms[0].Value = lal_StuNo.Text;
                parms[1].Value = tet_Name.Text;
                parms[2].Value = lal_psd.Text;
                parms[3].Value = cob_Sex.SelectedItem;
                parms[4].Value = dt_Register_Class.Rows[index]["Class_Id"].ToString().Trim();
                parms[5].Value = dateTimePicker_register.Value;
                parms[6].Value = tet_place.Text;

                string SchoolNO=null;
                //DataTable dt_schoolName = new DataTable();

                for (int i = 0; i < dt_ClassID.Rows.Count; i++)
                {
                    if (dt_schoolName.Rows[i]["schoolName"].ToString().Equals(cob_schoolName.SelectedItem.ToString()))
                    {
                        SchoolNO = dt_schoolName.Rows[i]["schoolNO"].ToString();
                        break;
                    }
                }
                parms[7].Value = SchoolNO;
                //


                SqlHelper.RunSQL(sqlstr, parms);
                tet_place.Text = "";
                tet_Name.Text = "";
                MessageBox.Show("添加成功");
            }
        }
    }
}
