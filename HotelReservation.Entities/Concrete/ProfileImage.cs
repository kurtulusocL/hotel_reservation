using HotelReservation.Core.Entities.EntityFramework;
using HotelReservation.Entities.Concrete.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class ProfileImage : BaseEntity
    {
        [Required]
        public string Image { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
