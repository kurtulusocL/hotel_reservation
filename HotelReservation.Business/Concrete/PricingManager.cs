using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class PricingManager : IPricingService
    {
        readonly IPricingDal _pricingDal;
        public PricingManager(IPricingDal pricingDal)
        {
            _pricingDal = pricingDal;
        }
        public async Task<bool> Create(Pricing entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _pricingDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Pricing entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _pricingDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<Pricing>> GetAll()
        {
            return await _pricingDal.GetAllPricings();
        }

        public IEnumerable<Pricing> GetAllPricingsForAdmin()
        {
            return _pricingDal.GetAllPricingsForAdmin();
        }

        public IEnumerable<Pricing> GetAllPricingsForUser()
        {
            return _pricingDal.GetAllPricingsForUser();
        }

        public async Task<IEnumerable<Pricing>> GetAllWtihoutParameter()
        {
            return await _pricingDal.GetAllWtihoutParameter();
        }

        public async Task<Pricing> GetById(int? id)
        {
            if (id!=null)
            {
                return await _pricingDal.GetPricingById(id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _pricingDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _pricingDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _pricingDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _pricingDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(Pricing entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _pricingDal.UpdateAsync(entity);
            return true;
        }
    }
}
