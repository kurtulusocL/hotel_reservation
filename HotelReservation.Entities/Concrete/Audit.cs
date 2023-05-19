using HotelReservation.Core.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities.Concrete
{
    public class Audit : BaseEntity
    {
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        public string? IPAddress { get; set; }
        public string? AreaAccessed { get; set; }
        public string? Browser { get; set; }
        public string? Device { get; set; }
        public string? Language { get; set; }
        public string? BrowserVersion { get; set; }
        public bool? IsMobile { get; set; }
        public string? DeviceModel { get; set; }
        public string? Platform { get; set; }
        public string? MacAddress { get; set; }
    }
}
