using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class HotelComment : ViewComponent
    {
        readonly ICommentService _commentService;
        public HotelComment(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke(int? id)
        {
            return View(_commentService.GetAllCommentsByHotelIdSync(id));
        }
    }
}
