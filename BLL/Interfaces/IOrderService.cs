using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        int MakeOrder(OrderDTO orderDto);
        IEnumerable<PlaceDTO> GetPlaces(int hallId);
        void Dispose();
    }
}
