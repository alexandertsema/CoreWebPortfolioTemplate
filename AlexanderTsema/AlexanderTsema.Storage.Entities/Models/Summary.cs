using System;
using System.Collections.Generic;

namespace AlexanderTsema.Storage.Entities.Models
{
    public class Summary
    {
        public Int16 Id { get; set; } 
        public String Description { get; set; } 
        public IEnumerable<Skill> Skills { get; set; } 
    }
}