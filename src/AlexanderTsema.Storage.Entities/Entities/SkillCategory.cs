using System;
using System.Collections.Generic;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class SkillCategory : BaseEntity
    {
        public String Name { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}