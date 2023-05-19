using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class GetHeaderAdminImage : ViewComponent
    {
        readonly IProfileImageService _profileImageService;
        public GetHeaderAdminImage(IProfileImageService profileImageService)
        {
            _profileImageService = profileImageService;
        }

        public IViewComponentResult Invoke(string id)
        {
            return View(_profileImageService.GetProfileImageByUserIdSync(id));
        }
    }
}
