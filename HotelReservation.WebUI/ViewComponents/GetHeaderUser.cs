using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class GetHeaderUser:ViewComponent
    {
        readonly IUserService _userService;
        readonly IHttpContextAccessor _httpContextAccessor;
        public GetHeaderUser(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke(string id)
        {
            id = Convert.ToString(_httpContextAccessor.HttpContext.Session.GetString("userId"));
            return View(_userService.GetUserByIdSync(id));
        }
    }
}
