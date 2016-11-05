using System;

namespace AlexanderTsema.Data.Models
{
    public class Content
    {
        public Int16 Id { get; set; } 
        public String EducationTitle { get; set; } 
        public School School { get; set; }
    }
}