using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class ProfileImageManager : IProfileImageService
    {
        readonly IProfileImageDal _profileImageDal;
        public ProfileImageManager(IProfileImageDal profileImageDal)
        {
            _profileImageDal = profileImageDal;
        }
        public async Task<bool> Create(ProfileImage entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _profileImageDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(ProfileImage entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _profileImageDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ProfileImage>> GetAll()
        {
            return await _profileImageDal.GetAllProfileImages();
        }

        public async Task<IEnumerable<ProfileImage>> GetAllProfileImagesByUserId(string id)
        {
            if (id != null)
            {
                return await _profileImageDal.GetAllProfileImagesByUserId(id);
            }
            throw new Exception("Id is null");
        }

        public async Task<IEnumerable<ProfileImage>> GetAllProfileImagesWithoutParameter()
        {
            return await _profileImageDal.GetAllProfileImagesWithoutParameter();
        }

        public async Task<ProfileImage> GetById(int? id)
        {
            if (id != null)
            {
                return await _profileImageDal.GetProfileImageById(id);
            }
            throw new Exception("Id is null");
        }

        public ProfileImage GetProfileImageByIdSync(int? id)
        {
            if (id != null)
            {
                return _profileImageDal.GetProfileImageByIdSync(id);
            }
            throw new Exception("Id is null");
        }

        public ProfileImage GetProfileImageByUserIdSync(string id)
        {
            if (id != null)
            {
                return _profileImageDal.GetProfileImageByUserIdSync(id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _profileImageDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _profileImageDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _profileImageDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _profileImageDal.SetNotDeleted(id);
            return true;
        }
    }
}
