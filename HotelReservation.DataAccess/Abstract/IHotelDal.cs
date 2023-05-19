using HotelReservation.Core.DataAccess;
using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Abstract
{
    public interface IHotelDal : IEntityRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
        Task<IEnumerable<Hotel>> GetAllHotelsByPromotion();
        Task<IEnumerable<Hotel>> GetAllHotelsWithutParameter();
        Task<Hotel> GetHotelById(int? id);
        Hotel GetHotelByIdSync(int? id);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
