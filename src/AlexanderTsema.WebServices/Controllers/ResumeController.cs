using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class ResumeController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        public ResumeController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }

        [HttpGet]
        public async Task<IEnumerable<AlexanderTsema.Storage.Entities.Entities.Resume>> Get()
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IResumeRepository>().AllAsync();
        }

        [HttpGet("{id}")]
        public async Task<AlexanderTsema.Storage.Entities.Entities.Resume> Get(int id)
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IResumeRepository>().SingleAsync(id);
        }

        //        [Authorize]
        [HttpPost]
        public async Task Post([FromBody]AlexanderTsema.Storage.Entities.Entities.Resume resume)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IResumeRepository>().CreateAsync(resume);
        }

        //        [Authorize]
        [HttpPut("{id}")]
        public async Task Put([FromBody]AlexanderTsema.Storage.Entities.Entities.Resume resume)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IResumeRepository>().UpdateAsync(resume);
        }

        //        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.IResumeRepository>().DeleteAsync(id);
        }
    }
}
