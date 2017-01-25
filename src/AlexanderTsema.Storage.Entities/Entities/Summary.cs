using System;
using System.Collections.Generic;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class Summary : BaseEntity
    {
        public String Description { get; set; } 
        public IEnumerable<Skill> Skills { get; set; } 
    }
}