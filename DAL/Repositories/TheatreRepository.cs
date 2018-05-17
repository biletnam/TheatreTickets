using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class TheatreRepository : IGenericRepository<Theatre>
    {
        DbContext context;
        DbSet<Theatre> theatreSet;

        public TheatreRepository(DbContext context)
        {
            this.context = context;
            theatreSet = context.Set<Theatre>();
        }

        public IEnumerable<Theatre> Get()
        {
            return theatreSet
                .Include(t => t.Plays)
                .ToList();
        }

        public IEnumerable<Theatre> Get(Func<Theatre, bool> predicate)
        {
            return theatreSet
                .Include(t => t.Plays)
                .Where(predicate)
                .ToList();
        }
        public Theatre FindById(int id)
        {
            return theatreSet
                .Include(t => t.Plays)
                .Where(p => p.TheatreId == id)
                .FirstOrDefault();
        }

        public void Create(Theatre item)
        {
            theatreSet.Add(item);
            context.SaveChanges();
        }
        public void Update(Theatre item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Remove(Theatre item)
        {
            theatreSet.Remove(item);
            context.SaveChanges();
        }
    }
}
