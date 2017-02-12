using System;
using System.ComponentModel.DataAnnotations;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class PortfolioItem : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(500, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Long")]
        public String Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(100, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String ImagePath { get; set; }

        [MaxLength(100, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String Link { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        public Int16 PortfolioItemCategoryId { get; set; }

        public virtual PortfolioItemCategory PortfolioItemCategory { get; set; }
    }
}