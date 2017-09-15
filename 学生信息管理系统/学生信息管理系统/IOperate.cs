using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace 学生信息管理系统
{
     public interface IOperate
    {
        DataTable Operate(string deptId,string classId);
    }
}
