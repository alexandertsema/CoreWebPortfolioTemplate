using System.Collections.Generic;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Models.Models;

namespace AlexanderTsema.Storage.Abstractions.Repositories
{
    public interface ICourseRepository : IRepository, ICrud<Course>
    {
        
    }
}