namespace AlexanderTsema.Storage.Abstractions.Core
{
    public interface IStorage
    {
        T GetRepository<T>() where T : IRepository;
        void Save();
    }
}