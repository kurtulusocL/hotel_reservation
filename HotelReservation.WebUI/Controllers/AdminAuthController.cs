using HotelReservation.Business.CrossCuttingConcern.Attributes;
using HotelReservation.Core.CrossCuttingConcern.Dtos.AuthDtos;
using HotelReservation.Core.CrossCuttingConcern.ViewModels;
using HotelReservation.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Controllers
{
    [ExceptionHandler]
    [AuditLog]
    public class AdminAuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        readonly IHttpContextAccessor _httpContextAccessor;
        public AdminAuthController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [TempData]
        public string? StatusMessage { get; set; }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginDto()
            {
                ReturnUrl = returnUrl
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("userId", user.Id);
                _httpContextAccessor.HttpContext.Session.SetString("userNameSurname", user.NameSurname);

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return RedirectToAction("Index", "HomeAdmin", new { id = user.Id });
                    return Redirect(model.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Username or password not found");
            return View(model);
        }

        [Authorize(Roles = "Admins, AsistantAdmins")]
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [Authorize(Roles = "Admins, AsistantAdmins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var user = new AppUser
            {
                UserName = model.Username,
                Email = model.Email,
                NameSurname = model.NameSurname,
                Title = model.Title,
                Birthdate = model.Birthdate,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                Country = model.Country,
                IsConfirmed = true,
                CreatedDate = DateTime.Now.ToLocalTime()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(Register));
        }

        [Authorize(Roles = "Admins, AsistantAdmins")]
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToAction(nameof(Login));
            }

            var model = new ChangePasswordDto { StatusMessage = StatusMessage };
            return View(model);
        }

        [Authorize(Roles = "Admins, AsistantAdmins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                TempData["error"] = "Mistake";
                return View(model);
            }
            await _signInManager.SignInAsync(user, isPersistent: false);

            StatusMessage = "Your password has been changed.";
            return RedirectToAction(nameof(ChangePassword));
        }

        [Authorize(Roles = "Admins, AsistantAdmins")]
        public async Task<ActionResult> UpdateProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            UpdateProfileDto model = new UpdateProfileDto();
            model.PhoneNumber = user.PhoneNumber;
            model.Email = user.Email;
            model.Username = user.UserName;
            model.Gender = user.Gender;

            return View(model);
        }

        [Authorize(Roles = "Admins, AsistantAdmins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateProfile(UpdateProfileDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.UserName = model.Username;
                user.Gender = model.Gender;
                user.UpdatedDate = DateTime.Now.ToLocalTime();

                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["success"] = "Profile Updated!";
                    return RedirectToAction(nameof(UpdateProfile));
                }
            }
            TempData["error"] = "There was an error!";
            return RedirectToAction(nameof(UpdateProfile));
        }

        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> RoleAssign(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            List<AppRole> allRoles = _roleManager.Roles.ToList();
            List<string>? userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignVM> assignRoles = new List<RoleAssignVM>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignVM
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));

            return View(assignRoles);
        }

        [Authorize(Roles = "Admins")]
        [HttpPost]
        public async Task<ActionResult> RoleAssign(List<RoleAssignVM> modelList, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignVM role in modelList)
            {
                if (role.HasAssign)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return RedirectToAction("Admin", "User");
        }

        [Authorize(Roles = "Admins, AsistantAdmins")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
