using System;
using DAL.Interfaces;
using DAL.Entities;
using DAL.EF;

namespace DAL.Repositories
{
    public class TheatreUoW : IUnitOfWork
    {
        private readonly Lazy<TheatreRepository> theatresRepository;
        private readonly Lazy<HallRepository> hallsRepository;
        private readonly Lazy<PlayRepository> playsRepository;
        private readonly Lazy<OrderRepository> ordersRepository;
        private readonly Lazy<PlaceRepository> placesRepository;

        public IGenericRepository<Theatre> TheatresRepository => theatresRepository.Value;
        public IGenericRepository<Hall> HallsRepository => hallsRepository.Value;
        public IGenericRepository<Play> PlaysRepository => playsRepository.Value;
        public IGenericRepository<Order> OrdersRepository => ordersRepository.Value;
        public IGenericRepository<Place> PlacesRepository => placesRepository.Value;

        private readonly DataContext dataContext;

        public TheatreUoW(DataContext dataContext)
        {
            this.dataContext = dataContext;

            theatresRepository = new Lazy<TheatreRepository>(() => new TheatreRepository(dataContext));
            hallsRepository = new Lazy<HallRepository>(() => new HallRepository(dataContext));
            playsRepository = new Lazy<PlayRepository>(() => new PlayRepository(dataContext));
            ordersRepository = new Lazy<OrderRepository>(() => new OrderRepository(dataContext));
            placesRepository = new Lazy<PlaceRepository>(() => new PlaceRepository(dataContext));
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
