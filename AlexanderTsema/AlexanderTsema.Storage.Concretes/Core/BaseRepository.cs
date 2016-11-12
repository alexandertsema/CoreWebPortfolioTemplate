using System;
using System.Collections.Generic;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Concretes.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AlexanderTsema.Storage.Concretes.Core
{
    /// <summary>
    /// waiting for Lazy Load to be added to Core
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
            return this.DbSet.OrderBy(i => i.GetType().GetProperty("Id").GetValue(i));
        }

        public T Single(int id)
        {
            return this.DbSet.SingleOrDefault(x => (short)x.GetType().GetProperty("Id").GetValue(x) == id);
        }

        public void Create(T obj)
        {
            this.DbSet.Add(obj);
            this.StorageContext.SaveChanges();
        }

        public void Update(T obj)
        {
            var dbEntry = this.DbSet.SingleOrDefault(x => (short)x.GetType().GetProperty("Id").GetValue(x) == (short)obj.GetType().GetProperty("Id").GetValue(obj));
            if (dbEntry != null)
            {
                foreach (var property in dbEntry.GetType().GetProperties())
                {
                    var dbEntryProperty = dbEntry.GetType().GetProperty(property.Name);
                    var objValue = obj.GetType().GetProperty(property.Name).GetValue(obj);
                    if (property.Name != "Id" && dbEntryProperty.GetValue(dbEntry).GetHashCode() != objValue.GetHashCode()) //todo: check for null
                        dbEntryProperty.SetValue(dbEntry, objValue);
                }
                this.StorageContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var dbEntry = this.DbSet.SingleOrDefault(x => (short)x.GetType().GetProperty("Id").GetValue(x) == id);
            if (dbEntry != null)
            {
                this.DbSet.Remove(dbEntry);
                this.StorageContext.SaveChanges();
            }
        }
    }
}