using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class HomeService:ViewComponent
    {
        readonly IOurServiceService _ourService;
        public HomeService(IOurServiceService ourService)
        {
            _ourService = ourService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_ourService.GetAllSync());
        }
    }
}
