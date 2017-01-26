using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class ReferenceAuthorController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        public ReferenceAuthorController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }
        [HttpGet]
        public IEnumerable<AlexanderTsema.Storage.Entities.Entities.ReferenceAuthor> Get()
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceAuthorRepository>().All();
        }

        [HttpGet("{id}")]
        public AlexanderTsema.Storage.Entities.Entities.ReferenceAuthor Get(int id)
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceAuthorRepository>().Single(id);
        }

        [HttpPost]
        public void Post([FromBody]AlexanderTsema.Storage.Entities.Entities.ReferenceAuthor referenceAuthor)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceAuthorRepository>().Create(referenceAuthor);
        }

        [HttpPut("{id}")]
        public void Put([FromBody]AlexanderTsema.Storage.Entities.Entities.ReferenceAuthor referenceAuthor)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceAuthorRepository>().Update(referenceAuthor);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceAuthorRepository>().Delete(id);
        }
    }
}
