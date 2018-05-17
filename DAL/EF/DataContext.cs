using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System.Collections.Generic;

namespace DAL.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Place> Places { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theatre>()
                .HasMany(t => t.Plays)
                .WithOne(p => p.Theatre);

            modelBuilder.Entity<Hall>()
                .HasMany(h => h.Places)
                .WithOne(p => p.Hall);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Place)
                .WithOne(p => p.Order)
                .HasForeignKey<Place>(p => p.OrderId);
        }              
    }
}
