using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class OurServiceManager : IOurServiceService
    {
        readonly IServiceDal _serviceDal;
        public OurServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }
        public async Task<bool> Create(Service entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _serviceDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Service entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _serviceDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await _serviceDal.GetAllServices();
        }

        public IEnumerable<Service> GetAllServicesForAdmin()
        {
            return _serviceDal.GetAllServicesForAdmin();
        }

        public IEnumerable<Service> GetAllServicesForUser()
        {
            return _serviceDal.GetAllServicesForUser();
        }

        public async Task<IEnumerable<Service>> GetAllServicesWithoutParameter()
        {
            return await _serviceDal.GetAllServicesWithoutParameter();
        }

        public IEnumerable<Service> GetAllSync()
        {
            return _serviceDal.GetAllServiceSync();
        }

        public async Task<Service> GetById(int? id)
        {
            if (id!=null)
            {
                return await _serviceDal.GetServiceById(id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _serviceDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _serviceDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _serviceDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _serviceDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(Service entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _serviceDal.UpdateAsync(entity);
            return true;
        }
    }
}
