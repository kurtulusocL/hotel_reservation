using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class FooterSocialMedia:ViewComponent
    {
        readonly ISocialMediaService _socialMediaService;
        public FooterSocialMedia(ISocialMediaService socialMediaService)
        {
            _socialMediaService=socialMediaService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_socialMediaService.GetAllSync());
        }
    }
}
