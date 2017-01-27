using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class PortfolioItem : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public String Link { get; set; }
        public virtual PortfolioItemCategory Category { get; set; }
    }
}