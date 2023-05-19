using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class HomeComment:ViewComponent
    {
        readonly ICommentService _commentService;
        public HomeComment(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_commentService.GetAllCommentsForHome());
        }
    }
}
