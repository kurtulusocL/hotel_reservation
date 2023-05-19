using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class AdminService : ViewComponent
    {
        readonly IOurServiceService _ourService;
        public AdminService(IOurServiceService ourService)
        {
            _ourService = ourService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_ourService.GetAllServicesForAdmin());
        }
    }
}
