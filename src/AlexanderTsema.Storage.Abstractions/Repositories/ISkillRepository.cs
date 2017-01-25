using System.Collections.Generic;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Entities.Entities;

namespace AlexanderTsema.Storage.Abstractions.Repositories
{
    public interface ISkillRepository : IRepository, IBaseRepository<Skill> { }
}