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
    public class ContactController : Controller
    {
        readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetAll());
        }

        public async Task<IActionResult> kurtulusocL()
        {
            return View(await _contactService.GetAll());
        }
        public async Task<IActionResult> ContactManage()
        {
            return View(await _contactService.GetAllWtihoutParameter());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _contactService.GetById(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                var result = await _contactService.Create(model);
                if (result)
                {
                    TempData["success"] = "Created";
                    return RedirectToAction(nameof(Create));
                }
                TempData["error"] = "Mistake";
                return RedirectToAction(nameof(Create));
            }
            TempData["modelState"] = "Error";
            return RedirectToAction(nameof(Create));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var updateContact = await _contactService.GetById(id);
            if (updateContact != null)
            {
                return View(updateContact);
            }
            return RedirectToAction(nameof(kurtulusocL));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact model)
        {
            if (ModelState.IsValid)
            {
                var result = await _contactService.Update(model);
                if (result)
                {
                    TempData["success"] = "Updated";
                    return RedirectToAction(nameof(Edit), new { id = model.Id });
                }
                TempData["error"] = "Mistake";
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            TempData["modelState"] = "Error";
            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteContact = await _contactService.GetById(id);
            if (deleteContact != null)
            {
                await _contactService.Delete(deleteContact);
                return RedirectToAction(nameof(ContactManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, Contact model)
        {
            var result = await _contactService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, Contact model)
        {
            var result = await _contactService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, Contact model)
        {
            var result = await _contactService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, Contact model)
        {
            var result = await _contactService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
