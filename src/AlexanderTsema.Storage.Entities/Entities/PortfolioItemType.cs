using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class PortfolioItemType : BaseEntity
    {
        public Boolean Web { get; set; } 
        public Boolean Desktop { get; set; } 
        public Boolean Mobile { get; set; }
    }
}