using System;
using System.Collections.Generic;

namespace AlexanderTsema.Storage.Models.Models
{
    public class Content
    {
        public Int16 Id { get; set; } 
        public String SummaryTitle { get; set; } 
        public String EducationTitle { get; set; } 
        public IEnumerable<School> Schools { get; set; }
    }
}