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
    public class ReservationPolicyController : Controller
    {
        readonly IReservationPolicyService _reservationPolicyService;
        public ReservationPolicyController(IReservationPolicyService reservationPolicyService)
        {
            _reservationPolicyService= reservationPolicyService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _reservationPolicyService.GetAll());
        }
        public async Task<IActionResult> kurtulusocL()
        {
            return View(await _reservationPolicyService.GetAll());
        }
        public async Task<IActionResult> PolicyManage()
        {
            return View(await _reservationPolicyService.GetAllWithoutParameter());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _reservationPolicyService.GetById(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationPolicy model)
        {
            if (ModelState.IsValid)
            {
                var result = await _reservationPolicyService.Create(model);
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
            var updatePolicy = await _reservationPolicyService.GetById(id);
            if (updatePolicy != null)
            {
                return View(updatePolicy);
            }
            return RedirectToAction(nameof(kurtulusocL));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationPolicy model)
        {
            if (ModelState.IsValid)
            {
                var result = await _reservationPolicyService.Update(model);
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
            var deletePolicy = await _reservationPolicyService.GetById(id);
            if (deletePolicy != null)
            {
                await _reservationPolicyService.Delete(deletePolicy);
                return RedirectToAction(nameof(PolicyManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, ReservationPolicy model)
        {
            var result = await _reservationPolicyService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, ReservationPolicy model)
        {
            var result = await _reservationPolicyService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, ReservationPolicy model)
        {
            var result = await _reservationPolicyService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, ReservationPolicy model)
        {
            var result = await _reservationPolicyService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
