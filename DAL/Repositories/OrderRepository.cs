using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    class OrderRepository : IGenericRepository<Order>
    {
        DbContext context;
        DbSet<Order> orderSet;

        public OrderRepository(DbContext context)
        {
            this.context = context;
            orderSet = context.Set<Order>();
        }

        public IEnumerable<Order> Get()
        {
            return orderSet
                .Include(o => o.Place)
                .ToList();
        }

        public IEnumerable<Order> Get(Func<Order, bool> predicate)
        {
            return orderSet
                .Include(o => o.Place)
                .Where(predicate)
                .ToList();
        }
        public Order FindById(int id)
        {
            return orderSet
                .Include(o => o.Place)
                .Where(o => o.OrderId == id)
                .FirstOrDefault();
        }

        public void Create(Order item)
        {
            orderSet.Add(item);
            context.SaveChanges();
        }
        public void Update(Order item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Remove(Order item)
        {
            orderSet.Remove(item);
            context.SaveChanges();
        }
    }
}
