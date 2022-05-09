using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using EntityLayer.Models;
using EntityLayer.Dto;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.IBase;
using EntityLayer.Base;

namespace BusinessLayer.Concrete
{
    public class UserManager : GenericManager<User, DtoUser>, IUserService
    {
        public readonly IUserRepository userRepository;
        public readonly ITaskWorkRepository taskworkRepository;
        private IConfiguration configuration;

        public UserManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
            taskworkRepository = service.GetService<ITaskWorkRepository>();
            this.configuration = configuration;
        }

    
        public IResponse<DtoUserToken> Login(DtoLogin login)
        {
            var user = userRepository.Login(ObjectMapper.Mapper.Map<User>(login));
            if (user != null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoLoginUser>(user);

                var token = new TokenManager(configuration).CreateAccessToken(dtoUser);

                var userToken = new DtoUserToken()
                {
                    DtoLoginUser = dtoUser,
                    AccessToken = token
                };

                return new Response<DtoUserToken>
                {
                    Message = "Token üretildi - Giriş Başarılı",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<DtoUserToken>
                {
                    Message = "Parola yanlış",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }
        public IResponse<DtoUser> changePassword(string e, string y, int id,bool saveChanges = true)
        {
            try
            {

                //var model = ObjectMapper.Mapper.Map<User>(item);
          

                var result = userRepository.changePassword(e,y,id);


                if (saveChanges)
                {
                    Save(); // kaydetme işlemi olduğundan transaction'ı commitliyoruz.
                }

                if (result == null)
                {
                    
                    return new Response<DtoUser>
                    {
                        StatusCode = StatusCodes.Status406NotAcceptable,
                        Message = $"Error: valid password is incorrect",
                        Data = null
                    };
                }

                //dönüş tipini ayarlıyoruz
                return new Response<DtoUser>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<User, DtoUser>(result)
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri seti
                return new Response<DtoUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
        public IResponse<DtoUser> AddXX(DtoUser item, bool saveChanges = true)
        {
            try
            {
                //dto verisi model(T) tipine dönüştürülüyor.
                //sebebi:dal T ile çalışır.

                var model = ObjectMapper.Mapper.Map<User>(item);
                //var resolvesResult = "";
                

                var result = userRepository.AddPerson(model);
                

                if (saveChanges)
                {
                    Save(); // kaydetme işlemi olduğundan transaction'ı commitliyoruz.
                }

                //dönüş tipini ayarlıyoruz
                return new Response<DtoUser>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<User, DtoUser>(result)
                };
            }
            catch (Exception ex)
            {
                //hata olma durumunda dönecek veri seti
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
