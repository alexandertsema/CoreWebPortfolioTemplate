using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Entities.Models;

namespace AlexanderTsema.Storage.Abstractions.Repositories
{
    public interface IPortfolioItemRepository : IRepository, IBaseRepository<PortfolioItem> { }
}