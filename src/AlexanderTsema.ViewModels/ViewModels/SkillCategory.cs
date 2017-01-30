using System;
using System.Collections.Generic;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class SkillCategory
    {
        public String Name { get; set; }
        public virtual IEnumerable<Skill> Skills { get; set; }
    }
}