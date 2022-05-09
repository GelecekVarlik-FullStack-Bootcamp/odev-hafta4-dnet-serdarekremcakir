using AutoMapper.Internal.Mappers;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Base;
using EntityLayer.Dto;
using EntityLayer.IBase;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApi.Base;





namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiBaseController<IUserService, User, DtoUser>
    {
        private readonly ITaskWorkService taskWorkService;

        private readonly IUserService userService;
        public UserController(IUserService userService , ITaskWorkService taskWorkService) : base(userService)
        {
            this.userService = userService;
            this.taskWorkService = taskWorkService;

        }



        [HttpPost("ChangePassword")]
        public IResponse<DtoUser> GeneratePassword(string currentpassword,string newpassword)
        {

            try
            {
                var userid = User.FindFirst("Jti").Value;
                return userService.changePassword(currentpassword, newpassword, Int32.Parse(userid));
            }
            
                
      
            catch (Exception ex)
            {
                return new Response<DtoUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IResponse<DtoUserToken> Login(DtoLogin login)
        {
            try
            {
                return userService.Login(login);
            }
            catch (Exception ex)
            {

                return new Response<DtoUserToken>
                {
                    Message = "Error" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPost("AddPerson"), Authorize(Roles = "Admin,Yonetici")]
        public IResponse<DtoUser> AddPerson(DtoUser entity)
        {
            try
            {
                return userService.AddXX(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }


    }
}
