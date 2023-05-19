using HotelReservation.Core.Entities.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Entities.Concrete
{
    public class SendMail : BaseEntity
    {
        [Required, EmailAddress]
        public string RecieverEmail { get; set; }

        [Required, EmailAddress]
        public string SenderEmail { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
