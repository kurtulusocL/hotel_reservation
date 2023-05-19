using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class HotelImage : ViewComponent
    {
        readonly IPictureService _pictureService;
        public HotelImage(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_pictureService.GetPictureSync());
        }
    }
}
