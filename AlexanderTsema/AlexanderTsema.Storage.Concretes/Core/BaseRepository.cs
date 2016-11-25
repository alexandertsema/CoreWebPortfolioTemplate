using System;
using System.Collections.Generic;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Concretes.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using AlexanderTsema.Storage.Concretes.Helpers;
using Microsoft.EntityFrameworkCore.Query;

namespace AlexanderTsema.Storage.Concretes.Core
{
    /// <summary>
    /// Basic CRUD functionality
    /// Waiting for Lazy Load to be added to Core. Now IncludeAll extension is used to reproduce lazy load.
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public abstract class BaseRepository<T> where T : class
    {
        protected StorageContext StorageContext;
        protected DbSet<T> DbSet;

        public void SetStorageContext(IStorageContext storageContext)
        {
            this.StorageContext = storageContext as StorageContext;
            var context = this.StorageContext;
            if (context != null) this.DbSet = context.Set<T>();
        }

        public IEnumerable<T> All()
        {
            return this.DbSet.OrderBy(i => i.GetType().GetProperty("Id").GetValue(i)).IncludeAll();
        }

        public T Single(int id)
        {
            var val = this.DbSet.Where(x => (short)x.GetType().GetProperty("Id").GetValue(x) == id).IncludeAll().SingleOrDefault();
            return val;
        }

        public void Create(T entity)
        {
            this.DbSet.Add(entity);
            this.StorageContext.SaveChanges();
        }

        public void Update(T entity)
        {
            var dbEntry = this.DbSet.Where(x => (short)x.GetType().GetProperty("Id").GetValue(x) == (short)entity.GetType().GetProperty("Id").GetValue(entity)).IncludeAll().SingleOrDefault();
            if (dbEntry != null)
            {
                foreach (var property in dbEntry.GetType().GetProperties())
                {
                    var dbEntryProperty = dbEntry.GetType().GetProperty(property.Name);
                    var objValue = entity.GetType().GetProperty(property.Name).GetValue(entity);

                    if (property.Name == "Id") continue;
                    if (dbEntryProperty.GetValue(dbEntry) != null && objValue != null )
                    {
                        if (dbEntryProperty.GetValue(dbEntry).GetHashCode() != objValue.GetHashCode())
                        {
                            dbEntryProperty.SetValue(dbEntry, objValue);
                        }
                    }
                    else
                    {
                        dbEntryProperty.SetValue(dbEntry, objValue);
                    }
                }
                this.StorageContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var dbEntry = this.DbSet.Where(x => (short)x.GetType().GetProperty("Id").GetValue(x) == id).IncludeAll().SingleOrDefault();
            if (dbEntry != null)
            {
                this.DbSet.Remove(dbEntry);
                this.StorageContext.SaveChanges();
            }
        }
    }
}