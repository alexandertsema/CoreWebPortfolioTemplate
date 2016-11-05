using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTsema.Storage.Concretes.Core
{
    public class StorageContext : DbContext, IStorageContext
    {
        private string connectionString;

        public StorageContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(this.connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<School>();
        }
    }
}