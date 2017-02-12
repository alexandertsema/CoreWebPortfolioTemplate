using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class ReferenceAuthor : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String Name { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String ImagePath { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String CompanyName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(100, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String CompanyLink { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String Position { get; set; }
        public virtual IEnumerable<Reference> References { get; set; }
    }
}