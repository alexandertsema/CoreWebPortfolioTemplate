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
    /// Waiting for Lazy Load to be added to Core. Now IncludeAll extension is used to reproduce lazy load.
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

        public virtual async Task<IQueryable<TEntity>> AllAsync() =>
            await Task.Run(() => this.DbSet.OrderBy(i => i.GetType().GetRuntimeProperty("Id").GetValue(i)).IncludeAll());

        public virtual async Task<TEntity> FindSingleAsync(TKey id) => await this.DbSet.FindAsync(id);

        public virtual async Task<TEntity> SingleAsync(TKey id)
        {
            var result = await this.DbSet.Where(x => x.Id.Equals(id))
                .IncludeAll()
                .SingleOrDefaultAsync();
            return result;
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await this.DbSet.AddAsync(entity);
            await this.StorageContext.SaveChangesAsync();
        }

        public virtual async Task<Boolean> UpdateAsync(TEntity entity) => await Task.Run(async () =>
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

        public virtual async Task<Boolean> DeleteAsync(TKey id) => await Task.Run(async () =>
        {
            var dbEntry = await 
                this.DbSet.Where(x => x.Id.Equals(id))
                    .IncludeAll()
                    .SingleOrDefaultAsync();
            if (dbEntry == null) return false;
            this.DbSet.Remove(dbEntry);
            await this.StorageContext.SaveChangesAsync();
            return true;
        });

        public Task<IQueryable<TEntity>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAllAsync(TKey id)
        {
            throw new NotImplementedException();
        }
    }
}