using System;
using System.ComponentModel.DataAnnotations;
using AlexanderTsema.ViewModels.ViewModels;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class Reference
    {
        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(500, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Long")]
        public String Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(100, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String Pdf { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        public virtual ReferenceAuthor ReferenceAuthor { get; set; }
    }
}