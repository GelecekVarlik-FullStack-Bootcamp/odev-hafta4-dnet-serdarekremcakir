using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class DtoLoginUser : DtoBase
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserAuthorization { get; set; }
        public string UserDepartmant { get; set; }

        public string UserEmail { get; set; }
    }
}
