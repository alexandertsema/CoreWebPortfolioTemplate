using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AlexanderTsema.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly AlexanderTsema.Storage.Abstractions.Core.IStorage _storage;

        public CourseController(AlexanderTsema.Storage.Abstractions.Core.IStorage storage)
        {
            this._storage = storage;
        }
        
        [HttpGet]
        public async Task<IEnumerable<AlexanderTsema.Storage.Entities.Entities.Course>> Get()
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().AllAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<AlexanderTsema.Storage.Entities.Entities.Course> Get(int id)
        {
            return await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().SingleAsync(id);
        }

//        [Authorize]
        [HttpPost]
        public async Task Post([FromBody]AlexanderTsema.Storage.Entities.Entities.Course course)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().CreateAsync(course);
        }

//        [Authorize]
        [HttpPut("{id}")]
        public async Task Put([FromBody]AlexanderTsema.Storage.Entities.Entities.Course course)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().UpdateAsync(course);
        }

//        [Authorize]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().DeleteAsync(id);
        }
    }
}
