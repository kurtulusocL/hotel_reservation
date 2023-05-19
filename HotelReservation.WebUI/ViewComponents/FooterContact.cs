using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class FooterContact : ViewComponent
    {
        readonly IContactService _contactService;
        public FooterContact(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_contactService.GetAllContactForHomeSync());
        }
    }
}