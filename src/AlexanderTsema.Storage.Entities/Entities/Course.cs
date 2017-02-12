using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class Course : BaseEntity
    {
        public String Name { get; set; }
        public Int16 SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}