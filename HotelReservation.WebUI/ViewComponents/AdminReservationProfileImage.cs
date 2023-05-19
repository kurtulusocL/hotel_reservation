using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class AdminReservationProfileImage:ViewComponent
    {
        readonly IProfileImageService _profileImageService;
        public AdminReservationProfileImage(IProfileImageService profileImageService)
        {
            _profileImageService = profileImageService;
        }
        public IViewComponentResult Invoke(string id)
        {
            return View(_profileImageService.GetProfileImageByUserIdSync(id));
        }
    }
}
