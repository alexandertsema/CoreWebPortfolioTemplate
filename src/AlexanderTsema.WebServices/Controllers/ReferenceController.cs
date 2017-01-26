using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class ReferenceController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        public ReferenceController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }
        [HttpGet]
        public IEnumerable<AlexanderTsema.Storage.Entities.Entities.Reference> Get()
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceRepository>().All();
        }

        [HttpGet("{id}")]
        public AlexanderTsema.Storage.Entities.Entities.Reference Get(int id)
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceRepository>().Single(id);
        }

        [HttpPost]
        public void Post([FromBody]AlexanderTsema.Storage.Entities.Entities.Reference reference)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceRepository>().Create(reference);
        }

        [HttpPut("{id}")]
        public void Put([FromBody]AlexanderTsema.Storage.Entities.Entities.Reference reference)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceRepository>().Update(reference);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IReferenceRepository>().Delete(id);
        }
    }
}
