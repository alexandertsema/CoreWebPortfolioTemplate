using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlexanderTsema.Storage.Abstractions.Core
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> All();
        Task<T> Single(int id);
        Task Create(T model);
        Task Update(T model);
        Task Delete(int id);
    }
}