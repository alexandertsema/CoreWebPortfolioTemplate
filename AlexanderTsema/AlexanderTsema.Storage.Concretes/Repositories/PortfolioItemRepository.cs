using System.Collections.Generic;
using System.Linq;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
    public class PortfolioItemRepository : IPortfolioItemRepository
    {
        private StorageContext _storageContext;
        private DbSet<PortfolioItem> _portfolioItemDbSet;

        public void SetStorageContext(IStorageContext storageContext)
        {
            this._storageContext = storageContext as StorageContext;
            var context = this._storageContext;
            if (context != null) this._portfolioItemDbSet = context.Set<PortfolioItem>();
        }

        public IEnumerable<PortfolioItem> All()
        {
            return this._portfolioItemDbSet.Include(x=>x.PortfolioItemType).OrderBy(i => i.Id);
        }

        public PortfolioItem Single(int id)
        {
            return this._portfolioItemDbSet.Where(x => x.Id == id).Include(x => x.PortfolioItemType).SingleOrDefault();
        }

        public void Create(PortfolioItem portfolioItem)
        {
            this._portfolioItemDbSet.Add(portfolioItem);
            this._storageContext.SaveChanges();
        }

        public void Update(PortfolioItem portfolioItem)
        {
            var dbEntry = this._portfolioItemDbSet.SingleOrDefault(x => x.Id == portfolioItem.Id);
            if (dbEntry != null)
            {
                dbEntry.Name = portfolioItem.Name;
                dbEntry.Description = portfolioItem.Description;
                dbEntry.Image = portfolioItem.Image;
                dbEntry.Link = portfolioItem.Link;
                dbEntry.PortfolioItemType = portfolioItem.PortfolioItemType;
            }
            this._storageContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbEntry = this._portfolioItemDbSet.SingleOrDefault(x => x.Id == id);
            if (dbEntry != null)
            {
                this._portfolioItemDbSet.Remove(dbEntry);
                this._storageContext.SaveChanges();
            }
        }
    }
}