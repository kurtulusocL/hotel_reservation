using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class AboutGuide:ViewComponent
    {
        readonly IGuideService _guideService;
        public AboutGuide(IGuideService guideService)
        {
            _guideService = guideService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_guideService.GetAllGuidesForAbout());
        }
    }
}
