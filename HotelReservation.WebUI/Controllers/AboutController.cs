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
    public class AboutController : Controller
    {
        readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _aboutService.GetAll());
        }

        [AllowAnonymous]
        public IActionResult _HitRead(int? id)
        {
            return PartialView(_aboutService.HitRead(id));
        }
        public async Task<IActionResult> kurtulusocL()
        {
            return View(await _aboutService.GetAll());
        }
        public async Task<IActionResult> AboutManage()
        {
            return View(await _aboutService.GetAllWtihoutParameter());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _aboutService.GetById(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(About model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/us/about/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.Image = photoName;
            }
            var result = await _aboutService.Create(model);
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
            var updateAbout = await _aboutService.GetById(id);
            if (updateAbout != null)
            {
                return View(updateAbout);
            }
            return RedirectToAction(nameof(kurtulusocL));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(About model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/us/about/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.Image = photoName;
            }
            var result = await _aboutService.Update(model);
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
            var deleteAbout = await _aboutService.GetById(id);
            if (deleteAbout != null)
            {
                await _aboutService.Delete(deleteAbout);
                return RedirectToAction(nameof(AboutManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, About model)
        {
            var result = await _aboutService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, About model)
        {
            var result = await _aboutService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, About model)
        {
            var result = await _aboutService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, About model)
        {
            var result = await _aboutService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}