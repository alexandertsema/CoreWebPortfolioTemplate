using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class Skill : BaseEntity
    {
        public String Name { get; set; } 
        public Int16 Priority { get; set; }
        public SkillCategory SkillCategory { get; set; }
    }
}