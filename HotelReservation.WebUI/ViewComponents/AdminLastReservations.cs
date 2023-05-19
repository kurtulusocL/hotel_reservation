using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class AdminLastReservations : ViewComponent
    {
        readonly IReservationService _reservationService;
        public AdminLastReservations(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_reservationService.GetAllLastReservationForAdmin());
        }
    }
}
