using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginDemo;

namespace 学生信息管理系统
{
    public class Pulish : IOperate
    {
        public DataTable Operate(string deptId, string classId)
        {
            string sqlstr = null;
            DataTable dt = new DataTable();
            ///<summary>
            ///deptId == null && classId == null选择全部惩罚信息
            ///deptId != null && classId == null选择已选学院受罚学生信息
            ///deptId == null && classId != null选择已选班级受罚学生信息
            ///</summary>
            if (deptId == null && classId == null)
            {
                sqlstr = "select Punishment_Id 编号,s.StuNo 学号,StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述"
                    + " from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl "
                    + "where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code";
                GetAllMessage(sqlstr,out dt);
            }
           else if (deptId != null && classId == null)
            {
                sqlstr = "select Punishment_Id 编号, s.StuNo 学号,s.StuName 姓名,p.Create_Date 日期,"
                    +"pl.Punish_Descriptions 惩罚描述 from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl "
                    +"where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code and s.ClassId in" 
                    +"(select Class_Id from dbo.Classes where Department_Id = @Department_Id); ";
                GetStudentByDeptIdOrClassId(sqlstr, deptId, out dt);
            }
            else if(deptId == null && classId != null)
            {
                sqlstr = "select Punishment_Id 编号, s.StuNo 学号,s.StuName 姓名,p.Create_Date 日期,pl.Punish_Descriptions 惩罚描述"
                    +" from dbo.Student as s,dbo.Punishment as p,dbo.Punish_Levels_Config as pl "
                    +"where p.StuNo = s.StuNo and p.Punishment_Code = pl.Punish_Code and s.ClassId  = @Department_Id; ";
                GetStudentByDeptIdOrClassId(sqlstr, classId, out dt);
            }
            return dt;
        }

        public DataTable GetAllMessage(string sqlstr,out DataTable dt)
        {
            SqlHelper.RunSQLReturnDataTable(sqlstr, out dt);
            return dt;
        }

        public void GetStudentByDeptIdOrClassId(string SqlStr, string StrDept, out DataTable dt)
        {
            SqlParameter[] parms ={
                 new SqlParameter("@Department_Id",SqlDbType.NChar)
                };
            parms[0].Value = StrDept;
            SqlHelper.RunSQLReturnDataTable(SqlStr, out dt, parms);
        }

    }
}
