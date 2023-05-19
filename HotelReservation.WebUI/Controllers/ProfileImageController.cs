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
    public class ProfileImageController : Controller
    {
        readonly IProfileImageService _profileImageService;
        public ProfileImageController(IProfileImageService profileImageService)
        {
            _profileImageService = profileImageService;
        }
        public async Task<IActionResult> kurtulusocL()
        {
            return View(await _profileImageService.GetAll());
        }
        public async Task<IActionResult> UserImage(string id)
        {
            return View(await _profileImageService.GetAllProfileImagesByUserId(id));
        }
        public async Task<IActionResult> ImageManage()
        {
            return View(await _profileImageService.GetAllProfileImagesWithoutParameter());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _profileImageService.GetById(id));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteImage = await _profileImageService.GetById(id);
            if (deleteImage != null)
            {
                await _profileImageService.Delete(deleteImage);
                return RedirectToAction(nameof(Detail), new { id = deleteImage.Id });
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, ProfileImage model)
        {
            var result = await _profileImageService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(ImageManage));
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, ProfileImage model)
        {
            var result = await _profileImageService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, ProfileImage model)
        {
            var result = await _profileImageService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, ProfileImage model)
        {
            var result = await _profileImageService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
