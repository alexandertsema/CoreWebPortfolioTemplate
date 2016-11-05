using System;

namespace AlexanderTsema.Storage.Models.Models
{
    public class Reference
    {
        public Int16 Id { get; set; } 
        public String Description { get; set; } 
        public String Pdf { get; set; } 
        public ReferenceAuthor ReferenceAuthor { get; set; } 
    }
}