using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlexanderTsema.Storage.Abstractions.Core
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> SingleAsync(int id);
        Task CreateAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(int id);
    }
}