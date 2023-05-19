using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IReservationPolicyService
    {
        Task<IEnumerable<ReservationPolicy>> GetAll();
        Task<IEnumerable<ReservationPolicy>> GetAllWithoutParameter();
        Task<ReservationPolicy> GetById(int? id);
        Task<bool> Create(ReservationPolicy entity);
        Task<bool> Update(ReservationPolicy entity);
        Task<bool> Delete(ReservationPolicy entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
