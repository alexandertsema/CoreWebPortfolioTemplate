using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Entities.Entities;

namespace AlexanderTsema.Storage.Abstractions.Core
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> SingleAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<Boolean> DeleteAsync(int id);
    }
}