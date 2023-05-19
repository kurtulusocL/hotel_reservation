using HotelReservation.Business.Abstract;
using HotelReservation.Business.CrossCuttingConcern.Attributes;
using HotelReservation.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Controllers
{
    [ExceptionHandler]
    [AuditLog]
    [Authorize(Roles = "Users")]
    public class HomeUserController : Controller
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IUserService _userService;
        readonly IProfileImageService _profileImageService;
        readonly ICommentService _commentService;
        readonly ICommentAnswerService _commentAnswerService;
        readonly IReservationService _reservationService;
        readonly IReservationPolicyService _reservationPolicyService;
        public HomeUserController(IHttpContextAccessor httpContextAccessor, IUserService userService, IProfileImageService profileImageService, ICommentService commentService, ICommentAnswerService commentAnswerService, IReservationService reservationService, IReservationPolicyService reservationPolicyService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _profileImageService = profileImageService;
            _commentService = commentService;
            _commentAnswerService = commentAnswerService;
            _reservationService = reservationService;
            _reservationPolicyService = reservationPolicyService;
        }
        public IActionResult Index()
        {
            ViewData["userId"] = _httpContextAccessor.HttpContext.Session.GetString("userId");
            ViewData["nameSurname"] = _httpContextAccessor.HttpContext.Session.GetString("userNameSurname");
            return View();
        }
        public IActionResult _CommentAnswerHit(int? id)
        {
            return PartialView(_commentAnswerService.HitRead(id));
        }
        public async Task<IActionResult> Like(int id, CommentAnswer model)
        {
            var result = await _commentAnswerService.Like(id);
            if (result)
            {
                return RedirectToAction(nameof(CommentAnswer), new { id = model.Id });
            }
            return RedirectToAction(nameof(CommentAnswer), new { id = model.Id });
        }
        public async Task<IActionResult> Dislike(int id, CommentAnswer model)
        {
            var result = await _commentAnswerService.Dislike(id);
            if (result)
            {
                return RedirectToAction(nameof(CommentAnswer), new { id = model.Id });
            }
            return RedirectToAction(nameof(CommentAnswer), new { id = model.Id });
        }
        public async Task<IActionResult> ReservationPolicy()
        {
            return View(await _reservationPolicyService.GetAll());
        }
        public async Task<IActionResult> CommentAnswer(int? id)
        {
            return View(await _commentAnswerService.GetAllCommentAnswersByCommentId(id));
        }
        public async Task<IActionResult> CommentList(string? id)
        {
            ViewData["userId"] = _httpContextAccessor.HttpContext.Session.GetString("userId");
            id = _httpContextAccessor.HttpContext.Session.GetString("userId");
            return View(await _commentService.GetAllCommentsByUserId(id));
        }
        public async Task<IActionResult> MyConfirmedReservations(string id)
        {
            ViewData["userId"] = _httpContextAccessor.HttpContext.Session.GetString("userId");
            id = _httpContextAccessor.HttpContext.Session.GetString("userId");
            return View(await _reservationService.GetAllConfirmedReservationForUserByUserId(id));
        }
        public async Task<IActionResult> MyAllReservations(string id)
        {
            ViewData["userId"] = _httpContextAccessor.HttpContext.Session.GetString("userId");
            id = _httpContextAccessor.HttpContext.Session.GetString("userId");
            return View(await _reservationService.GetAllReservationByUserId(id));
        }
        public async Task<IActionResult> MyProfilePhotoList(string id)
        {
            return View(await _profileImageService.GetAllProfileImagesByUserId(id));
        }
        public async Task<IActionResult> MyProfile(string id)
        {
            return View(await _userService.GetById(id));
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
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/user/profile/" + photoName);
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
        public async Task<IActionResult> DeleteComment(int id, Comment model)
        {
            var result = await _commentService.SetDeleted(id);
            if (result)
            {
                TempData["success"] = "Comment Deleted!";
                return RedirectToAction(nameof(CommentList), new { id = model.AppUserId });
            }
            TempData["error"] = "Mistake!";
            return RedirectToAction(nameof(CommentList), new { id = model.AppUserId });
        }
        public async Task<IActionResult> DeleteCommentAnswer(int id, CommentAnswer model)
        {
            var result = await _commentAnswerService.SetDeleted(id);
            if (result)
            {
                TempData["success"] = "Comment Answer Deleted!";
                return RedirectToAction(nameof(CommentAnswer), new { id = model.Id });
            }
            TempData["error"] = "Mistake!";
            return RedirectToAction(nameof(CommentAnswer), new { id = model.Id });
        }
    }
}
