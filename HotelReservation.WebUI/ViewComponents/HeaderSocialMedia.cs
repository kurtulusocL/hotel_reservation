using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class HeaderSocialMedia : ViewComponent
    {
        readonly ISocialMediaService _socialMediaService;
        public HeaderSocialMedia(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_socialMediaService.GetAllSync());
        }
    }
}