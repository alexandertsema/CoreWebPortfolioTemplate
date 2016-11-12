using System;

namespace AlexanderTsema.Storage.Entities.Models
{
    public class Course
    {
        public Int16 Id { get; set; }
        public String Name { get; set; }
        public School School { get; set; }
    }
}