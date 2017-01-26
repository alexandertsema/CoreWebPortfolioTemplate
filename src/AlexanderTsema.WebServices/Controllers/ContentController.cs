using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<AlexanderTsema.Storage.Entities.Entities.Content> Get()
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().All();
        }

        [HttpGet("{id}")]
        public AlexanderTsema.Storage.Entities.Entities.Content Get(int id)
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().Single(id);
        }

        [HttpPost]
        public void Post([FromBody]AlexanderTsema.Storage.Entities.Entities.Content content)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().Create(content);
        }

        [HttpPut("{id}")]
        public void Put([FromBody]AlexanderTsema.Storage.Entities.Entities.Content content)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().Update(content);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IContentRepository>().Delete(id);
        }
    }
}
