using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    class PlayRepository : IGenericRepository<Play>
    {
        DbContext context;
        DbSet<Play> playSet;

        public PlayRepository(DbContext context)
        {
            this.context = context;
            playSet = context.Set<Play>();
        }

        public IEnumerable<Play> Get()
        {
            return playSet
                .ToList();
        }

        public IEnumerable<Play> Get(Func<Play, bool> predicate)
        {
            return playSet
                .Where(predicate)
                .ToList();
        }
        public Play FindById(int id)
        {
            return playSet
                .Include(p => p.Hall)
                .Where(p => p.PlayId == id)
                .FirstOrDefault();
        }

        public void Create(Play item)
        {
            playSet.Add(item);
            context.SaveChanges();
        }
        public void Update(Play item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Remove(Play item)
        {
            playSet.Remove(item);
            context.SaveChanges();
        }
    }
}
