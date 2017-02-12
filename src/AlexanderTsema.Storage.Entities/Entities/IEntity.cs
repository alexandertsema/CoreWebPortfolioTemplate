using System;

namespace AlexanderTsema.Storage.Entities.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
        DateTime Timestamp { get; set; }
    }
}