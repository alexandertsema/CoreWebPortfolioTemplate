using System;
using System.Collections.Generic;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class ReferenceAuthor : BaseEntity
    {
        public String Name { get; set; } 
        public String Image { get; set; } 
        public String CompanyName { get; set; } 
        public String CompanyLink { get; set; } 
        public String Position { get; set; }
        public IEnumerable<Reference> References { get; set; }
    }
}