using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class Course
    {
        public Int16 Id { get; set; }
        public String Name { get; set; }
        public virtual School School { get; set; }
    }
}