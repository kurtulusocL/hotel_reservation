using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        readonly IHotelDal _hotelDal;
        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal = hotelDal;
        }
        public async Task<bool> Create(Hotel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _hotelDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Hotel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _hotelDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<Hotel>> GetAll()
        {
            return await _hotelDal.GetAllHotels();
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsByPromotion()
        {
            return await _hotelDal.GetAllHotelsByPromotion();
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsWithoutParameter()
        {
            return await _hotelDal.GetAllHotelsWithutParameter();
        }

        public async Task<Hotel> GetById(int? id)
        {
            if (id!=null)
            {
                return await _hotelDal.GetHotelById(id);
            }
            throw new Exception("Id is null");
        }

        public Hotel GetHotelByIdSync(int? id)
        {
            if(id != null)
            {
                return _hotelDal.GetHotelByIdSync(id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _hotelDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _hotelDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _hotelDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _hotelDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(Hotel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _hotelDal.UpdateAsync(entity);
            return true;
        }
    }
}
