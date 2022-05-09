using EntityLayer.Dto;
using EntityLayer.IBase;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IGenericService<User, DtoUser>
    {
        IResponse<DtoUserToken> Login(DtoLogin login);
        IResponse<DtoUser> AddXX(DtoUser item, bool saveChanges = true);
        IResponse<DtoUser> changePassword(string e, string y, int id, bool saveChanges = true);
    }
}
