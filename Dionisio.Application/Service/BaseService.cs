using AutoMapper;
using Dionisio.Application.Interface.Repository;
using Dionisio.Application.Interface.Sevice;
using Dionisio.Domain.Entities.Base;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Application.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<T> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        async Task<List<T>> IBaseService<T>.Get()
        {
            var result = _baseRepository.SelectAll();
            return await result.ToListAsync();
        }

        Task<T> IBaseService<T>.Add(T obj)
        {
            _baseRepository.Insert(obj);
            return Task.FromResult(obj);
        }

        Task<T> IBaseService<T>.Add<TValidator>(T obj)
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return Task.FromResult(obj);
        }

        Task<bool> IBaseService<T>.Delete(Guid id)
        {
            _baseRepository.Delete(id);
            return Task.FromResult(true);
        }

        public Task<T?> GetFirst()
        {
            var result = _baseRepository.SelectAll();
            return result.FirstOrDefaultAsync();
        }

        Task<T?> IBaseService<T>.GetById(Guid id)
        {
            return Task.FromResult(_baseRepository.Select(id));
        }

        Task<T> IBaseService<T>.Update(T obj)
        {
            _baseRepository.Update(obj);
            return Task.FromResult(obj);
        }

        Task<T> IBaseService<T>.Update<TValidator>(T obj)
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return Task.FromResult(obj);
        }

        protected void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
