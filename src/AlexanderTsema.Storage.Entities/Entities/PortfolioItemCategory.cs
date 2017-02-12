using System;
using System.Collections.Generic;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class PortfolioItemCategory : BaseEntity
    {
        public String Name { get; set; }
        public virtual IEnumerable<PortfolioItem> PortfolioItems { get; set; }
    }
}