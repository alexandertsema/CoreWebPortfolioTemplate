using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class ResumeController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        private readonly ILogger<ResumeController> _log;

        public ResumeController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage,
            IMapper mapper, ILogger<ResumeController> log)
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
                var resumes = await this._storage.GetRepository<IResumeRepository>().AllAsync();
                return
                    Ok(_mapper
                        .Map
                        <IEnumerable<Storage.Entities.Entities.Resume>,
                            IEnumerable<ViewModels.ViewModels.Resume>>
                            (resumes));
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
                var resume = await this._storage.GetRepository<IResumeRepository>().SingleAsync(id);
                return Ok(_mapper
                    .Map
                    <Storage.Entities.Entities.Resume,
                        ViewModels.ViewModels.Resume>(resume));
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

        //        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ViewModels.ViewModels.Resume resume)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var enity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.Resume,
                            Storage.Entities.Entities.Resume>(resume);
                await this._storage.GetRepository<IResumeRepository>().CreateAsync(enity);
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
        public async Task<IActionResult> Put([FromBody]ViewModels.ViewModels.Resume resume)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.Resume,
                            Storage.Entities.Entities.Resume>(resume);
                await this._storage.GetRepository<IResumeRepository>().UpdateAsync(entity);
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
                if (await this._storage.GetRepository<IResumeRepository>().DeleteAsync(id))
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
