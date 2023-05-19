using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class ImageComment : ViewComponent
    {
        readonly ICommentService _commentService;
        public ImageComment(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke(int? id)
        {
            return View(_commentService.GetAllCommentsByPictureIdSync(id));
        }
    }
}
