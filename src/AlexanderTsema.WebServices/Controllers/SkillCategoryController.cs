using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class SkillCategoryController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;

        public SkillCategoryController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }

        [HttpGet]
        public async Task<IEnumerable<AlexanderTsema.Storage.Entities.Entities.SkillCategory>> Get()
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillCategoryRepository>().AllAsync();
        }

        [HttpGet("{id}")]
        public async Task<AlexanderTsema.Storage.Entities.Entities.SkillCategory> Get(int id)
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillCategoryRepository>().SingleAsync(id);
        }

        //        [Authorize]
        [HttpPost]
        public async Task Post([FromBody]AlexanderTsema.Storage.Entities.Entities.SkillCategory skillCategory)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillCategoryRepository>().CreateAsync(skillCategory);
        }

        //        [Authorize]
        [HttpPut("{id}")]
        public async Task Put([FromBody]AlexanderTsema.Storage.Entities.Entities.SkillCategory skillCategory)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillCategoryRepository>().UpdateAsync(skillCategory);
        }

        //        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillCategoryRepository>().DeleteAsync(id);
        }
    }
}
