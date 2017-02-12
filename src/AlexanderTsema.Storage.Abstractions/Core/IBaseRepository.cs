using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Entities.Entities;

namespace AlexanderTsema.Storage.Abstractions.Core
{
    public interface IBaseRepository<TEntity, in TKey>
    {
        Task<IQueryable<TEntity>> AllAsync();
        Task<IQueryable<TEntity>> FindAllAsync();
        Task<TEntity> SingleAsync(TKey id);
        Task<TEntity> FindSingleAsync(TKey id);
        Task CreateAsync(TEntity entity);
        Task<Boolean> UpdateAsync(TEntity entity);
        Task<Boolean> DeleteAsync(TKey id);
        Task<Boolean> DeleteAllAsync(TKey id);
    }
}