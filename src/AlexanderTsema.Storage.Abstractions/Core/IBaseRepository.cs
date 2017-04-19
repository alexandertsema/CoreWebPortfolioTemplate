using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Entities.Entities;

namespace AlexanderTsema.Storage.Abstractions.Core
{
    public interface IBaseRepository<TEntity, in TKey>
    {
        IQueryable<TEntity> All();
        Task<IQueryable<TEntity>> AllEagerAsync();
        Task<TEntity> SingleAsync(TKey id);
        Task<TEntity> SingleEagerAsync(TKey id);
        Task CreateAsync(TEntity entity);
        Task<Boolean> UpdateAsync(TEntity entity);
        Task<Boolean> UpdateEagerAsync(TEntity entity);
        Task<Boolean> DeleteAsync(TKey id);
        Task<Boolean> DeleteEagerAsync(TKey id);
    }
}