using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{    
    public class HeaderContact : ViewComponent
    {
        readonly IContactService _contactService;
        public HeaderContact(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_contactService.GetAllContactForHomeSync());
        }
    }
}
