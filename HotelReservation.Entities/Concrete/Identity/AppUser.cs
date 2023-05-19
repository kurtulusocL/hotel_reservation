using HotelReservation.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete.Identity
{
    public class AppUser : IdentityUser, IEntity
    {
        [Required]
        public string NameSurname { get; set; }

        [Required]
        public string Gender { get; set; }
        public string? Title { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Country { get; set; }
        public bool IsConfirmed { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<ProfileImage> ProfileImages { get; set; }

    }
}
