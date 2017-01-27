using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IEnumerable<AlexanderTsema.Storage.Entities.Entities.School>> Get()
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().All();
        }
        
        [HttpGet("{id}")]
        public async Task<AlexanderTsema.Storage.Entities.Entities.School> Get(int id)
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().Single(id);
        }

//        [Authorize]
        [HttpPost]
        public async Task Post([FromBody]AlexanderTsema.Storage.Entities.Entities.School school)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().Create(school);
        }

//        [Authorize]
        [HttpPut]
        public async Task Put([FromBody]AlexanderTsema.Storage.Entities.Entities.School school)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().Update(school);
        }

//        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISchoolRepository>().Delete(id);
        }
    }
}
