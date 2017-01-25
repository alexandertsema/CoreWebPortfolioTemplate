using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;

        public SkillController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }

        [HttpGet]
        public IEnumerable<AlexanderTsema.Storage.Entities.Entities.Skill> Get()
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().All();
        }

        [HttpGet("{id}")]
        public AlexanderTsema.Storage.Entities.Entities.Skill Get(int id)
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().Single(id);
        }

        [HttpPost]
        public void Post([FromBody]AlexanderTsema.Storage.Entities.Entities.Skill skill)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().Create(skill);
        }

        [HttpPut("{id}")]
        public void Put([FromBody]AlexanderTsema.Storage.Entities.Entities.Skill skill)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().Update(skill);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().Delete(id);
        }
    }
}
