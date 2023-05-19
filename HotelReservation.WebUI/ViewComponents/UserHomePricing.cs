using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class UserHomePricing : ViewComponent
    {
        readonly IPricingService _pricingService;
        public UserHomePricing(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_pricingService.GetAllPricingsForUser());
        }
    }
}
