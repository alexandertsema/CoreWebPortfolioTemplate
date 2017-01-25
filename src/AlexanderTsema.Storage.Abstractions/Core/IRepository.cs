using System.Collections.Generic;

namespace AlexanderTsema.Storage.Abstractions.Core
{
    public interface IRepository
    {
        void SetStorageContext(IStorageContext storageContext);
    }
}