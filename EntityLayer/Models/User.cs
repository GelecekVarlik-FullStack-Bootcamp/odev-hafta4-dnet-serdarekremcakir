using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class User : EntityBase
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserSurname { get; set; }
        [Required]
        public string UserEmail { get; set; }
        public string UserTelNo { get; set; }

        [Required]
        public string UserDepartmant { get; set; }

        
        public string UserAuthorization { get; set; }


        public string Password { get; set; }
        public List<TaskWork> TaskWorks { get; set; }
    }
}
