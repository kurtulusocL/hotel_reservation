using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class ExceptionLoggerManager : IExceptionLoggerService
    {
        readonly IExceptionLoggerDal _loggerDal;
        public ExceptionLoggerManager(IExceptionLoggerDal loggerDal)
        {
            _loggerDal = loggerDal;
        }
        public async Task<bool> Delete(ExceptionLogger entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _loggerDal.DeleteAsync(entity);
            return true;
        }
        public async Task<IEnumerable<ExceptionLogger>> GetAll()
        {
            var result = await _loggerDal.GetAllAsync(i => i.IsDeleted == false && i.IsConfirmed == true);
            return result.OrderByDescending(i=>i.CreatedDate).ToList();
        }
        public async Task<IEnumerable<ExceptionLogger>> GetAllWtihoutParameter()
        {
            var result = await _loggerDal.GetAllAsync(i => i.IsDeleted == false && i.IsConfirmed == true);
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }
        public async Task<ExceptionLogger> GetById(int? id)
        {
            if (id!=null)
            {
                return await _loggerDal.GetAsync(i => i.Id == id);
            }
            throw new Exception("Id is null");
        }
        public async Task<bool> SetActive(int id)
        {
            await _loggerDal.SetActive(id);
            return true;
        }
        public async Task<bool> SetDeActive(int id)
        {
            await _loggerDal.SetDeActive(id);
            return true;
        }
        public async Task<bool> SetDeleted(int id)
        {
            await _loggerDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _loggerDal.SetNotDeleted(id);
            return true;
        }
    }
}
