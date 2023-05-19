using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class UserHomeService : ViewComponent
    {
        readonly IOurServiceService _ourService;
        public UserHomeService(IOurServiceService ourService)
        {
            _ourService = ourService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_ourService.GetAllServicesForUser());
        }
    }
}
