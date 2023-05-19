using HotelReservation.Business.Abstract;
using HotelReservation.Business.CrossCuttingConcern.Attributes;
using HotelReservation.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Controllers
{
    [ExceptionHandler]
    [AuditLog]
    [Authorize(Roles = "Admins, AsistantAdmins")]
    public class HomeAdminController : Controller
    {
        readonly IUserService _userService;
        readonly IProfileImageService _profileImageService;
        readonly IHttpContextAccessor _httpContextAccessor;
        public HomeAdminController(IProfileImageService profileImageService, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _profileImageService = profileImageService;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }
        public IActionResult Index()
        {
            ViewData["nameSurname"] = _httpContextAccessor.HttpContext.Session.GetString("userNameSurname");
            if (User.IsInRole("Admins") || User.IsInRole("AsistantAdmins"))
                return View();
            else
                return RedirectToAction("Login", "AdminAuth");
        }
        public async Task<IActionResult> MyProfile(string id)
        {
            return View(await _userService.GetById(id));
        }
        public async Task<IActionResult> MyProfilePhotoList(string id)
        {
            return View(await _profileImageService.GetAllProfileImagesByUserId(id));
        }
        public IActionResult CreateProfilePhoto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProfilePhoto(string appUserId, IFormFile image)
        {
            appUserId = Convert.ToString(_httpContextAccessor.HttpContext.Session.GetString("userId"));
            ProfileImage model = new ProfileImage
            {
                AppUserId = appUserId
            };
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/us/profile/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.Image = photoName;
            }            
            var result = await _profileImageService.Create(model);
            if (result)
            {
                TempData["success"] = "Profile Image Saved";
                return RedirectToAction(nameof(CreateProfilePhoto), new { id = model.AppUserId });
            }
            TempData["success"] = "Mistake";
            return RedirectToAction(nameof(CreateProfilePhoto), new { id = model.AppUserId });
        }

        public async Task<IActionResult> DeleteProfilePhoto(int? id, ProfileImage model)
        {
            var profilePhoto = await _profileImageService.GetById(id);
            if (profilePhoto != null)
            {
                var result = await _profileImageService.Delete(profilePhoto);
                if (result)
                {
                    TempData["success"] = "Image Deleted!";
                    return RedirectToAction(nameof(MyProfilePhotoList), new { id = model.AppUserId });
                }
                TempData["error"] = "There was an error";
                return RedirectToAction(nameof(MyProfilePhotoList), new { id = model.AppUserId });
            }
            TempData["noImage"] = "There was not an image";
            return RedirectToAction(nameof(MyProfilePhotoList), new { id = model.AppUserId });
        }
    }
}
