using System;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class PortfolioItem
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public String Link { get; set; }
        public virtual PortfolioItemCategory Category { get; set; }
    }
}