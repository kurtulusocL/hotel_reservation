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
    public class CommentAnswerController : Controller
    {
        readonly ICommentAnswerService _commentAnswerService;
        public CommentAnswerController(ICommentAnswerService commentAnswerService)
        {
            _commentAnswerService = commentAnswerService;
        }        
        public IActionResult kurtulusocL(int page = 1)
        {
            return View(_commentAnswerService.GetAll(page, 30));
        }
        public IActionResult Comment(int? id)
        {
            return View(_commentAnswerService.GetAllCommentAnswersByCommentId(id));
        }
        public IActionResult AnswerManage(int page = 1)
        {
            return View(_commentAnswerService.GetAllCommentAnswersWithoutParameter(page, 40));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _commentAnswerService.GetById(id));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteAbout = await _commentAnswerService.GetById(id);
            if (deleteAbout != null)
            {
                await _commentAnswerService.Delete(deleteAbout);
                return RedirectToAction(nameof(AnswerManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, CommentAnswer model)
        {
            var result = await _commentAnswerService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, CommentAnswer model)
        {
            var result = await _commentAnswerService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, CommentAnswer model)
        {
            var result = await _commentAnswerService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, CommentAnswer model)
        {
            var result = await _commentAnswerService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
