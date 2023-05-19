using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface ICaptchaValidatorService
    {
        bool IsRecaptchaValid(string token);
    }
}
