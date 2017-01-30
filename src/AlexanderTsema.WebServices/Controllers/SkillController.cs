using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Entities.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;

        public SkillController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage, IMapper mapper)
        {
            this._storage = storage;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AlexanderTsema.Storage.Entities.Entities.Skill>> Get()
        {
            var skills = await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().AllAsync();
            return _mapper.Map<IEnumerable<Skill>, IEnumerable<Skill>>(skills);
        }

        [HttpGet("{id}")]
        public async Task<AlexanderTsema.Storage.Entities.Entities.Skill> Get(int id)
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().SingleAsync(id);
        }

//        [Authorize]
        [HttpPost]
        public async Task Post([FromBody]AlexanderTsema.Storage.Entities.Entities.Skill skill)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().CreateAsync(skill);
        }

//        [Authorize]
        [HttpPut("{id}")]
        public async Task Put([FromBody]AlexanderTsema.Storage.Entities.Entities.Skill skill)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().UpdateAsync(skill);
        }

//        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISkillRepository>().DeleteAsync(id);
        }
    }
}
