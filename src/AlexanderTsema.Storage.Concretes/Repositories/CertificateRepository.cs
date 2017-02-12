using System;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Entities.Entities;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
    public class CertificateRepository : BaseRepository<Certificate, Int16>, ICertificateRepository
    {
        
    }
}