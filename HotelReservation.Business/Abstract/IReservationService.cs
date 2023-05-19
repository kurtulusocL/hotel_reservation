using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAll(int page, int pageCount);
        IEnumerable<Reservation> GetAllApprovedReservations(int page, int pageCount);
        IEnumerable<Reservation> GetAllNotApprovedReservations(int page, int pageCount);
        IEnumerable<Reservation> GetAllReservationsWithoutParameter(int page, int pageCount);
        IEnumerable<Reservation> GetAllReservationsByUserId(string userId, int page, int pageCount);
        IEnumerable<Reservation> GetAllReservationsByPriceId(int? id, int page, int pageCount);
        IEnumerable<Reservation> GetAllReservationsByServiceId(int? id, int page, int pageCount);
        Task<IEnumerable<Reservation>> GetAllConfirmedReservationForUserByUserId(string userId);
        Task<IEnumerable<Reservation>> GetAllReservationByUserId(string userId);
        IEnumerable<Reservation> GetAllReservationForAdmin();
        IEnumerable<Reservation> GetAllLastReservationForAdmin();
        IEnumerable<Reservation> GetAllSomeReservationForAdmin();
        IEnumerable<Reservation> GetAllConfirmedReservationByUserId(string userId);
        IEnumerable<Reservation> GetAllReservationsByUserIdSync(string userId);
        Task<Reservation> GetById(int? id);
        Task<bool> Create(Reservation entity);
        Task<bool> Update(Reservation entity);
        Task<bool> Delete(Reservation entity);
        Task<bool> SetApproved(int id);
        Task<bool> SetNotApproved(int id);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
