using HotelReservation.Core.Entities.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class Picture : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }      

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
