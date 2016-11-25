using System.Collections.Generic;

namespace AlexanderTsema.Storage.Abstractions.Core
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> All();
        T Single(int id);
        void Create(T model);
        void Update(T model);
        void Delete(int id);
    }
}