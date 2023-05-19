using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class HomeImages:ViewComponent
    {
        readonly IPictureService _pictureService;
        public HomeImages(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_pictureService.GetAllPicturesForHomeSync());
        }
    }
}
