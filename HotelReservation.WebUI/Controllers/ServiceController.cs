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
    public class ServiceController : Controller
    {
        readonly IOurServiceService _ourService;
        public ServiceController(IOurServiceService ourService)
        {
            _ourService = ourService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _ourService.GetAll());
        }
        public async Task<IActionResult> kurtulusocL()
        {
            return View(await _ourService.GetAll());
        }
        public async Task<IActionResult> ServiceManage()
        {
            return View(await _ourService.GetAllServicesWithoutParameter());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _ourService.GetById(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service model)
        {
            var result = await _ourService.Create(model);
            if (result)
            {
                TempData["success"] = "Created";
                return RedirectToAction(nameof(Create));
            }
            TempData["success"] = "Error";
            return RedirectToAction(nameof(Create));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var updateService = await _ourService.GetById(id);
            if (updateService != null)
            {
                return View(updateService);
            }
            return RedirectToAction(nameof(kurtulusocL));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Service model)
        {
            var result = await _ourService.Update(model);
            if (result)
            {
                TempData["success"] = "Updated";
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            TempData["success"] = "Error";
            return RedirectToAction(nameof(Edit), new { id = model.Id });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteService = await _ourService.GetById(id);
            if (deleteService != null)
            {
                await _ourService.Delete(deleteService);
                return RedirectToAction(nameof(ServiceManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, Service model)
        {
            var result = await _ourService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, Service model)
        {
            var result = await _ourService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, Service model)
        {
            var result = await _ourService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, Service model)
        {
            var result = await _ourService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
