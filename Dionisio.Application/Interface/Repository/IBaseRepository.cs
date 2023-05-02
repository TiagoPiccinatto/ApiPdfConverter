using Dionisio.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Application.Interface.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        bool Insert(T obj);
        bool Update(T obj);
        bool Delete(Guid id);
        IQueryable<T> SelectAll();
        T? Select(Guid id);
    }
}
