using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public abstract class BaseEntity
    {
        private DateTime _timestamp;

        public Int16 Id { get; set; }

        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = DateTime.UtcNow; }
        }

    }
}