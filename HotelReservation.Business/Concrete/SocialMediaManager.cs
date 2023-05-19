using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        readonly ISocialMediaDal _socialMediaDal;
        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }
        public async Task<bool> Create(SocialMedia entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _socialMediaDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(SocialMedia entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _socialMediaDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<SocialMedia>> GetAll()
        {
            var result = await _socialMediaDal.GetAllAsync(i => i.IsDeleted == false && i.IsConfirmed == true);
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public IEnumerable<SocialMedia> GetAllSync()
        {
            return _socialMediaDal.GetAll(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<IEnumerable<SocialMedia>> GetAllWithoutParameter()
        {
            var result = await _socialMediaDal.GetAllAsync();
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<SocialMedia> GetById(int? id)
        {
            if (id != null)
            {
                return await _socialMediaDal.GetAsync(i => i.Id == id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _socialMediaDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _socialMediaDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _socialMediaDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _socialMediaDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(SocialMedia entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _socialMediaDal.UpdateAsync(entity);
            return true;
        }
    }
}
