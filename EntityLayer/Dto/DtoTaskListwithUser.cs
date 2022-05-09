using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class DtoTaskListwithUser : DtoBase
    {
        public DtoTaskListwithUser()
        {
        }

        public int TaskID { get; set; }

        public string TaskTitle { get; set; }

        public string TaskDepartmant { get; set; }

        public DateTime TaskCreateTime { get; set; }

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserTelNo { get; set; }

    }
}
