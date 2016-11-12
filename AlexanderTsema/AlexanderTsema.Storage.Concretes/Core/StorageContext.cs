using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AlexanderTsema.Storage.Concretes.Core
{
    public class StorageContext : DbContext, IStorageContext
    {
        private readonly string _connectionString;

        public StorageContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(this._connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<School>();
            modelBuilder.Entity<Course>();
        }
    }
    /// <summary>
    /// Hot fix to allow migrations
    /// </summary>
    public class TemporaryDbContextFactory : IDbContextFactory<StorageContext>
    {
        public StorageContext Create(DbContextFactoryOptions options)
        {
            return new StorageContext(@"Data Source=DESKTOP-47CKMKT\SQLEXPRESS;Initial Catalog=AlexanderTsema;Trusted_Connection=True;");
        }
    }
}