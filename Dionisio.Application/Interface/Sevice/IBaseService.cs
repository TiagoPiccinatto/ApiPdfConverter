using Dionisio.Domain.Entities.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Application.Interface.Sevice
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Add(T obj);
        Task<T> Add<TValidator>(T obj) where TValidator : AbstractValidator<T>;
        Task<bool> Delete(Guid id);
        Task<T?> GetFirst();
        Task<List<T>> Get();
        Task<T?> GetById(Guid id);
        Task<T> Update<TValidator>(T obj) where TValidator : AbstractValidator<T>;
        Task<T> Update(T obj);
    }
}
