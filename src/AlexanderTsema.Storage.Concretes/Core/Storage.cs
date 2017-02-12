using System;
using  System.Reflection;
using AlexanderTsema.Storage.Abstractions.Core;

namespace AlexanderTsema.Storage.Concretes.Core
{
    public class Storage : IStorage
    {
        public StorageContext StorageContext { get; private set; }

        public Storage()
        {
            this.StorageContext = new StorageContext(@"Data Source=ALEXANDER-DESKT\SQLEXPRESS;Initial Catalog=AlexanderTsema;Trusted_Connection=True;"); //todo: move to appsettings
        }

        public TEntity GetRepository<TEntity>() where TEntity : IRepository
        {
            foreach (var type in this.GetType().GetTypeInfo().Assembly.ExportedTypes)
            {
                if (typeof(TEntity).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()) && type.GetTypeInfo().IsClass)
                {
                    TEntity repository = (TEntity)Activator.CreateInstance(type);

                    repository.SetStorageContext(this.StorageContext);
                    return repository;
                }
            }

            return default(TEntity);
        }

        public void Save()
        {
            this.StorageContext.SaveChanges();
        }
    }
}