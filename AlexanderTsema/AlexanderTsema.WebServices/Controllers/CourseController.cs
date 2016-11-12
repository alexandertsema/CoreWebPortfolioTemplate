using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<AlexanderTsema.Storage.Entities.Models.Course> Get()
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().All();
        }
        
        [HttpGet("{id}")]
        public AlexanderTsema.Storage.Entities.Models.Course Get(int id)
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().Single(id);
        }
        
        [HttpPost]
        public void Post([FromBody]AlexanderTsema.Storage.Entities.Models.Course course)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().Create(course);
        }
        
        [HttpPut("{id}")]
        public void Put([FromBody]AlexanderTsema.Storage.Entities.Models.Course course)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().Update(course);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().Delete(id);
        }
    }
}
