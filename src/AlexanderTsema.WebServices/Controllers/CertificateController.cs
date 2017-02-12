using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class CertificateController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        private readonly ILogger<CertificateController> _log;

        public CertificateController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage,
            IMapper mapper, ILogger<CertificateController> log)
        {
            this._storage = storage;
            this._mapper = mapper;
            this._log = log;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var certificates = await this._storage.GetRepository<ICertificateRepository>().AllAsync();
                return
                    Ok(_mapper
                        .Map
                        <IEnumerable<Storage.Entities.Entities.Certificate>,
                            IEnumerable<ViewModels.ViewModels.Certificate>>
                            (certificates));
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(short id)
        {
            try
            {
                var certificate = await this._storage.GetRepository<ICertificateRepository>().SingleAsync(id);
                return Ok(_mapper
                    .Map
                    <Storage.Entities.Entities.Certificate,
                        ViewModels.ViewModels.Certificate>(certificate));
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        //        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AlexanderTsema.ViewModels.ViewModels.Certificate certificate)
        {
            if (!ModelState.IsValid) return StatusCode((int) HttpStatusCode.BadRequest, ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.Certificate,
                            Storage.Entities.Entities.Certificate>(certificate);
                await this._storage.GetRepository<ICertificateRepository>().CreateAsync(entity);
                return StatusCode((int) HttpStatusCode.Created, entity);
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        //        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]AlexanderTsema.ViewModels.ViewModels.Certificate certificate)
        {
            if (!ModelState.IsValid) return StatusCode((int) HttpStatusCode.BadRequest, ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.Certificate,
                            Storage.Entities.Entities.Certificate>(certificate);
                if (await this._storage.GetRepository<ICertificateRepository>().UpdateAsync(entity))
                    return StatusCode((int)HttpStatusCode.OK);
                return StatusCode((int)HttpStatusCode.NotModified);
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        //        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            try
            {
                if (await this._storage.GetRepository<ICertificateRepository>().DeleteAsync(id))
                    return StatusCode((int)HttpStatusCode.OK);
                return StatusCode((int) HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }
    }
}
