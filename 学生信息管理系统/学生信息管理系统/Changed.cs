﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginDemo;

namespace 学生信息管理系统
{
    public class Changed : IOperate
    {
        public DataTable Operate(string deptId, string classId)
        {
            string sqlstr = null;
            DataTable dt = new DataTable();
            ///<summary>
            ///deptId == null && classId == null选择全部改变信息
            ///deptId != null && classId == null选择已选学院改变学生信息
            ///deptId == null && classId != null选择已选班级改变学生信息
            ///</summary>
            if (deptId == null && classId == null)
            {
                sqlstr = "select Reward_Id 编号, s.StuNo 学号,s.StuName 姓名,r.Create_Date 日期,"+
                    "rl.Reward_Descriptions 奖励描述 from dbo.Student as s,dbo.Reward as r,dbo.Reward_Levels_Config "+
                    "as rl where r.StuNo = s.StuNo and r.Reward_Code = rl.Reward_Code and r.ReWard_Condition=0";
                GetAllMessage(sqlstr, out dt);
            }
            else if (deptId != null && classId == null)
            {
                sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions "+
                    "学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo and"+
                    " c.Change_Code = cc.Change_Code and s.ClassId in (select Class_Id from dbo.Classes "+
                    "where Department_Id = @Department_Id); ";

                GetStudentByDeptIdOrClassId(sqlstr, deptId, out dt);
            }
            else if (deptId == null && classId != null)
            {
                sqlstr = "select Change_Id 编号, s.StuNo 学号,s.StuName 姓名,c.Create_Date 日期,cc.Change_Descriptions "+
                    "学籍描述 from dbo.Student as s,dbo.Change as c,dbo.Change_Config as cc where c.StuNo = s.StuNo "+
                    "and c.Change_Code = cc.Change_Code and s.ClassId  = @Department_Id; ";

                GetStudentByDeptIdOrClassId(sqlstr, classId, out dt);
            }
            return dt;
        }

        public DataTable GetAllMessage(string sqlstr, out DataTable dt)
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
