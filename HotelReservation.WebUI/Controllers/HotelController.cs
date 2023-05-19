using HotelReservation.Business.Abstract;
using HotelReservation.Business.CrossCuttingConcern.Attributes;
using HotelReservation.Core.CrossCuttingConcern.Dtos.UpdateDtos;
using HotelReservation.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace HotelReservation.WebUI.Controllers
{
    [ExceptionHandler]
    [AuditLog]
    [Authorize(Roles = "Admins, AsistantAdmins")]
    public class HotelController : Controller
    {
        readonly IHotelService _hotelService;
        readonly ICommentService _commentService;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly ICaptchaValidatorService _captchaValidatorService;
        public HotelController(IHotelService hotelService, ICommentService commentService, IHttpContextAccessor httpContextAccessor, ICaptchaValidatorService captchaValidatorService)
        {
            _hotelService = hotelService;
            _commentService = commentService;
            _httpContextAccessor = httpContextAccessor;
            _captchaValidatorService = captchaValidatorService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _hotelService.GetAll());
        }

        [AllowAnonymous]
        public async Task<IActionResult> CreateComment(int? id)
        {
            ViewBag.HotelId = await _hotelService.GetById(id);
            Comment model = new Comment
            {
                HotelId = id
            };
            return View("CreateComment", model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(string nameSurname, string emailAddress, string subject, string text, string appUserId, int? hotelId, string token)
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
                HotelId = hotelId
            };
            var result = await _commentService.Create(model);
            if (result)
            {
                TempData["success"] = "Your comment has been saved. Thank you.";
                return RedirectToAction(nameof(CreateComment), new { id=model.HotelId });
            }
            TempData["error"] = "There was an error while saving to your comment. Please check to comment form and then try again.";
            return RedirectToAction(nameof(CreateComment), new { id = model.HotelId });
        }
        public async Task<IActionResult> kurtulusocL()
        {
            return View(await _hotelService.GetAll());
        }
        public async Task<IActionResult> HotelManage()
        {
            return View(await _hotelService.GetAllHotelsWithoutParameter());
        }
        public async Task<IActionResult> HotelDetail(int? id)
        {
            return View(await _hotelService.GetById(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hotel model, IFormFile image)
        {

            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/us/hotel/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.CoverImage = photoName;
            }
            var result = await _hotelService.Create(model);
            if (result)
            {
                TempData["success"] = "Created";
                return RedirectToAction(nameof(Create));
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(Create));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var updateHotel = await _hotelService.GetById(id);
            if (updateHotel != null)
            {
                return View(updateHotel);
            }
            return RedirectToAction(nameof(kurtulusocL));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Hotel model, IFormFile image)
        {

            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/us/hotel/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.CoverImage = photoName;
            }
            var result = await _hotelService.Update(model);
            if (result)
            {
                TempData["success"] = "Updated";
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }

        public async Task<IActionResult> PromotionUpdate(int? id)
        {
            var updatePromotion = await _hotelService.GetById(id);
            var model = new HotelPromotionUpdateDto()
            {
                Id = updatePromotion.Id,
                IsPromotion = updatePromotion.IsPromotion
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PromotionUpdate(HotelPromotionUpdateDto model)
        {
            var promotion = await _hotelService.GetById(model.Id);
            promotion.IsPromotion = model.IsPromotion;
            var result = await _hotelService.Update(promotion);
            if (result == true)
            {
                TempData["success"] = "Hotel Promotion Updated";
                return RedirectToAction(nameof(PromotionUpdate), new { id = model.Id });
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(PromotionUpdate), new { id = model.Id });
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var deleteHotel = await _hotelService.GetById(id);
            if (deleteHotel != null)
            {
                await _hotelService.Delete(deleteHotel);
                return RedirectToAction(nameof(HotelManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, Hotel model)
        {
            var result = await _hotelService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(HotelDetail), new { id = model.Id });
            }
            return RedirectToAction(nameof(HotelDetail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, Hotel model)
        {
            var result = await _hotelService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(HotelDetail), new { id = model.Id });
            }
            return RedirectToAction(nameof(HotelDetail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, Hotel model)
        {
            var result = await _hotelService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(HotelDetail), new { id = model.Id });
            }
            return RedirectToAction(nameof(HotelDetail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, Hotel model)
        {
            var result = await _hotelService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(HotelDetail), new { id = model.Id });
            }
            return RedirectToAction(nameof(HotelDetail), new { id = model.Id });
        }
    }
}
