using HotelReservation.Business.CrossCuttingConcern.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Controllers
{
    [ExceptionHandler]
    [AuditLog]
    public class ErrorController : Controller
    {
        public IActionResult NotFound(int code = 0)
        {
            TempData["404"] = "NotFound";
            return View(code);
        }
    }
}
