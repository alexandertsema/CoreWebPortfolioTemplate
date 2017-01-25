using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class Reference : BaseEntity
    {
        public String Description { get; set; } 
        public String Pdf { get; set; } 
        public virtual ReferenceAuthor ReferenceAuthor { get; set; } 
    }
}