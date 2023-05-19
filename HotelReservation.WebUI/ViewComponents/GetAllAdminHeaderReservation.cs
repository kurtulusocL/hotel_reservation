using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class GetAllAdminHeaderReservation : ViewComponent
    {
        readonly IReservationService _reservationService;
        public GetAllAdminHeaderReservation(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_reservationService.GetAllReservationForAdmin());
        }
    }
}
