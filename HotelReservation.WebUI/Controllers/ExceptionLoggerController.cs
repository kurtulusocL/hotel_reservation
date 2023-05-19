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
    public class ExceptionLoggerController : Controller
    {
        readonly IExceptionLoggerService _loggerService;
        public ExceptionLoggerController(IExceptionLoggerService loggerService)
        {
            _loggerService = loggerService;
        }
        public async Task<IActionResult> kurtulusocL()
        {
            return View(await _loggerService.GetAll());
        }
        public async Task<IActionResult> LoggerManage()
        {
            return View(await _loggerService.GetAllWtihoutParameter());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _loggerService.GetById(id));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteLog = await _loggerService.GetById(id);
            if (deleteLog != null)
            {
                await _loggerService.Delete(deleteLog);
                return RedirectToAction(nameof(LoggerManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, ExceptionLogger model)
        {
            var result = await _loggerService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, ExceptionLogger model)
        {
            var result = await _loggerService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, ExceptionLogger model)
        {
            var result = await _loggerService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, ExceptionLogger model)
        {
            var result = await _loggerService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
