using AutoMapper;
using EntityLayer.Dto;
using EntityLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskWork, DtoTaskWork>().ReverseMap();
            CreateMap<User, DtoUser>().ReverseMap();

            CreateMap<User, DtoLoginUser>();
            CreateMap<DtoLogin, User>();

           



        }
    }
}
