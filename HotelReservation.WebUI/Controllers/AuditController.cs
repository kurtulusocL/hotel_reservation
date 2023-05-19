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
    public class AuditController : Controller
    {
        readonly IAuditService _auditService;
        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }
        public IActionResult kurtulusocL(int page = 1)
        {
            return View(_auditService.GetAll(page, 55));
        }
        public IActionResult Visitor(int page = 1)
        {
            return View(_auditService.GetAllVisitorAuidts(page, 45));
        }
        public IActionResult UserAudit(int page = 1)
        {
            return View(_auditService.GetAllUserAuidts(page, 45));
        }
        public IActionResult AuditManage(int page = 1)
        {
            return View(_auditService.GetAllWtihoutParameter(page, 65));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _auditService.GetById(id));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteAudit = await _auditService.GetById(id);
            if (deleteAudit != null)
            {
                await _auditService.Delete(deleteAudit);
                return RedirectToAction(nameof(AuditManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, Audit model)
        {
            var result = await _auditService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, Audit model)
        {
            var result = await _auditService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, Audit model)
        {
            var result = await _auditService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, Audit model)
        {
            var result = await _auditService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
