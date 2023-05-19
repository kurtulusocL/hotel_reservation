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
    public class ReservationController : Controller
    {
        readonly IReservationService _reservationService;        
        readonly IOurServiceService _ourService;
        readonly IHttpContextAccessor _contextAccessor;
        public ReservationController(IReservationService reservationService, IOurServiceService ourService, IHttpContextAccessor contextAccessor)
        {
            _reservationService = reservationService;           
            _ourService = ourService;
            _contextAccessor = contextAccessor;
        }

        [AllowAnonymous]
        public async Task<IActionResult> CreateReservation()
        {
            ViewBag.Services = await _ourService.GetAll();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReservation(DateTime entryDate, DateTime departureDate, int numberOfPeople, int numberOfRoom, bool hasGuide, decimal totalPrice, bool isPolicyReady, int? pricingId, int? serviceId, string appUserId)
        {
            appUserId = Convert.ToString(_contextAccessor.HttpContext.Session.GetString("userId"));
            var model = new Reservation
            {
                EntryDate = entryDate,
                DepartureDate = departureDate,
                NumberOfPeople = numberOfPeople,
                NumberOfRoom = numberOfRoom,
                HasGuide = hasGuide,
                TotalPrice = totalPrice,
                IsPolicyRead = isPolicyReady,
                PricingId = pricingId,
                ServiceId = serviceId,
                AppUserId = appUserId
            };
            var result = await _reservationService.Create(model);
            if (result)
            {
                TempData["success"] = "Your reservation has been created. You can check to reservation informations from your dashboard. Thank you for use to our service.";
                return RedirectToAction(nameof(CreateReservation));
            }
            TempData["error"] = "There was an error while creating to reservation. Please check to reservation form and try again.";
            return RedirectToAction(nameof(CreateReservation));
        }
        public IActionResult kurtulusocL(int page = 1)
        {
            return View(_reservationService.GetAll(page, 35));
        }
        public IActionResult ReservationManage(int page = 1)
        {
            return View(_reservationService.GetAllReservationsWithoutParameter(page, 55));
        }
        public IActionResult Pricing(int? id, int page = 1)
        {
            return View(_reservationService.GetAllReservationsByPriceId(id, page, 35));
        }
        public IActionResult UserReservation(string id, int page = 1)
        {
            return View(_reservationService.GetAllReservationsByUserId(id, page, 35));
        }
        public IActionResult Service(int? id, int page = 1)
        {
            return View(_reservationService.GetAllReservationsByServiceId(id, page, 35));
        }
        public IActionResult NotApprovedReservation(int page = 1)
        {
            return View(_reservationService.GetAllNotApprovedReservations(page, 35));
        }
        public IActionResult ApprovedReservation(int page = 1)
        {
            return View(_reservationService.GetAllApprovedReservations(page, 35));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _reservationService.GetById(id));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteReservation = await _reservationService.GetById(id);
            if (deleteReservation != null)
            {
                await _reservationService.Delete(deleteReservation);
                return RedirectToAction(nameof(ReservationManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> SetApproved(int id)
        {
            var result = await _reservationService.SetApproved(id);
            if (result)
            {
                return RedirectToAction(nameof(NotApprovedReservation));
            }
            return RedirectToAction(nameof(Detail));
        }
        public async Task<IActionResult> SetNotApproved(int id)
        {
            var result = await _reservationService.SetNotApproved(id);
            if (result)
            {
                return RedirectToAction(nameof(ApprovedReservation));
            }
            return RedirectToAction(nameof(ApprovedReservation));
        }
        public async Task<IActionResult> Active(int id, Reservation model)
        {
            var result = await _reservationService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, Reservation model)
        {
            var result = await _reservationService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, Reservation model)
        {
            var result = await _reservationService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, Reservation model)
        {
            var result = await _reservationService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
