using System;
using System.ComponentModel.DataAnnotations;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class Course : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String Name { get; set; }
        public virtual School School { get; set; }
    }
}