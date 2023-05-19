using HotelReservation.Core.Entities.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class SocialMedia : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required, Url]
        public string Url { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
