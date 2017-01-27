using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        public ContentController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }

        [HttpGet]
        public async Task<IEnumerable<AlexanderTsema.Storage.Entities.Entities.Content>> Get()
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().All();
        }

        [HttpGet("{id}")]
        public async Task<Content> Get(int id)
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().Single(id);
        }

//        [Authorize]
        [HttpPost]
        public async Task Post([FromBody]AlexanderTsema.Storage.Entities.Entities.Content content)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().Create(content);
        }

//        [Authorize]
        [HttpPut("{id}")]
        public async Task Put([FromBody]AlexanderTsema.Storage.Entities.Entities.Content content)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().Update(content);
        }

//        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().Delete(id);
        }
    }
}
