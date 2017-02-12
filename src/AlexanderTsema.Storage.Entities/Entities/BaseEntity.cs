using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public abstract class BaseEntity// : IEntity<Int16>
    {
        public Int16 Id { get; set; } // this is virtual prop, IncludeAll crashes

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}