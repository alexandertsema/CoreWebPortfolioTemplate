using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class ReferenceAuthorController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        private readonly ILogger<ReferenceAuthorController> _log;

        public ReferenceAuthorController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage,
            IMapper mapper, ILogger<ReferenceAuthorController> log)
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
                var referenceAuthors = await this._storage.GetRepository<IReferenceAuthorRepository>().AllAsync();
                return
                    Ok(_mapper
                        .Map
                        <IEnumerable<Storage.Entities.Entities.ReferenceAuthor>,
                            IEnumerable<ViewModels.ViewModels.ReferenceAuthor>>
                            (referenceAuthors));
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var referenceAuthor = await this._storage.GetRepository<IReferenceAuthorRepository>().SingleAsync(id);
                return Ok(_mapper
                    .Map
                    <Storage.Entities.Entities.ReferenceAuthor,
                        ViewModels.ViewModels.ReferenceAuthor>(referenceAuthor));
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

//        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ViewModels.ViewModels.ReferenceAuthor referenceAuthor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var enity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.ReferenceAuthor,
                            Storage.Entities.Entities.ReferenceAuthor>(referenceAuthor);
                await this._storage.GetRepository<IReferenceAuthorRepository>().CreateAsync(enity);
                return Ok();
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

//        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]ViewModels.ViewModels.ReferenceAuthor referenceAuthor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.ReferenceAuthor,
                            Storage.Entities.Entities.ReferenceAuthor>(referenceAuthor);
                await this._storage.GetRepository<IReferenceAuthorRepository>().UpdateAsync(entity);
                return Ok();
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

//        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await this._storage.GetRepository<IReferenceAuthorRepository>().DeleteAsync(id))
                    return Ok();
                return NotFound();
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }
    }
}
