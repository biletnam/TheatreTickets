using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class HallRepository : IGenericRepository<Hall>
    {
        DbContext context;
        DbSet<Hall> hallSet;

        public HallRepository(DbContext context)
        {
            this.context = context;
            hallSet = context.Set<Hall>();
        }

        public IEnumerable<Hall> Get()
        {
            return hallSet
                .Include(h => h.Places)
                .ToList();
        }

        public IEnumerable<Hall> Get(Func<Hall, bool> predicate)
        {
            return hallSet
                .Include(h => h.Places)
                .Where(predicate)
                .ToList();
        }
        public Hall FindById(int id)
        {
            return hallSet
                .Include(h => h.Places)
                .Where(h => h.HallId == id)
                .FirstOrDefault();
        }

        public void Create(Hall item)
        {
            hallSet.Add(item);
            context.SaveChanges();
        }
        public void Update(Hall item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Remove(Hall item)
        {
            hallSet.Remove(item);
            context.SaveChanges();
        }
    }
}
