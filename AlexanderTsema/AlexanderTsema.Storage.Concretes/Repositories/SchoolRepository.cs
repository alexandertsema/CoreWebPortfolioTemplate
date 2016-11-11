using System.Collections.Generic;
using System.Linq;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
    public class SchoolRepository : BaseRepository<School>, ISchoolRepository
    {
        
        //private StorageContext _storageContext;
        //private DbSet<School> _schoolDbSet;

        //public void SetStorageContext(IStorageContext storageContext)
        //{
        //    this._storageContext = storageContext as StorageContext;
        //    var context = this._storageContext;
        //    if (context != null)
        //        this._schoolDbSet = context.Set<School>();
        //}

        //public IEnumerable<School> All()
        //{
        //    return this._schoolDbSet.Include(x => x.Courses).OrderBy(i => i.Id);
        //}

        //public School Single(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void Create(School school)
        //{
        //    this._schoolDbSet.Add(school);
        //}

        //public void Update(School school)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void Delete(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}