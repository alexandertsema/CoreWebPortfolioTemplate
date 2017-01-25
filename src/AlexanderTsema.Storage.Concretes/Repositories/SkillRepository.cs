using System.Collections.Generic;
using System.Linq;
using AlexanderTsema.Storage.Abstractions.Core;
using AlexanderTsema.Storage.Abstractions.Repositories;
using AlexanderTsema.Storage.Concretes.Core;
using AlexanderTsema.Storage.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTsema.Storage.Concretes.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
//        private StorageContext _storageContext;
//        private DbSet<Skill> _skillDbSet;
//
//        public void SetStorageContext(IStorageContext storageContext)
//        {
//            this._storageContext = storageContext as StorageContext;
//            var context = this._storageContext;
//            if (context != null) this._skillDbSet = context.Set<Skill>();
//        }
//
//        public IEnumerable<Skill> All()
//        {
//            return this._skillDbSet.OrderBy(i => i.Id);
//        }
//
//        public Skill Single(int id)
//        {
//            return this._skillDbSet.SingleOrDefault(x => x.Id == id);
//        }
//
//        public void Create(Skill skill)
//        {
//            this._skillDbSet.Add(skill);
//            this._storageContext.SaveChanges();
//        }
//
//        public void Update(Skill skill)
//        {
//            var dbEntry = this._skillDbSet.SingleOrDefault(x => x.Id == skill.Id);
//            if (dbEntry != null)
//            {
//                dbEntry.Name = skill.Name;
//                dbEntry.Priority = skill.Priority;
//            }
//            this._storageContext.SaveChanges();
//        }
//
//        public void Delete(int id)
//        {
//            var dbEntry = this._skillDbSet.SingleOrDefault(x => x.Id == id);
//            if (dbEntry != null)
//            {
//                this._skillDbSet.Remove(dbEntry);
//                this._storageContext.SaveChanges();
//            }
//        }
    }
}