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
        public async Task<IEnumerable<AlexanderTsema.Storage.Entities.Entities.PortfolioItem>> Get()
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().All();
        }

        [HttpGet("{id}")]
        public async Task<AlexanderTsema.Storage.Entities.Entities.PortfolioItem> Get(int id)
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().Single(id);
        }

        [HttpPost]
        public async Task Post([FromBody]AlexanderTsema.Storage.Entities.Entities.PortfolioItem portfolioItem)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().Create(portfolioItem);
        }

        [HttpPut("{id}")]
        public async Task Put([FromBody]AlexanderTsema.Storage.Entities.Entities.PortfolioItem portfolioItem)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().Update(portfolioItem);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IPortfolioItemRepository>().Delete(id);
        }
    }
}
