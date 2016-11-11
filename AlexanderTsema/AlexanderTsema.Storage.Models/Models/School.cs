using System;
using System.Collections.Generic;

namespace AlexanderTsema.Storage.Models.Models
{
    public class School
    {
        public Int16 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String GraduationWork { get; set; }
        public Double Gpa { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
