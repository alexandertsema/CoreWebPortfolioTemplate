using System.Collections.Generic;
using System.Linq;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private StorageContext _storageContext;
        private DbSet<Course> _courseDbSet;

        public void SetStorageContext(IStorageContext storageContext)
        {
            this._storageContext = storageContext as StorageContext;
            var context = this._storageContext;
            if (context != null) this._courseDbSet = context.Set<Course>();
        }

        public IEnumerable<Course> All()
        {
            return this._courseDbSet.OrderBy(i => i.Id);
        }

        public Course Single(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Course course)
        {
            this._courseDbSet.Add(course);
            this._courseDbSet.Save();
        }

        public void Update(Course course)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}