using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class PortfolioItem : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Link { get; set; }
        //public Int16 FileId { get; set; }
        public Int16 PortfolioItemCategoryId { get; set; }
        //public File Image { get; set; }
        public virtual PortfolioItemCategory PortfolioItemCategory { get; set; }
    }
}