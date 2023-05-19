using HotelReservation.Core.Entities.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class Hotel : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsPromotion { get; set; } = false;

        [Required]
        public string CoverImage { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
