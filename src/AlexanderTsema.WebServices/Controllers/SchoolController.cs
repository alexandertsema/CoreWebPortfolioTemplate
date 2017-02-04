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
    public class SchoolController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        private readonly ILogger<SchoolController> _log;

        public SchoolController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage, IMapper mapper, ILogger<SchoolController> log)
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
                var school = await this._storage.GetRepository<ISchoolRepository>().AllAsync();
                return
                    Ok(_mapper
                         .Map
                            <IEnumerable<Storage.Entities.Entities.School>, IEnumerable<ViewModels.ViewModels.School>>(school));
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
                var school = await this._storage.GetRepository<ISchoolRepository>().SingleAsync(id);
                return Ok(_mapper.Map<Storage.Entities.Entities.School, ViewModels.ViewModels.School>(school));
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

//        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ViewModels.ViewModels.School school)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var enity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.School,
                            Storage.Entities.Entities.School>(school);
                await this._storage.GetRepository<ISchoolRepository>().CreateAsync(enity);
                return Ok();
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

//        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ViewModels.ViewModels.School school)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.School,
                            Storage.Entities.Entities.School>(school);
                await this._storage.GetRepository<ISchoolRepository>().UpdateAsync(entity);
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
                if (await this._storage.GetRepository<ISchoolRepository>().DeleteAsync(id))
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
