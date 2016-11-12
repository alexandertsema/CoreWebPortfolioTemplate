using System;

namespace AlexanderTsema.Storage.Entities.Models
{
    public class PortfolioItem
    {
        public Int16 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public String Link { get; set; }
        public PortfolioItemType PortfolioItemType { get; set; }
    }
}