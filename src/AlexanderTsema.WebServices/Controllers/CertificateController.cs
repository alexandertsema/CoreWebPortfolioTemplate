using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class CertificateController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        public CertificateController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }

        [HttpGet]
        public async Task<IEnumerable<AlexanderTsema.Storage.Entities.Entities.Certificate>> Get()
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICertificateRepository>().AllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Certificate> Get(int id)
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICertificateRepository>().SingleAsync(id);
        }

        //        [Authorize]
        [HttpPost]
        public async Task Post([FromBody]AlexanderTsema.Storage.Entities.Entities.Certificate certificate)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICertificateRepository>().CreateAsync(certificate);
        }

        //        [Authorize]
        [HttpPut("{id}")]
        public async Task Put([FromBody]AlexanderTsema.Storage.Entities.Entities.Certificate certificate)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICertificateRepository>().UpdateAsync(certificate);
        }

        //        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICertificateRepository>().DeleteAsync(id);
        }
    }
}
