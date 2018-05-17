using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITheatreService
    {
        IEnumerable<TheatreDTO> GetTheatres();
        HallDTO GetHall(int theatreId);
        IEnumerable<PlaceDTO> GetAllPlaces(int hallId);
        PlaceDTO GetPlace(int placeId);
        IEnumerable<PlayDTO> GetPlays(int theatreId);
    }
}
