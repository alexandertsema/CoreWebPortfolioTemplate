using System.Collections.Generic;
using System.Threading.Tasks;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Entities.Entities;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
    public class ContentRepository : BaseRepository<Content>, IContentRepository
    {

    }
}