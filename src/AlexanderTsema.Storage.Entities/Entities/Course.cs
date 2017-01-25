using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class Course : BaseEntity
    {
        public String Name { get; set; }
        public virtual School School { get; set; }
    }
}