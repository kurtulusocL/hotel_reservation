using HotelReservation.Core.Entities.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class About : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Subtitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
        public int? Hit { get; set; } = 0;
    }
}
