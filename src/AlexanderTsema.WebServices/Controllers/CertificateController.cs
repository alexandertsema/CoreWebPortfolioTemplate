using System.Collections.Generic;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class CertificateController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        public CertificateController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage, IMapper mapper)
        {
            this._storage = storage;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var certificates = await this._storage.GetRepository<ICertificateRepository>().AllAsync();
            return
                Ok(_mapper
                        .Map
                        <IEnumerable<AlexanderTsema.Storage.Entities.Entities.Certificate>,
                            IEnumerable<AlexanderTsema.ViewModels.ViewModels.Certificate>>(certificates));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var certificate = await this._storage.GetRepository<ICertificateRepository>().SingleAsync(id);
            return Ok(_mapper
                            .Map
                            <AlexanderTsema.Storage.Entities.Entities.Certificate,
                                AlexanderTsema.ViewModels.ViewModels.Certificate>(certificate));
        }

        //        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AlexanderTsema.ViewModels.ViewModels.Certificate certificate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var enity =
                _mapper
                    .Map
                    <AlexanderTsema.ViewModels.ViewModels.Certificate,
                        AlexanderTsema.Storage.Entities.Entities.Certificate>(certificate);
            await this._storage.GetRepository<ICertificateRepository>().CreateAsync(enity);
            return Ok();
        }

        //        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]AlexanderTsema.ViewModels.ViewModels.Certificate certificate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var entity =
                _mapper
                    .Map
                    <AlexanderTsema.ViewModels.ViewModels.Certificate,
                        AlexanderTsema.Storage.Entities.Entities.Certificate>(certificate);
            await this._storage.GetRepository<ICertificateRepository>().UpdateAsync(entity);
            return Ok();
        }

        //        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this._storage.GetRepository<ICertificateRepository>().DeleteAsync(id);
            return Ok();
        }
    }
}
