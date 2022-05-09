using BusinessLayer.Abstract;
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
using WebApi.Base;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskWorkController : ApiBaseController<ITaskWorkService, TaskWork, DtoTaskWork>
    {
        
        private readonly ITaskWorkService taskworkService;
        public TaskWorkController(ITaskWorkService taskworkService) : base(taskworkService)
        {
            this.taskworkService = taskworkService;
        }

        [HttpGet("GetTotalReport")] //abc.com/api/customer/GetTotalReport
        [AllowAnonymous]
        public IResponse<IQueryable<DtoTaskWork>> GetTotalReport()
        {
            try
            {
                return taskworkService.GetTotalReport();
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

        [HttpPost("AddTask")]
        public IResponse<DtoTaskWork> Addx(DtoTaskWork entity)
        {
            try
            {
                var userid = User.FindFirst("Jti").Value;
                entity.UserID = Int32.Parse(userid);
                return taskworkService.Add(entity);
            }
            catch (Exception ex)
            {
                return new Response<DtoTaskWork>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }


        [HttpGet("TaskListwithUserDetails")]
        public IResponse<List<DtoTaskListwithUser>> TaskListwithUserDetails()
        {
            try
            {
                var userdepartmant = User.Identity.Name;

       
                
                return taskworkService.GetTaskswithUserDetails(userdepartmant);
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


    }
}
