using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class DtoUserToken : DtoBase
    {
        public DtoLoginUser DtoLoginUser { get; set; }
        public object AccessToken { get; set; }
        

    }
}
