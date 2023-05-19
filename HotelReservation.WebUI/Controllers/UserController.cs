using HotelReservation.Business.Abstract;
using HotelReservation.Business.CrossCuttingConcern.Attributes;
using HotelReservation.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Controllers
{
    [ExceptionHandler]
    [AuditLog]
    [Authorize(Roles = "Admins, AsistantAdmins")]
    public class UserController : Controller
    {
        readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult kurtulusocL(int page = 1)
        {
            return View(_userService.GetAll(page, 35));
        }
        public IActionResult Admin(int page = 1)
        {
            return View(_userService.GetAllAdminUsers(page, 35));
        }
        public IActionResult MemberUser(int page = 1)
        {
            return View(_userService.GetAllMemberUser(page, 35));
        }
        public IActionResult UserManage(int page = 1)
        {
            return View(_userService.GetAllUsersWithoutParameter(page, 45));
        }
        public async Task<IActionResult> Detail(string id)
        {
            return View(await _userService.GetById(id));
        }
        public async Task<IActionResult> Delete(string id)
        {
            var deleteUser = await _userService.GetById(id);
            if (deleteUser != null)
            {
                await _userService.Delete(deleteUser);
                return RedirectToAction(nameof(UserManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(string id, AppRole model)
        {
            var result = await _userService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(string id, AppRole model)
        {
            var result = await _userService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(string id, AppRole model)
        {
            var result = await _userService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(string id, AppUser model)
        {
            var result = await _userService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
