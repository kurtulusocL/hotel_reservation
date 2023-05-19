using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class GuideManager : IGuideService
    {
        readonly IGuideDal _guideDal;
        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }
        public async Task<bool> Create(Guide entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _guideDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Guide entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _guideDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<Guide>> GetAll()
        {
            var result = await _guideDal.GetAllAsync(i => i.IsDeleted == false && i.IsConfirmed == true);
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public IEnumerable<Guide> GetAllGuidesForAbout()
        {
            return _guideDal.GetAll(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i => Guid.NewGuid()).Take(4).ToList();
        }

        public async Task<IEnumerable<Guide>> GetAllWtihoutParameter()
        {
            var result = await _guideDal.GetAllAsync();
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<Guide> GetById(int? id)
        {
            if (id!=null)
            {
                return await _guideDal.GetAsync(i => i.Id == id);
            }
            throw new Exception("Id is not null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _guideDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _guideDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _guideDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _guideDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(Guide entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _guideDal.UpdateAsync(entity);
            return true;
        }
    }
}
