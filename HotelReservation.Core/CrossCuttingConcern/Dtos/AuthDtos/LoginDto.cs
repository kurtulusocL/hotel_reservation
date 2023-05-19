using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.CrossCuttingConcern.Dtos.AuthDtos
{
    public class LoginDto
    {
        [MinLength(4), Required]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(4), Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
