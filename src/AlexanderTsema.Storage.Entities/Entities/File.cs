using System;
using AlexanderTsema.Storage.Entities.Enums;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public class File : BaseEntity
    {
        public String Name { get; set; }
        public String FilePath { get; set; }
        public Int64 Size { get; set; }
        public FileType FileType { get; set; }
    }
}