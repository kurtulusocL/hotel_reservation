using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class HotelCommentAnswer:ViewComponent
    {
        readonly ICommentAnswerService _commentAnswerService;
        public HotelCommentAnswer(ICommentAnswerService commentAnswerService)
        {
            _commentAnswerService= commentAnswerService;
        }
        public IViewComponentResult Invoke(int? id)
        {
            return View(_commentAnswerService.GetAllCommentAnswersByCommentIdSync(id));
        }
    }
}
