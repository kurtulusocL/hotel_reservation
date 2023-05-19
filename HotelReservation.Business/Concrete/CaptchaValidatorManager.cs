using HotelReservation.Business.Abstract;
using HotelReservation.Core.CrossCuttingConcern.Captche;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HotelReservation.Business.Concrete
{
    public class CaptchaValidatorManager:ICaptchaValidatorService
    {
        private const string GoogleRecaptchaAddress = "https://www.google.com/recaptcha/api/siteverify";

        public readonly IConfiguration Configuration;

        public CaptchaValidatorManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public bool IsRecaptchaValid(string token)
        {
            using var client = new HttpClient();
            var response = client.GetStringAsync($@"{GoogleRecaptchaAddress}?secret={Configuration["Google:RecaptchaV3SecretKey"]}&response={token}").Result;
            var recaptchaResponse = JsonConvert.DeserializeObject<CaptcheResponse>(response);

            if (!recaptchaResponse.Success || recaptchaResponse.Score < Convert.ToDecimal(Configuration["Google:RecaptchaMinScore"]))
            {
                return false;
            }
            return true;
        }
    }
}
