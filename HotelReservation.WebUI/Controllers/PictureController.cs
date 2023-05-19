using HotelReservation.Business.Abstract;
using HotelReservation.Business.CrossCuttingConcern.Attributes;
using HotelReservation.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace HotelReservation.WebUI.Controllers
{
    [ExceptionHandler]
    [AuditLog]
    [Authorize(Roles = "Admins, AsistantAdmins")]
    public class PictureController : Controller
    {
        readonly IPictureService _pictureService;
        readonly ICommentService _commentService;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly ICaptchaValidatorService _captchaValidatorService;
        public PictureController(IPictureService pictureService, ICommentService commentService, IHttpContextAccessor httpContextAccessor, ICaptchaValidatorService captchaValidatorService)
        {
            _pictureService = pictureService;
            _commentService = commentService;
            _httpContextAccessor = httpContextAccessor;
            _captchaValidatorService = captchaValidatorService;
        }

        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            return View(_pictureService.GetAll(page, 24));
        }

        [AllowAnonymous]
        public async Task<IActionResult> CreateComment(int? id)
        {
            ViewBag.PictureId = await _pictureService.GetById(id);
            Comment model = new Comment
            {
                PictureId = id
            };
            return PartialView("CreateComment", model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(string nameSurname, string emailAddress, string subject, string text, string appUserId, int? pictureId, string token)
        {
            appUserId = Convert.ToString(_httpContextAccessor.HttpContext.Session.GetString("userId"));
            if (!_captchaValidatorService.IsRecaptchaValid(token))
            {
                TempData["CaptchaError"] = "Captcha is not valid!!";
                return BadRequest();
            }
            var model = new Comment
            {
                NameSurname = nameSurname,
                EmailAddress = emailAddress,
                Subject = subject,
                Text = text,
                AppUserId = appUserId,
                PictureId = pictureId
            };
            var result = await _commentService.Create(model);
            if (result)
            {
                TempData["success"] = "Your comment has been saved. Thank you.";
                return RedirectToAction(nameof(Detail), new { id = model.PictureId });
            }
            TempData["success"] = "There was an error while saving to your comment. Please check to comment form and then try again.";
            return RedirectToAction(nameof(Detail), new { id = model.PictureId });
        }
        public IActionResult kurtulusocL(int page = 1)
        {
            return View(_pictureService.GetAll(page, 40));
        }
        public IActionResult PictureManage(int page = 1)
        {
            return View(_pictureService.GetAllPicturesWithoutParameter(page, 55));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _pictureService.GetById(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Picture model, IEnumerable<IFormFile> images)
        {
            if (images != null)
            {
                foreach (var image in images)
                {
                    var path = Path.GetExtension(image.FileName);
                    var photoName = Guid.NewGuid() + path;
                    var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/us/web/" + photoName);
                    var stream = new FileStream(upload, FileMode.Create);
                    image.CopyTo(stream);
                    model.ImageUrl = photoName;

                    _pictureService.Create(model);
                    TempData["success"] = "Creatad";
                    return RedirectToAction(nameof(Create));
                }
                TempData["error"] = "Mistake";
                return RedirectToAction(nameof(Create));
            }
            TempData["noImage"] = "There is/are not image(s)";
            return RedirectToAction(nameof(Create));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var updateImage = await _pictureService.GetById(id);
            if (updateImage != null)
            {
                return View(updateImage);
            }
            return RedirectToAction(nameof(kurtulusocL));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Picture model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/us/web/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.ImageUrl = photoName;
            }
            var result = await _pictureService.Update(model);
            if (result)
            {
                TempData["success"] = "Updated";
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteImage = await _pictureService.GetById(id);
            if (deleteImage != null)
            {
                await _pictureService.Delete(deleteImage);
                return RedirectToAction(nameof(PictureManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, Picture model)
        {
            var result = await _pictureService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, Picture model)
        {
            var result = await _pictureService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, Picture model)
        {
            var result = await _pictureService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, Picture model)
        {
            var result = await _pictureService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
