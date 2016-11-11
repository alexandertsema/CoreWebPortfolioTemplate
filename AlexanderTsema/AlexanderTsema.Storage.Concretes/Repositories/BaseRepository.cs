using System.Collections.Generic;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Concretes.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
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
            return this.DbSet.SingleOrDefault(x => (short) x.GetType().GetProperty("Id").GetValue(x) == id);
        }

        public void Create(T obj)
        {
            this.DbSet.Add(obj);
            this.StorageContext.SaveChanges();
        }

        public void Update(T obj)
        {
            var dbEntry = this.DbSet.SingleOrDefault(x => (short) x.GetType().GetProperty("Id").GetValue(x) == (short) obj.GetType().GetProperty("Id").GetValue(obj));
            if (dbEntry != null)
            {
                foreach (var property in dbEntry.GetType().GetProperties())
                {
                    var dbEntryProperty = dbEntry.GetType().GetProperty(property.Name);
                    var objValue = obj.GetType().GetProperty(property.Name).GetValue(obj);
                    if (property.Name != "Id" && dbEntryProperty.GetValue(dbEntry).GetHashCode() != objValue.GetHashCode())
                        dbEntryProperty.SetValue(dbEntry, objValue);
                }
                this.StorageContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            //var dbEntry = this._courseDbSet.SingleOrDefault(x => x.Id == id);
            //if (dbEntry != null)
            //{
            //    this._courseDbSet.Remove(dbEntry);
            //    this._storageContext.SaveChanges();
            //}
        }
    }
}