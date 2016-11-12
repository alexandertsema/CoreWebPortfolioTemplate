using System;
using System.Collections.Generic;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Concretes.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Query;

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
            var val = this.DbSet.Where(x => (short)x.GetType().GetProperty("Id").GetValue(x) == id).IncludeAllChildren().SingleOrDefault();
            return val;
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
    public static class Extension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static IEnumerable<TEntity> IncludeAllChildren<TEntity>(this IQueryable<TEntity> source) where TEntity : class
        {
            IEnumerable<TEntity> query = null;
            foreach (var item in source)
            {
                foreach (var propperty in item.GetType().GetProperties())
                {
                    var val = propperty.PropertyType;
                    query = source.Include(x => x.GetType().GetProperty(val.Name).GetValue(x));
                }
            }
            return query;
        }
    }
}