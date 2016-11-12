using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class SchoolController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;

        public SchoolController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }
        
        [HttpGet]
        public IEnumerable<AlexanderTsema.Storage.Entities.Models.School> Get()
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().All();
        }
        
        [HttpGet("{id}")]
        public AlexanderTsema.Storage.Entities.Models.School Get(int id)
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().Single(id);
        }
        
        [HttpPost]
        public void Post([FromBody]AlexanderTsema.Storage.Entities.Models.School school)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().Create(school);
        }
        
        [HttpPut]
        public void Put([FromBody]AlexanderTsema.Storage.Entities.Models.School school)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().Update(school);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().Delete(id);
        }
    }
}
