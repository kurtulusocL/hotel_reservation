using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class HomeSlider:ViewComponent
    {
        readonly IPictureService _pictureService;
        public HomeSlider(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_pictureService.GetAllPicturesSync());
        }
    }
}
