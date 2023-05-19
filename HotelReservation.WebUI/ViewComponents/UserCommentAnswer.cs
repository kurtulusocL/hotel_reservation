using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class UserCommentAnswer : ViewComponent
    {
        readonly ICommentAnswerService _commentAnswerService;
        readonly IHttpContextAccessor _httpContextAccessor;
        public UserCommentAnswer(ICommentAnswerService commentAnswerService, IHttpContextAccessor httpContextAccessor)
        {
            _commentAnswerService = commentAnswerService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke(string id)
        {
            ViewData["userId"]= Convert.ToString(_httpContextAccessor.HttpContext.Session.GetString("userId"));
            id = Convert.ToString(_httpContextAccessor.HttpContext.Session.GetString("userId"));
            return View(_commentAnswerService.GetAllCommentAnswersForUserSync(id));
        }
    }
}
