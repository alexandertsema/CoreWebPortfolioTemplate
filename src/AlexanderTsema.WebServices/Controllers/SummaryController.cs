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
    public class SummaryController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        readonly ILogger<SummaryController> _log;

        public SummaryController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage, IMapper mapper, ILogger<SummaryController> log)
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
                var summaries = await this._storage.GetRepository<ISummaryRepository>().AllAsync();
                return
                    Ok(_mapper
                        .Map
                        <IEnumerable<Storage.Entities.Entities.Summary>,
                            IEnumerable<ViewModels.ViewModels.Summary>>
                            (summaries));
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
                var sumary = await this._storage.GetRepository<ISummaryRepository>().SingleAsync(id);
                return Ok(_mapper
                    .Map
                    <Storage.Entities.Entities.Summary,
                        ViewModels.ViewModels.Summary>(sumary));
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

//        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AlexanderTsema.ViewModels.ViewModels.Summary summary)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var enity =
                   _mapper
                       .Map
                       <ViewModels.ViewModels.Summary,
                           Storage.Entities.Entities.Summary>(summary);
                await  this._storage.GetRepository<ISummaryRepository>().CreateAsync(enity);
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
        public async Task<IActionResult> Put([FromBody]AlexanderTsema.ViewModels.ViewModels.Summary summary)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.Summary,
                            Storage.Entities.Entities.Summary>(summary);
                await this._storage.GetRepository<ISummaryRepository>().UpdateAsync(entity);
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
                if (await this._storage.GetRepository<ISummaryRepository>().DeleteAsync(id))
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
