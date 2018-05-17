using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    class PlaceRepository : IGenericRepository<Place>
    {
        DbContext context;
        DbSet<Place> placeSet;

        public PlaceRepository(DbContext context)
        {
            this.context = context;
            placeSet = context.Set<Place>();
        }

        public IEnumerable<Place> Get()
        {
            return placeSet                
                .ToList();
        }

        public IEnumerable<Place> Get(Func<Place, bool> predicate)
        {
            return placeSet                
                .Where(predicate)
                .ToList();
        }
        public Place FindById(int id)
        {
            return placeSet                
                .Where(p => p.PlaceId == id)
                .FirstOrDefault();
        }

        public void Create(Place item)
        {
            placeSet.Add(item);
            context.SaveChanges();
        }
        public void Update(Place item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Remove(Place item)
        {
            placeSet.Remove(item);
            context.SaveChanges();
        }
    }
}
