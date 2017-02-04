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
    public class SkillCategoryController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        private readonly ILogger<SkillCategoryController> _log;

        public SkillCategoryController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage,
            IMapper mapper, ILogger<SkillCategoryController> log)
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
                var skillCatalogs = await this._storage.GetRepository<ISkillCategoryRepository>().AllAsync();
                return
                    Ok(_mapper
                         .Map
                            <IEnumerable<Storage.Entities.Entities.SkillCategory>, 
                            IEnumerable<ViewModels.ViewModels.SkillCategory>>(skillCatalogs));
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
                var skillCatalog = await this._storage.GetRepository<ISkillCategoryRepository>().SingleAsync(id);
                return
                    Ok(_mapper
                         .Map
                            <Storage.Entities.Entities.SkillCategory,
                            ViewModels.ViewModels.SkillCategory>(skillCatalog));
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

        //        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ViewModels.ViewModels.SkillCategory skillCategory)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var enity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.SkillCategory,
                            Storage.Entities.Entities.SkillCategory>(skillCategory);
                await this._storage.GetRepository<ISkillCategoryRepository>().CreateAsync(enity);
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
        public async Task<IActionResult> Put([FromBody]ViewModels.ViewModels.SkillCategory skillCategory)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.SkillCategory,
                            Storage.Entities.Entities.SkillCategory>(skillCategory);
                await this._storage.GetRepository<ISkillCategoryRepository>().UpdateAsync(entity);
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
                if (await this._storage.GetRepository<ISkillCategoryRepository>().DeleteAsync(id))
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
