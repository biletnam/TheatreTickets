using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Order> OrdersRepository { get; }
        IGenericRepository<Theatre> TheatresRepository { get; }
        IGenericRepository<Hall> HallsRepository { get; }
        IGenericRepository<Play> PlaysRepository { get; }
        IGenericRepository<Place> PlacesRepository { get; }
        void Save();
    }
}
