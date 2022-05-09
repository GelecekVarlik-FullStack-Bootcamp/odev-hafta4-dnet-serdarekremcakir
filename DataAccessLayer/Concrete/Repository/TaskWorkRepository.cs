using DataAccessLayer.Abstract;
using EntityLayer.Dto;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class TaskWorkRepository : GenericRepository<TaskWork>, ITaskWorkRepository
    {
        protected DbSet<User> userdbset;
        public TaskWorkRepository(DbContext context) : base(context)
        {
            this.userdbset = this.context.Set<User>();
        }

        public List<TaskWork> GetAllTask(Expression<Func<TaskWork, bool>> expression)
        {
            
            return dbset.Where(expression).ToList();

        }

        IQueryable<TaskWork> ITaskWorkRepository.GetTotalReport()
        {
            return dbset.AsQueryable();
        }

        public List<DtoTaskListwithUser> GetTaskswithUserDetails(string departmant)
        {
            

            return dbset.Where(x => x.TaskWorkDepartment == departmant).ToList().Join(userdbset, taskwork => taskwork.UserID
            , user => user.UserID, (taskwork, user) => new DtoTaskListwithUser
            {
                TaskID = taskwork.TaskWorkID,
                TaskTitle = taskwork.TaskWorkTitle,
                TaskDepartmant = taskwork.TaskWorkDepartment,
                TaskCreateTime = taskwork.TaskCreateTime,
                UserName = user.UserName,
                UserSurname = user.UserSurname,
                UserEmail = user.UserEmail,
                UserTelNo = user.UserTelNo

            }
            ).ToList();
        }

    }
}
