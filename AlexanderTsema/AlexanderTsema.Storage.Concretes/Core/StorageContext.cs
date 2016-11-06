using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Models.Models;
using Microsoft.EntityFrameworkCore;

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
}