using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Entities.Entities;
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
            modelBuilder.Entity<Content>();
            modelBuilder.Entity<Certificate>();
            modelBuilder.Entity<Course>();
            modelBuilder.Entity<PortfolioItem>();
            modelBuilder.Entity<PortfolioItemCategory>();
            modelBuilder.Entity<Reference>();
            modelBuilder.Entity<ReferenceAuthor>();
            modelBuilder.Entity<School>();
            modelBuilder.Entity<Skill>();
            modelBuilder.Entity<SkillCategory>();
            modelBuilder.Entity<Summary>();
            modelBuilder.Entity<Resume>();
        }
    }
    /// <summary>
    /// Hot fix to allow migrations
    /// </summary>
    public class TemporaryDbContextFactory : IDbContextFactory<StorageContext>
    {
        public StorageContext Create(DbContextFactoryOptions options)
        {
            return new StorageContext(@"Data Source=ALEXANDER-DESKT\SQLEXPRESS;Initial Catalog=AlexanderTsema;Trusted_Connection=True;");
        }
    }
}