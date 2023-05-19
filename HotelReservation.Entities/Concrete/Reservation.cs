using HotelReservation.Core.Entities.EntityFramework;
using HotelReservation.Entities.Concrete.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class Reservation : BaseEntity
    {
        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public int NumberOfPeople { get; set; }

        [Required]
        public int NumberOfRoom { get; set; }

        [Required]
        public bool HasGuide { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
        public bool IsPolicyRead { get; set; }
        public bool IsReservationApproved { get; set; } = false;

        public int? PricingId { get; set; }
        public string AppUserId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Pricing Pricing { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Service Service { get; set; }
        
    }
}
