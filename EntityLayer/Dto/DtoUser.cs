using EntityLayer.Base;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class DtoUser : DtoBase
    {
        public DtoUser()
        {
            this.UserAuthorization = "Personel";
        }
        public int UserID { get; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserTelNo { get; set; }
        public string UserDepartmant { get; set; }
        public string UserAuthorization { get;}

        
    }
}
