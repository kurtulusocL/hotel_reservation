using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class UserConfirmedReservations : ViewComponent
    {
        readonly IReservationService _reservationService;
        readonly IHttpContextAccessor _httpContextAccessor;
        public UserConfirmedReservations(IReservationService reservationService, IHttpContextAccessor httpContextAccessor)
        {
            _reservationService = reservationService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke(string id)
        {
            id = Convert.ToString(_httpContextAccessor.HttpContext.Session.GetString("userId"));
            return View(_reservationService.GetAllConfirmedReservationByUserId(id));
        }
    }
}
