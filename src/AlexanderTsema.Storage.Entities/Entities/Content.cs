using System;
using System.Collections.Generic;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class Content : BaseEntity
    {
        public String SummaryTitle { get; set; } 
        public String EducationTitle { get; set; } 
        public String WorkTitle { get; set; } 
        public String TestimonialsTitle { get; set; } 
        public String CertificateTitle { get; set; } 
        public String ContactsTitle { get; set; } 
    }
}