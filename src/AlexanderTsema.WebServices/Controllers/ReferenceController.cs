using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class ReferenceController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        private readonly ILogger<ReferenceController> _log;

        public ReferenceController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage,
            IMapper mapper, ILogger<ReferenceController> log)
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
                var references = await this._storage.GetRepository<IReferenceRepository>().AllAsync();
                return
                    Ok(_mapper
                        .Map
                        <IEnumerable<Storage.Entities.Entities.Reference>,
                            IEnumerable<ViewModels.ViewModels.Reference>>
                            (references));
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var reference = await this._storage.GetRepository<IReferenceRepository>().SingleAsync(id);
                return Ok(_mapper
                    .Map
                    <Storage.Entities.Entities.Reference,
                        ViewModels.ViewModels.Reference>(reference));
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

//        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AlexanderTsema.ViewModels.ViewModels.Reference reference)
        {
            if (!ModelState.IsValid) return StatusCode((int) HttpStatusCode.BadRequest, ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.Reference,
                            Storage.Entities.Entities.Reference>(reference);
                await this._storage.GetRepository<IReferenceRepository>().CreateAsync(entity);
                return StatusCode((int)HttpStatusCode.Created, entity);
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

//        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]AlexanderTsema.ViewModels.ViewModels.Reference reference)
        {
            if (!ModelState.IsValid) return StatusCode((int) HttpStatusCode.BadRequest, ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.Reference,
                            Storage.Entities.Entities.Reference>(reference);
                if (await this._storage.GetRepository<IReferenceRepository>().UpdateAsync(entity))
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await this._storage.GetRepository<IReferenceRepository>().DeleteAsync(id))
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
