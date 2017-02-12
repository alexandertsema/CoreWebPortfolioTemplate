using System;
using System.ComponentModel.DataAnnotations;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class Resume : BaseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Length_Short")]
        public String PdfPath { get; set; }
    }
}