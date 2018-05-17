using System.Collections.Generic;
using BLL.DTO;
using BLL.Interfaces;
using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TheatreService : ITheatreService
    {
        IUnitOfWork Database { get; set; }

        public TheatreService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<PlaceDTO> GetAllPlaces(int hallId)
        {
            Hall hall = Database.HallsRepository.FindById(hallId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Place>, List<PlaceDTO>>(hall.Places);
        }

        public PlaceDTO GetPlace(int placeId)
        {
            Place place = Database.PlacesRepository.FindById(placeId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Place, PlaceDTO>()).CreateMapper();
            return mapper.Map<Place, PlaceDTO>(place);
        }

        public HallDTO GetHall(int playId)
        {
            Play play = Database.PlaysRepository.FindById(playId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Hall, HallDTO>()).CreateMapper();
            return mapper.Map<Hall, HallDTO>(play.Hall);
        }

        public IEnumerable<PlayDTO> GetPlays(int theatreId)
        {
            Theatre theatre = Database.TheatresRepository.FindById(theatreId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Play, PlayDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Play>, List<PlayDTO>>(theatre.Plays);
        }

        public IEnumerable<TheatreDTO> GetTheatres()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Theatre, TheatreDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Theatre>, List<TheatreDTO>>(Database.TheatresRepository.Get());
        }
    }
}
