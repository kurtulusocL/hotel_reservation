using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core.CrossCuttingConcern.Dtos.UpdateDtos
{
    public class HotelPromotionUpdateDto
    {
        public int Id { get; set; }
        public bool IsPromotion { get; set; }
    }
}
