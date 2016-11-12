using System.Collections.Generic;
using System.Linq;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Entities.Models;
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
            return this._courseDbSet.Include(x=>x.School).OrderBy(i => i.Id);
        }

        public Course Single(int id)
        {
            return this._courseDbSet.Where(x => x.Id == id).Include(x => x.School).SingleOrDefault();
        }

        public void Create(Course course)
        {
            this._courseDbSet.Add(course);
            this._storageContext.SaveChanges();
        }

        public void Update(Course course)
        {
            var dbEntry = this._courseDbSet.SingleOrDefault(x => x.Id == course.Id);
            if (dbEntry != null)
            {
                dbEntry.Name = course.Name;
                dbEntry.School = course.School;
            }
            this._storageContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbEntry = this._courseDbSet.SingleOrDefault(x => x.Id == id);
            if (dbEntry != null)
            {
                this._courseDbSet.Remove(dbEntry);
                this._storageContext.SaveChanges();
            }
        }
    }
}