using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class PortfolioItemController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        public PortfolioItemController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }
        [HttpGet]
        public IEnumerable<AlexanderTsema.Storage.Entities.Entities.PortfolioItem> Get()
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().All();
        }

        [HttpGet("{id}")]
        public AlexanderTsema.Storage.Entities.Entities.PortfolioItem Get(int id)
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().Single(id);
        }

        [HttpPost]
        public void Post([FromBody]AlexanderTsema.Storage.Entities.Entities.PortfolioItem portfolioItem)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().Create(portfolioItem);
        }

        [HttpPut("{id}")]
        public void Put([FromBody]AlexanderTsema.Storage.Entities.Entities.PortfolioItem portfolioItem)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().Update(portfolioItem);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().Delete(id);
        }
    }
}
