using System.Collections.Generic;
using System.Linq;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
    public class PortfolioItemRepository : BaseRepository<PortfolioItem>, IPortfolioItemRepository
    {

    }
}