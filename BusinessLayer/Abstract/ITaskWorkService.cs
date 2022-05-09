using EntityLayer.Dto;
using EntityLayer.IBase;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITaskWorkService: IGenericService<TaskWork,DtoTaskWork>
    {

        IResponse<IQueryable<DtoTaskWork>> GetTotalReport();
        public IResponse<List<DtoTaskListwithUser>> GetTaskswithUserDetails(string departmant);
    }
}
