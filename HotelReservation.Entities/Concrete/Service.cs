using HotelReservation.Core.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Entities.Concrete
{
    public class Service : BaseEntity
    {
        public string ServiceType { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
