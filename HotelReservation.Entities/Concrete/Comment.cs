using HotelReservation.Core.Entities.EntityFramework;
using HotelReservation.Entities.Concrete.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class Comment : BaseEntity
    {
        [Required]
        public string NameSurname { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Text { get; set; }

        public string? AppUserId { get; set; }
        public int? HotelId { get; set; }
        public int? PictureId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Picture Picture { get; set; }

        public virtual ICollection<CommentAnswer> CommentAnswers { get; set; }
    }
}
