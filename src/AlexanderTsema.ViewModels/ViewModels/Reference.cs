using System;
using AlexanderTsema.ViewModels.ViewModels;

namespace AlexanderTsema.ViewModels.ViewModels
{
    public class Reference
    {
        public String Description { get; set; }
        public String Pdf { get; set; }
        public virtual ReferenceAuthor ReferenceAuthor { get; set; }
    }
}