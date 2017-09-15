using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Change
{
    [Database(Name = "StuMgt")]
    class ChangeDataContext: System.Data.Linq.DataContext
    {
        public ChangeDataContext()
            : base("server=(localdb)\\ProjectsV12;database=StuMgt;uid=;pwd=")
        {

        }

        public Table<ChangeInfo> Change
        {
            get { return this.GetTable<ChangeInfo>(); }
        }
    }
}
