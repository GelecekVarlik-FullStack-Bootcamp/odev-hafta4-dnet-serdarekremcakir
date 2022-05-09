using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Dto;
using EntityLayer.IBase;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using EntityLayer.Base;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class TaskWorkManager : GenericManager<TaskWork, DtoTaskWork>, ITaskWorkService
    {
        public readonly ITaskWorkRepository taskWorkRepository;
        public readonly IUserRepository userRepository;
        public TaskWorkManager(IServiceProvider service) : base(service)
        {
            taskWorkRepository = service.GetService<ITaskWorkRepository>();
            userRepository = service.GetService<IUserRepository>();
        }

        public IResponse<List<DtoTaskListwithUser>> GetTaskswithUserDetails(string departmant)
        {
            try
            {
                var tasklist = taskWorkRepository.GetTaskswithUserDetails(departmant);

                return new Response<List<DtoTaskListwithUser>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = tasklist
                };

            }
            catch (Exception ex)
            {

                return new Response<List<DtoTaskListwithUser>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }


        public IResponse<IQueryable<DtoTaskWork>> GetTotalReport()
        {


            try
            {
                var list = taskWorkRepository.GetTotalReport();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoTaskWork>(x));
                return new Response<IQueryable<DtoTaskWork>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };

            }
            catch (Exception ex)
            {

                return new Response<IQueryable<DtoTaskWork>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

    }
}
