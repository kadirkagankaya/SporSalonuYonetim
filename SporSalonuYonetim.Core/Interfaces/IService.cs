using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SporSalonuYonetim.Core.DTOs;
using SporSalonuYonetim.Core.Entities;

namespace SporSalonuYonetim.Core.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        Task<ServiceResponse<T>> GetByIdAsync(Guid id);
        Task<ServiceResponse<IEnumerable<T>>> GetAllAsync();
        Task<ServiceResponse<IEnumerable<T>>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<ServiceResponse<T>> AddAsync(T entity);
        Task<ServiceResponse<bool>> RemoveAsync(Guid id);
        Task<ServiceResponse<bool>> UpdateAsync(T entity);
    }
}
