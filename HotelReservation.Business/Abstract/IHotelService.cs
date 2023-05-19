using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetAll();
        Task<IEnumerable<Hotel>> GetAllHotelsByPromotion();
        Task<IEnumerable<Hotel>> GetAllHotelsWithoutParameter();
        Task<Hotel> GetById(int? id);
        Hotel GetHotelByIdSync(int? id);
        Task<bool> Create(Hotel entity);
        Task<bool> Update(Hotel entity);
        Task<bool> Delete(Hotel entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
