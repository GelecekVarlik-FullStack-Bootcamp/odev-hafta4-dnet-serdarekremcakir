using EntityLayer.Dto;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITaskWorkRepository
    {
        IQueryable<TaskWork> GetTotalReport();
        List<TaskWork> GetAllTask(Expression<Func<TaskWork, bool>> expression);
        public List<DtoTaskListwithUser> GetTaskswithUserDetails(string departmant);
    }
}
