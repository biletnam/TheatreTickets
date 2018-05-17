using AutoMapper;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using DAL.Interfaces;
using DAL.Entities;
using System.Linq;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public int MakeOrder(OrderDTO orderDTO)
        {
            if (orderDTO.PlaceId < 0)
                throw new ValidationException("Не указаны места", "");

            //List<Place> places = new List<Place>();
            //foreach (PlaceDTO placeOTD in orderDTO.Places)
            //{
                Place place = Database.PlacesRepository.FindById(orderDTO.PlaceId);

                place.Buyed = true;

                //places.Add(place);
            //}

            Order order = new Order
            {
                FirstName = orderDTO.FirstName,
                LastName = orderDTO.LastName,
                Place = place
            };

            Database.OrdersRepository.Create(order);
            
            Database.Save();

            return order.OrderId;
        }

        public IEnumerable<PlaceDTO> GetPlaces(int hallId)
        {
            Hall hall = Database.HallsRepository.FindById(hallId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Place>, List<PlaceDTO>>(hall.Places.Where(p => p.Buyed == false));
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
