using EntityLayer.Base;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class DtoTaskWork :DtoBase
    {
        public DtoTaskWork()
        {
            this.TaskCreateTime = DateTime.Now;
        }

        public int TaskWorkID { get;} //
        public string TaskWorkTitle { get; set; }  //
        public string TaskWorkContent { get; set; }  //
        public string TaskWorkDepartment { get; set; } //
        public string TaskWorkDepTopic { get; set; } //
        public int TaskWorkPriority { get; set; } //
        public DateTime TaskWorkStart { get; set; } //
        public DateTime TaskWorkEnd { get; set; } //
        public bool TaskWorkStatus { get; set; }

        public DateTime TaskCreateTime { get; } //

        public int UserID { get; set; }

    }
}
