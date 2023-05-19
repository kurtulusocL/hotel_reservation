using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class AdminSomeReservations : ViewComponent
    {
        readonly IReservationService _reservationService;
        public AdminSomeReservations(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_reservationService.GetAllSomeReservationForAdmin());
        }
    }
}
