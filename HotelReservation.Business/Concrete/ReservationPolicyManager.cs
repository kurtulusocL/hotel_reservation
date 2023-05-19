using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class ReservationPolicyManager : IReservationPolicyService
    {
        readonly IReservationPolicyDal _reservationPolicyDal;
        public ReservationPolicyManager(IReservationPolicyDal reservationPolicyDal)
        {
            _reservationPolicyDal = reservationPolicyDal;
        }
        public async Task<bool> Create(ReservationPolicy entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _reservationPolicyDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(ReservationPolicy entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _reservationPolicyDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ReservationPolicy>> GetAll()
        {
            var result = await _reservationPolicyDal.GetAllAsync(i => i.IsConfirmed == true && i.IsDeleted == false);
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<IEnumerable<ReservationPolicy>> GetAllWithoutParameter()
        {
            var result = await _reservationPolicyDal.GetAllAsync();
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<ReservationPolicy> GetById(int? id)
        {
            if (id != null)
            {
                return await _reservationPolicyDal.GetAsync(i => i.Id == id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _reservationPolicyDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _reservationPolicyDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _reservationPolicyDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _reservationPolicyDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(ReservationPolicy entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _reservationPolicyDal.UpdateAsync(entity);
            return true;
        }
    }
}
