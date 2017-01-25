using System.Collections.Generic;
using System.Linq;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
    public class SchoolRepository : BaseRepository<School>, ISchoolRepository //BaseRepository<School>,
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
        //    return this._schoolDbSet.Where(x => x.Id == id).Include(x=>x.Courses).SingleOrDefault();
        //}

        //public void Create(School school)
        //{
        //    this._schoolDbSet.Add(school);
        //    this._storageContext.SaveChanges();
        //}

        //public void Update(School school)
        //{
        //    var dbEntry = this._schoolDbSet.Where(x => x.Id == school.Id).Include(x => x.Courses).SingleOrDefault();
        //    if (dbEntry != null)
        //    {
        //        dbEntry.Name = school.Name;
        //        dbEntry.Description = school.Description;
        //        dbEntry.Degree = school.Degree;
        //        dbEntry.StartDate = school.StartDate;
        //        dbEntry.EndDate = school.EndDate;
        //        dbEntry.GraduationWork = school.GraduationWork;
        //        dbEntry.Gpa = school.Gpa;
        //        dbEntry.Courses = school.Courses;
        //    }
        //    this._storageContext.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var dbEntry = this._schoolDbSet.Where(x => x.Id == id).Include(x => x.Courses).SingleOrDefault();
        //    if (dbEntry != null)
        //    {
        //        this._schoolDbSet.Remove(dbEntry);
        //        this._storageContext.SaveChanges();
        //    }
        //}
    }
}