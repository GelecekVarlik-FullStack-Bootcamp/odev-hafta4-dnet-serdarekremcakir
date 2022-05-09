using EntityLayer.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLayer.Abstract
{
    public interface IGenericService<T, TDto> where T:IEntityBase where TDto: IDtoBase
    {
        //Listeleme
        IResponse<List<TDto>> GetAll();

        //Filtreli listeleme
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression);

        //Getrime
        IResponse<TDto> Find(int id);

        //Kaydetme
        IResponse<TDto> Add(TDto item, bool saveChanges = true);

        //Async Kaydetme
        Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true);

        //Güncelleme
        IResponse<TDto> Update(TDto item, bool saveChanges = true);


        //Silme
        IResponse<bool> DeleteById(int id, bool saveChanges = true);

        //Async silme
        Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true);


        //IQueryable listeleme
        IResponse<IQueryable<TDto>> GetQueryable();

        void Save();
    }
}
