using System;
using System.Collections.Generic;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class School
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String GraduationWork { get; set; }
        public Double Gpa { get; set; }
        public String Image { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
