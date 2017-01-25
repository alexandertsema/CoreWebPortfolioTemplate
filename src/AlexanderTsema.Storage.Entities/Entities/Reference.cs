using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class Reference
    {
        public Int16 Id { get; set; } 
        public String Description { get; set; } 
        public String Pdf { get; set; } 
        public virtual ReferenceAuthor ReferenceAuthor { get; set; } 
    }
}