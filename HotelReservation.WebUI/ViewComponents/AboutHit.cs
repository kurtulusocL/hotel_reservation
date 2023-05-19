using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class AboutHit : ViewComponent
    {
        readonly IAboutService _aboutService;
        public AboutHit(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public IViewComponentResult Invoke(int? id)
        {
            return View(_aboutService.HitRead(id));
        }
    }
}
