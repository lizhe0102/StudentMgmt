using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Change
{
    [Serializable]
    [Table(Name = "Change")]
    public class ChangeInfo
    {
        public ChangeInfo(string Change_Id,string StuNo,string Change_Code,DateTime Create_Data,string Change_Descriptions)
        {
            this.Change_Id = Change_Id;
            this.StuNo = StuNo;
            this.Change_Code = Change_Code;
            this.Create_Data = Create_Data;
            this.Change_Descriptions = Change_Descriptions;
        }
        [Column(IsPrimaryKey =true)]
        public string Change_Id { get; set; }
        public string StuNo { get; set; }
        public string Change_Code { get; set; }
        public DateTime Create_Data { get; set; }
        public string Change_Descriptions { get; set; }
    }
}
