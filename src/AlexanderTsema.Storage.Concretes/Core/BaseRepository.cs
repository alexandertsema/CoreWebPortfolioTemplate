using System;
using System.Collections.Generic;
using AlexanderTsema.Storage.Abstractions.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Concretes.Helpers;
using AlexanderTsema.Storage.Entities.Entities;

namespace AlexanderTsema.Storage.Concretes.Core
{
    /// <summary>
    /// Basic CRUD functionality
    /// Waiting for Lazy Load to be added to Core. Now IncludeAll extension is used to reproduce lazy load with eager load of each virtual property.
    /// </summary>
    /// <typeparam name="TEntity">TEntity</typeparam>
    /// <typeparam name="TKey">Id PK</typeparam>
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity
        where TKey : struct
    {
        protected StorageContext StorageContext;
        protected DbSet<TEntity> DbSet;

        public void SetStorageContext(IStorageContext storageContext)
        {
            this.StorageContext = storageContext as StorageContext;
            var context = this.StorageContext;
            if (context != null) this.DbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> All() => DbSet;


        public async Task<IQueryable<TEntity>> AllEagerAsync() => 
            await Task.Run(() => DbSet.IncludeAll());

        public virtual async Task<TEntity> SingleAsync(TKey id) => 
            await DbSet.FindAsync(id);

        public virtual async Task<TEntity> SingleEagerAsync(TKey id) =>
            await DbSet.Where(x => x.Id.Equals(id))
                .IncludeAll()
                .SingleOrDefaultAsync();

        public virtual async Task CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await StorageContext.SaveChangesAsync();
        }

        public virtual async Task<Boolean> UpdateAsync(TEntity entity)
        {
            var dbEntry = await DbSet.FindAsync(entity.Id);
            if (dbEntry == null) return false;
            await Task.Run(() => {
                StorageContext.Entry(dbEntry).State = EntityState.Modified;
            });
            await StorageContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<Boolean> UpdateEagerAsync(TEntity entity) => await Task.Run(async () => //todo: get rid of reflections
        {
            var dbEntry = await
                DbSet.Where(
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
            await StorageContext.SaveChangesAsync();
            return true;
        });
        
        public virtual async Task<Boolean> DeleteAsync(TKey id)
        {
            var dbEntry = await DbSet.FindAsync(id);
            if (dbEntry == null) return false;
            await Task.Run(() =>
            {
                DbSet.Remove(dbEntry);
            });
            await StorageContext.SaveChangesAsync();
            return true;
        }
        
        public virtual async Task<bool> DeleteEagerAsync(TKey id)
        {
            var dbEntry = await
                DbSet.Where(x => x.Id.Equals(id))
                    .IncludeAll()
                    .SingleOrDefaultAsync();
            if (dbEntry == null) return false;
            await Task.Run(() =>
            {
                DbSet.Remove(dbEntry);
            });
            await StorageContext.SaveChangesAsync();
            return true;
        }
    }
}