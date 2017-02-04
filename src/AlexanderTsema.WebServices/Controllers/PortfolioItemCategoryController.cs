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
    public class PortfolioItemCategoryController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        private readonly ILogger<PortfolioItemCategoryController> _log;

        public PortfolioItemCategoryController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage,
            IMapper mapper, ILogger<PortfolioItemCategoryController> log)
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
                var portfolioItemCategories = await this._storage.GetRepository<IPortfolioItemCategoryRepository>().AllAsync();
                return
                    Ok(_mapper
                        .Map
                        <IEnumerable<Storage.Entities.Entities.PortfolioItemCategory>,
                            IEnumerable<ViewModels.ViewModels.PortfolioItemCategory>>
                            (portfolioItemCategories));
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
                var portfolioItemCategory = await this._storage.GetRepository<IPortfolioItemCategoryRepository>().SingleAsync(id);
                return Ok(_mapper
                    .Map
                    <Storage.Entities.Entities.PortfolioItemCategory,
                        ViewModels.ViewModels.PortfolioItemCategory>(portfolioItemCategory));
            }
            catch (Exception e)
            {
                _log.LogInformation(e.ToString());
                return StatusCode(500);
            }
        }

        //        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ViewModels.ViewModels.PortfolioItemCategory portfolioItemCategory)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var enity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.PortfolioItemCategory,
                            Storage.Entities.Entities.PortfolioItemCategory>(portfolioItemCategory);
                await this._storage.GetRepository<IPortfolioItemCategoryRepository>().CreateAsync(enity);
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
        public async Task<IActionResult> Put([FromBody]ViewModels.ViewModels.PortfolioItemCategory portfolioItemCategory)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.PortfolioItemCategory,
                            Storage.Entities.Entities.PortfolioItemCategory>(portfolioItemCategory);
                await this._storage.GetRepository<IPortfolioItemCategoryRepository>().UpdateAsync(entity);
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
                if (await this._storage.GetRepository<IPortfolioItemCategoryRepository>().DeleteAsync(id))
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
