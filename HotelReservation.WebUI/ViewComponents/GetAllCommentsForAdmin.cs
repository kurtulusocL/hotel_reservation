using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class GetAllCommentsForAdmin:ViewComponent
    {
        readonly ICommentService _commentService;
        public GetAllCommentsForAdmin(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_commentService.GetAllCommentsForAdmin());
        }
    }
}
