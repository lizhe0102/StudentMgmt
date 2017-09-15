using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 学生信息管理系统
{
    public abstract class Factory
    {
        public static IOperate CreateOperate(string operateType)
        {
            IOperate operate = null;
            if (operateType.Equals("惩罚信息查询"))
            {
                operate = new Pulish();
            }
            else if (operateType.Equals("奖励信息查询"))
            {
                operate = new Rewarded();
            }
            else if (operateType.Equals("学生奖励审批"))
            {
                operate = new ConformReward();
            }
            else
            {
                operate = new Changed();
            }
            return operate;
        }
    }
}
