using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Change
{
    class Change
    {
        public List<ChangeInfo>GetChange(string StuNo)
        {
            ChangeDataContext Cdb = new ChangeDataContext();
            var result = from c in Cdb.Change
                         where c.StuNo.Equals(StuNo)
                         select c;
            return result.ToList();
        }
        public List<ChangeInfo> GetChanges(string Change_Id)
        {
            ChangeDataContext Cdb = new ChangeDataContext();
            var result = from c in Cdb.Change
                         select c ;
            return result.ToList();
        }
    }
}
