using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class SummaryController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        public SummaryController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }

        [HttpGet]
        public async Task<IEnumerable<AlexanderTsema.Storage.Entities.Entities.Summary>> Get()
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISummaryRepository>().All();
        }

        [HttpGet("{id}")]
        public async Task<AlexanderTsema.Storage.Entities.Entities.Summary> Get(int id)
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISummaryRepository>().Single(id);
        }

//        [Authorize]
        [HttpPost]
        public async Task Post([FromBody]AlexanderTsema.Storage.Entities.Entities.Summary summary)
        {
            await  this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISummaryRepository>().Create(summary);
        }

//        [Authorize]
        [HttpPut("{id}")]
        public async Task Put([FromBody]AlexanderTsema.Storage.Entities.Entities.Summary summary)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISummaryRepository>().Update(summary);
        }

//        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ISummaryRepository>().Delete(id);
        }
    }
}
