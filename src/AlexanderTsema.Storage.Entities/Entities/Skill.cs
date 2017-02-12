using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class Skill : BaseEntity
    {
        public String Name { get; set; }
        public Int16 Priority { get; set; }
        public Int16 SkillCategoryId { get; set; }
        public virtual SkillCategory SkillCategory { get; set; }
    }
}