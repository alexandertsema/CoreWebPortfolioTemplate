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
            this.StorageContext = new StorageContext(@"Data Source=DESKTOP-47CKMKT\SQLEXPRESS;Initial Catalog=AlexanderTsema;Trusted_Connection=True;");
        }

        public T GetRepository<T>() where T : IRepository
        {
            foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
            {
                if (typeof(T).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                {
                    T repository = (T)Activator.CreateInstance(type);

                    repository.SetStorageContext(this.StorageContext);
                    return repository;
                }
            }

            return default(T);
        }

        public void Save()
        {
            this.StorageContext.SaveChanges();
        }
    }
}