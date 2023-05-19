using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class CommentAnswerHit:ViewComponent
    {
        readonly ICommentAnswerService _commentAnswerService;
        public CommentAnswerHit(ICommentAnswerService commentAnswerService)
        {
            _commentAnswerService=commentAnswerService;
        }
        public IViewComponentResult Invoke(int? id)
        {
            return View(_commentAnswerService.HitRead(id));
        }
    }
}
