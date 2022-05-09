using EntityLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EntityLayer.Models
{
    public class TaskWork :EntityBase
    {
        [Key]
        public int TaskWorkID { get; set; }
        public string TaskWorkTitle { get; set; }
        public string TaskWorkContent { get; set; }
        public string TaskWorkDepartment { get; set; }
        public string TaskWorkDepTopic { get; set; }
        public int TaskWorkPriority { get; set; }
        public DateTime TaskWorkStart { get; set; }
        public DateTime TaskWorkEnd { get; set; }
        public bool TaskWorkStatus { get; set; }

        public DateTime TaskCreateTime { get; set; }

        public User User { get; set; }

        

        public int UserID { get; set; }

        
    }
}
