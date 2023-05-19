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
    public class CommentController : Controller
    {
        readonly ICommentService _commentService;
        readonly ICommentAnswerService _commentAnswerService;
        public CommentController(ICommentService commentService, ICommentAnswerService commentAnswerService)
        {
            _commentService = commentService;
            _commentAnswerService = commentAnswerService;
        }
        public IActionResult kurtulusocL(int page = 1)
        {
            return View(_commentService.GetAll(page, 65));
        }
        public IActionResult Hotel(int? id, int page = 1)
        {
            return View(_commentService.GetAllCommentsByHotelId(id, page, 45));
        }
        public IActionResult Picture(int? id, int page = 1)
        {
            return View(_commentService.GetAllCommentsByPictureId(id, page, 45));
        }
        public IActionResult CommentManage(int page = 1)
        {
            return View(_commentService.GetAllCommentsWithoutParameter(page, 80));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _commentService.GetById(id));
        }
        public async Task<IActionResult> CreateAnswer(int? id)
        {
            ViewBag.CommentId = await _commentService.GetById(id);
            CommentAnswer model = new CommentAnswer()
            {
                CommentId = id
            };
            return View("CreateAnswer", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnswer(int? commentId, string title, string answer)
        {
            var model = new CommentAnswer
            {
                CommentId = commentId,
                Title = title,
                Answer = answer
            };
            var result = await _commentAnswerService.Create(model);
            if (result)
            {
                TempData["success"] = "Created";
                return RedirectToAction(nameof(CreateAnswer), new { id = model.CommentId });
            }
            TempData["error"] = "Mistake";
            return RedirectToAction(nameof(CreateAnswer), new { id = model.CommentId });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var deleteComment = await _commentService.GetById(id);
            if (deleteComment != null)
            {
                await _commentService.Delete(deleteComment);
                return RedirectToAction(nameof(CommentManage));
            }
            return RedirectToAction(nameof(kurtulusocL));
        }
        public async Task<IActionResult> Active(int id, Comment model)
        {
            var result = await _commentService.SetActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> DeActive(int id, Comment model)
        {
            var result = await _commentService.SetDeActive(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> Deleted(int id, Comment model)
        {
            var result = await _commentService.SetDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
        public async Task<IActionResult> NotDeleted(int id, Comment model)
        {
            var result = await _commentService.SetNotDeleted(id);
            if (result)
            {
                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }
            return RedirectToAction(nameof(Detail), new { id = model.Id });
        }
    }
}
