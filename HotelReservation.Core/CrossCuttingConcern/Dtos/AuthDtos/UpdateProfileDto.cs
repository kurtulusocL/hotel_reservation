using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.CrossCuttingConcern.Dtos.AuthDtos
{
    public class UpdateProfileDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Gender { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsConfirm { get; set; } = true;
    }
}
