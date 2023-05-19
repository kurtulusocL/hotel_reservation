using HotelReservation.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.WebUI.Extensions
{
    public static class UrlHelperExtension
    {
        //public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        //{
        //    return urlHelper.Action(
        //        action: nameof(UserAuthController.ConfirmEmail),
        //        controller: "Account",
        //        values: new { userId, code },
        //        protocol: scheme);
        //}

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(UserAuthController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
