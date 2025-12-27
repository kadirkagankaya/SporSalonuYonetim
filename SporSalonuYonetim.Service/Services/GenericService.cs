using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading.Tasks;
using SporSalonuYonetim.Core.DTOs;
using SporSalonuYonetim.Core.Entities;
using SporSalonuYonetim.Core.Interfaces;

namespace SporSalonuYonetim.Service.Services
{
    public class GenericService<T> : IService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<T>> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return ServiceResponse<T>.SuccessResult(entity, 201);
        }

        public async Task<ServiceResponse<IEnumerable<T>>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var list = await _repository.FindAsync(predicate);
            return ServiceResponse<IEnumerable<T>>.SuccessResult(list);
        }

        public async Task<ServiceResponse<IEnumerable<T>>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return ServiceResponse<IEnumerable<T>>.SuccessResult(list);
        }

        public async Task<ServiceResponse<T>> GetByIdAsync(Guid id)
        {
            var hasProduct = await _repository.GetByIdAsync(id);

            if (hasProduct == null)
            {
                return ServiceResponse<T>.FailResult("Kayıt bulunamadı", 404);
            }

            return ServiceResponse<T>.SuccessResult(hasProduct);
        }

        public async Task<ServiceResponse<bool>> RemoveAsync(Guid id)
        {
            var hasProduct = await _repository.GetByIdAsync(id);

            if (hasProduct == null)
            {
                return ServiceResponse<bool>.FailResult("Kayıt bulunamadı", 404);
            }

            _repository.Remove(hasProduct);
            await _unitOfWork.CommitAsync();
            return ServiceResponse<bool>.SuccessResult(true, 204);
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return ServiceResponse<bool>.SuccessResult(true, 204);
        }
    }
}
