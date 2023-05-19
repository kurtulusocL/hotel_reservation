using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class UserNavbar:ViewComponent
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        public UserNavbar(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke()
        {
            //id = _httpContextAccessor.HttpContext.Session.GetString("userId");
            ViewData["userId"] = _httpContextAccessor.HttpContext.Session.GetString("userId");
            return View();
        }
    }
}
