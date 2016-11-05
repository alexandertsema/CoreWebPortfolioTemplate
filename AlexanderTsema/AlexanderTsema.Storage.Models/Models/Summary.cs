using System;
using System.Collections.Generic;

namespace AlexanderTsema.Storage.Models.Models
{
    public class Summary
    {
        public Int16 Id { get; set; } 
        public String Description { get; set; } 
        public IEnumerable<Skill> Skills { get; set; } 
    }
}