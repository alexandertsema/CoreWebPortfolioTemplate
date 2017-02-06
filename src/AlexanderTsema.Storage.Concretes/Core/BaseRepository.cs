using System;
using System.Collections.Generic;
using AlexanderTsema.Storage.Abstractions.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Concretes.Helpers;

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

        public virtual async Task<IEnumerable<T>> AllAsync() =>
            await Task.Run(() => this.DbSet.OrderBy(i => i.GetType().GetRuntimeProperty("Id").GetValue(i)).IncludeAll());
        
        public virtual async Task<T> SingleAsync(int id) =>
            await Task.Run(
                async () =>
                    await this.DbSet.Where(x => (short) x.GetType().GetRuntimeProperty("Id").GetValue(x) == id)
                        .IncludeAll()
                        .SingleOrDefaultAsync());
  
        public virtual async Task CreateAsync(T entity) => await Task.Run(async () =>
        {
            await this.DbSet.AddAsync(entity);
            await this.StorageContext.SaveChangesAsync();
        });

        public virtual async Task<Boolean> UpdateAsync(T entity) => await Task.Run(async () =>
        {
            var dbEntry = await
                this.DbSet.Where(
                        x =>
                            (short) x.GetType().GetRuntimeProperty("Id").GetValue(x) ==
                            (short) entity.GetType().GetRuntimeProperty("Id").GetValue(entity))
                    .IncludeAll()
                    .SingleOrDefaultAsync();
            if (dbEntry == null) return false;
            foreach (var property in dbEntry.GetType().GetRuntimeProperties())
            {
                var dbEntryProperty = dbEntry.GetType().GetRuntimeProperty(property.Name);
                var objValue = entity.GetType().GetRuntimeProperty(property.Name).GetValue(entity);

                if (property.Name == "Id") continue;
                if (dbEntryProperty.GetValue(dbEntry) != null && objValue != null)
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
            await this.StorageContext.SaveChangesAsync();
            return true;
        });

        public virtual async Task<Boolean> DeleteAsync(int id) => await Task.Run(async () =>
        {
            var dbEntry = await 
                this.DbSet.Where(x => (short) x.GetType().GetRuntimeProperty("Id").GetValue(x) == id)
                    .IncludeAll()
                    .SingleOrDefaultAsync();
            if (dbEntry == null) return false;
            this.DbSet.Remove(dbEntry);
            await this.StorageContext.SaveChangesAsync();
            return true;
        });
    }
}