using HotelReservation.Core.Entities.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class CommentAnswer : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Answer { get; set; }
        public int? Hit { get; set; } = 0;
        public int? Like { get; set; } = 0;
        public int? Dislike { get; set; } = 0;

        public int? CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
