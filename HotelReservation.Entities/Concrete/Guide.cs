using HotelReservation.Core.Entities.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class Guide : BaseEntity
    {
        [Required]
        public string NameSurname { get; set; }

        [Required]
        public string ShortDesc { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Expertise { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
