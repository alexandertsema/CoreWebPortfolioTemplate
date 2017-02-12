using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class PortfolioItemCategory : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String Name { get; set; }

        public virtual IEnumerable<PortfolioItem> PortfolioItems { get; set; }
    }
}