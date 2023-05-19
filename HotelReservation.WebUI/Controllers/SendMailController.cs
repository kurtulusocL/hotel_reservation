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
    public class SendMailController : Controller
    {
        readonly ISendMailService _sendMailService;
        public SendMailController(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }
        public IActionResult kurtulusocL(int page = 1)
        {
            return View(_sendMailService.GetAll(page, 25));
        }
        public IActionResult MailManage(int page = 1)
        {
            return View(_sendMailService.GetAllWithoutParameter(page, 35));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _sendMailService.GetById(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SendMail model)
        {
            var result = await _sendMailService.Send(model);
            if (result)
            {
                TempData["success"] = "Mail Sent";
                return RedirectToAction(nameof(Create));
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(Create));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteMail = await _sendMailService.GetById(id);
            if (deleteMail != null)
            {
                await _sendMailService.Delete(deleteMail);
                return RedirectToAction(nameof(MailManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, SendMail model)
        {
            var result = await _sendMailService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, SendMail model)
        {
            var result = await _sendMailService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, SendMail model)
        {
            var result = await _sendMailService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, SendMail model)
        {
            var result = await _sendMailService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
