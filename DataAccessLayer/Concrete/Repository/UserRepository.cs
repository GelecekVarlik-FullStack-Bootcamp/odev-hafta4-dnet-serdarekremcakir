using DataAccessLayer.Abstract;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {

        }


        public IQueryable<User> GetTotalReport()
        {
            return dbset.AsQueryable();
        }

        public User Login(User login)
        {
            string encrptPassword = MD5encrypt.MD5Pass(login.Password);
            var user = dbset.Where(x => x.UserEmail == login.UserEmail && x.Password == encrptPassword).SingleOrDefault();

            
            //var user = dbset.FirstOrDefault(x => x.UserCode == login.UserCode && x.Password == login.Password);

            //var user = dbset.SingleOrDefault(x => x.UserCode == login.UserCode && x.Password == login.Password)

            return user;
        }

        public User changePassword(string e, string y,int id)
        {
            string encryptOldPassword = MD5encrypt.MD5Pass(e);
            if (dbset.Where(x => x.UserID == id).SingleOrDefault().Password == encryptOldPassword)
            {
                dbset.Where(x => x.UserID == id).SingleOrDefault().Password = MD5encrypt.MD5Pass(y);
                return dbset.Where(x => x.UserID == id).SingleOrDefault();
            }
            else
            {
                return null;

            }

        }
        public User AddPerson (User item)
        {
            
            
            string mailpass = RandomPassword.GeneratePassword(true, true, true, true, 6);
            context.Entry(item).State = EntityState.Added;
            dbset.Add(item);


            MailMessage mailim = new MailMessage();
            mailim.To.Add("kimegonderilsin");
            mailim.From = new MailAddress("kimden gonderilsin");
            mailim.Subject = "Sifre";
            mailim.Body = "Kullanıcı Şifresi:" + mailpass;
            mailim.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-mail.outlook.com";
            smtp.Credentials = new NetworkCredential("gonderecemail", "gonderecekmailsifre");
            smtp.Port = 587;
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mailim);
            }
            catch (Exception ex)
            {

                throw;
            }



            item.Password = MD5encrypt.MD5Pass(mailpass);
            return item;
        }
    }
}
