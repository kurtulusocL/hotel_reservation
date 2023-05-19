using HotelReservation.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.ViewComponents
{
    public class AdminPricing : ViewComponent
    {
        readonly IPricingService _pricingService;
        public AdminPricing(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_pricingService.GetAllPricingsForAdmin());
        }
    }
}
