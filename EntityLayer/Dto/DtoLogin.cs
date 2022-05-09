using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class DtoLogin : DtoBase
    {
        [Required]
        [StringLength(maximumLength:40)]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
