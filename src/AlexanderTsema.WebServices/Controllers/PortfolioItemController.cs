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
    public class PortfolioItemController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;
        private readonly IMapper _mapper;
        private readonly ILogger<PortfolioItemController> _log;

        public PortfolioItemController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage,
            IMapper mapper, ILogger<PortfolioItemController> log)
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
                var portfolioItem = await this._storage.GetRepository<IPortfolioItemRepository>().AllAsync();
                return
                    Ok(_mapper
                        .Map
                        <IEnumerable<Storage.Entities.Entities.PortfolioItem>,
                            IEnumerable<ViewModels.ViewModels.PortfolioItem>>
                            (portfolioItem));
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
                var portfolioItem = await this._storage.GetRepository<IPortfolioItemRepository>().SingleAsync(id);
                return Ok(_mapper
                    .Map
                    <Storage.Entities.Entities.PortfolioItem,
                        ViewModels.ViewModels.PortfolioItem>(portfolioItem));
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

//        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ViewModels.ViewModels.PortfolioItem portfolioItem)
        {
            if (!ModelState.IsValid) return StatusCode((int) HttpStatusCode.BadRequest, ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.PortfolioItem,
                            Storage.Entities.Entities.PortfolioItem>(portfolioItem);
                await this._storage.GetRepository<IPortfolioItemRepository>().CreateAsync(entity);
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
        public async Task<IActionResult> Put([FromBody]ViewModels.ViewModels.PortfolioItem portfolioItem)
        {
            if (!ModelState.IsValid) return StatusCode((int) HttpStatusCode.BadRequest, ModelState);
            try
            {
                var entity =
                    _mapper
                        .Map
                        <ViewModels.ViewModels.PortfolioItem,
                            Storage.Entities.Entities.PortfolioItem>(portfolioItem);
                if (await this._storage.GetRepository<IPortfolioItemRepository>().UpdateAsync(entity))
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
                if (await this._storage.GetRepository<IPortfolioItemRepository>().DeleteAsync(id))
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
