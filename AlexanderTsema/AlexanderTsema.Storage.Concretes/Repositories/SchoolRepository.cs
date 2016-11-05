using System.Collections.Generic;
using System.Linq;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private StorageContext _storageContext;
        private DbSet<School> _dbSet;

        public void SetStorageContext(IStorageContext storageContext)
        {
            this._storageContext = storageContext as StorageContext;
            this._dbSet = this._storageContext.Set<School>();
        }

        public IEnumerable<School> All()
        {
            return this._dbSet.OrderBy(i => i.Id);
        }
    }
}