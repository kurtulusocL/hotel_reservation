using HotelReservation.Core.CrossCuttingConcern.Audit;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using HotelReservation.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelReservation.Business.CrossCuttingConcern.Attributes
{
    public class AuditLogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            AppUser user = new AppUser();
            var request = filterContext.HttpContext.Request;
            Audit audit = new Audit()
            {
                UserName = (request.HttpContext.User.Identity.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                // IPAddress = request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                UserId = user.Id,
                IPAddress = IpAddress.FindUserIp(),
                Browser = request.HttpContext.Request.Headers["User-Agent"].ToString(),
                BrowserVersion = request.HttpContext.Request.Headers["User-Agent-Version"].ToString(),
                Language = request.HttpContext.Request.Headers["Accept-Language"].ToString(),
                AreaAccessed = request.HttpContext.Request.QueryString.ToUriComponent(),
                //Browser = request.HttpContext.Request.Browser.Browser,
                //IsMobile = request.Browser.IsMobileDevice,
                //DeviceModel = request.Browser.MobileDeviceModel,
                //Platform = request.Browser.Platform,
                MacAddress = MacAddress.GetMACAddress(),
                CreatedDate = DateTime.Now
            };

            ApplicationDbContext context = new ApplicationDbContext();
            context.Audits.Add(audit);
            context.SaveChanges();
            base.OnActionExecuting(filterContext);
        }
    }
}
