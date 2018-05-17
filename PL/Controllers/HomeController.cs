using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using BLL.DTO;
using PL.Models;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        private ITheatreService theatreService;
        private IOrderService orderService;

        public HomeController(ITheatreService theatreService, IOrderService orderService)
        {
            this.theatreService = theatreService;
            this.orderService = orderService;
        }

        public ViewResult Index()
        {
            IEnumerable<TheatreDTO> theatreDTOs = theatreService.GetTheatres();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TheatreDTO, TheatreViewModel>()).CreateMapper();
            var theatres = mapper.Map<IEnumerable<TheatreDTO>, List<TheatreViewModel>>(theatreDTOs);

            return View(theatres);
        }

        public ViewResult Hall(int playId)
        {
            HallDTO hallDTO = theatreService.GetHall(playId);
            var mapperHall = new MapperConfiguration(cfg => cfg.CreateMap<HallDTO, HallViewModel>()).CreateMapper();
            HallViewModel hallVM = mapperHall.Map<HallDTO, HallViewModel>(hallDTO);

            IEnumerable<PlaceDTO> placeDTOs = orderService.GetPlaces(hallDTO.HallId);
            var mapperPlace = new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, PlaceViewModel>()).CreateMapper();
            List<PlaceViewModel> placesVM = mapperPlace.Map<IEnumerable<PlaceDTO>, List<PlaceViewModel>>(placeDTOs);
            placesVM.Sort(new PlaceComparator());

            return View((hallVM, placesVM as IEnumerable<PlaceViewModel>));
        }

        public ViewResult Plays(int theatreId)
        {
            IEnumerable<PlayDTO> playsDTOs = theatreService.GetPlays(theatreId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlayDTO, PlayViewModel>()).CreateMapper();
            List<PlayViewModel> playsVM = mapper.Map<IEnumerable<PlayDTO>, List<PlayViewModel>>(playsDTOs);

            return View(playsVM);
        }

        [HttpPost]
        public ViewResult MakeOrder( OrderViewModel orderVM)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderViewModel, OrderDTO>()).CreateMapper();

            OrderDTO order = mapper.Map<OrderViewModel, OrderDTO>(orderVM);
            orderVM.OrderId = orderService.MakeOrder(order);
            
            return View("ResultOrder", orderVM);
        }

        public ViewResult MakeOrder(int placeId)
        {
            PlaceDTO placeDTO = theatreService.GetPlace(placeId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaceDTO, PlaceViewModel>()).CreateMapper();
            PlaceViewModel placeVM = mapper.Map<PlaceDTO, PlaceViewModel>(placeDTO);

            OrderViewModel orderVM = new OrderViewModel() { PlaceId = placeId, Number = placeDTO.Number };

            return View("MakeOrder", orderVM);
        }
    }
}
