using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer.Abstract
{
    public interface IUserRepository
    {
        public User Login(User login);
        public User AddPerson(User item);
        public User changePassword(string e, string y,int id);
    }
}