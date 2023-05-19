using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        readonly IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }
        public async Task<bool> Create(Reservation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var addWithTotalPrice = _reservationDal.AccountTotalPrice(entity, entity.TotalPrice);
            await _reservationDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Reservation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _reservationDal.DeleteAsync(entity);
            return true;
        }

        public IEnumerable<Reservation> GetAll(int page, int pageCount)
        {
            return _reservationDal.GetAllReservations(page, 35);
        }

        public IEnumerable<Reservation> GetAllApprovedReservations(int page, int pageCount)
        {
            return _reservationDal.GetAllApprovedReservations(page, 35);
        }

        public IEnumerable<Reservation> GetAllConfirmedReservationByUserId(string userId)
        {
            if (userId!=null)
            {
                return _reservationDal.GetAllConfirmedReservationByUserId(userId);
            }
            throw new Exception("User Id is null");
        }

        public async Task<IEnumerable<Reservation>> GetAllConfirmedReservationForUserByUserId(string userId)
        {
            if (userId!=null)
            {
                return await _reservationDal.GetAllConfirmedReservationForUserByUserId(userId);
            }
            throw new Exception("User Id is null");
        }

        public IEnumerable<Reservation> GetAllLastReservationForAdmin()
        {
            return _reservationDal.GetAllLastReservationForAdmin();
        }

        public IEnumerable<Reservation> GetAllNotApprovedReservations(int page, int pageCount)
        {
            return _reservationDal.GetAllNotApprovedReservations(page, 35);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationByUserId(string userId)
        {
            if (userId != null)
            {
                return await _reservationDal.GetAllReservationByUserId(userId);
            }
            throw new Exception("User Id is null");
        }

        public IEnumerable<Reservation> GetAllReservationForAdmin()
        {
            return _reservationDal.GetAllReservationForAdmin();
        }

        public IEnumerable<Reservation> GetAllReservationsByPriceId(int? id, int page, int pageCount)
        {
            if (id != null)
            {
                return _reservationDal.GetAllReservationsByPriceId(id, page, 35);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<Reservation> GetAllReservationsByServiceId(int? id, int page, int pageCount)
        {
            if (id != null)
            {
                return _reservationDal.GetAllReservationsByServiceId(id, page, 35);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<Reservation> GetAllReservationsByUserId(string userId, int page, int pageCount)
        {
            if (userId != null)
            {
                return _reservationDal.GetAllReservationsByUserId(userId, page, 35);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<Reservation> GetAllReservationsByUserIdSync(string userId)
        {
            if (userId != null)
            {
                return _reservationDal.GetAllReservationsByUserIdSync(userId);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<Reservation> GetAllReservationsWithoutParameter(int page, int pageCount)
        {
            return _reservationDal.GetAllReservationsWithoutParameter(page, 35);
        }

        public IEnumerable<Reservation> GetAllSomeReservationForAdmin()
        {
            return _reservationDal.GetAllSomeReservationForAdmin();
        }

        public async Task<Reservation> GetById(int? id)
        {
            if (id != null)
            {
                return await _reservationDal.GetReservationById(id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _reservationDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetApproved(int id)
        {
            await _reservationDal.SetApproved(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _reservationDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _reservationDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotApproved(int id)
        {
            await _reservationDal.SetNotApproved(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _reservationDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(Reservation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _reservationDal.UpdateAsync(entity);
            return true;
        }
    }
}
