using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class PortfolioItem
    {
        public Int16 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public String Link { get; set; }
        public virtual PortfolioItemType PortfolioItemType { get; set; }
    }
}