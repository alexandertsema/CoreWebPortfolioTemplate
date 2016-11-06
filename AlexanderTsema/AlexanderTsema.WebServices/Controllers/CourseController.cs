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

        // GET api/values
        [HttpGet]
        public IEnumerable<AlexanderTsema.Storage.Models.Models.Course> Get()
        {
            return this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(AlexanderTsema.Storage.Models.Models.Course course)
        {
            this._storage.GetRepository<AlexanderTsema.Storage.Abstractions.Repositories.ICourseRepository>().Create(course);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
