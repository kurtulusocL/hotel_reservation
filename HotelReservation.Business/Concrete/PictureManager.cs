using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class PictureManager : IPictureService
    {
        readonly IPictureDal _pictureDal;
        public PictureManager(IPictureDal pictureDal)
        {
            _pictureDal = pictureDal;
        }
        public void Create(Picture entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _pictureDal.Create(entity);
        }

        public async Task CreateSync(Picture entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _pictureDal.AddAsync(entity);
        }

        public async Task<bool> Delete(Picture entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _pictureDal.DeleteAsync(entity);
            return true;
        }

        public IEnumerable<Picture> GetAll(int page, int pageCount)
        {
            return  _pictureDal.GetAllPictures(page, 45);
        }

        public async Task<IEnumerable<Picture>> GetAllPictures()
        {
            return await _pictureDal.GetAllPictures();
        }

        public IEnumerable<Picture> GetAllPicturesForHomeSync()
        {
            return _pictureDal.GetAllPicturesForHomeSync();
        }

        public IEnumerable<Picture> GetAllPicturesSync()
        {
            return _pictureDal.GetAllPicturesSync();
        }

        public IEnumerable<Picture> GetAllPicturesWithoutParameter(int page, int pageCount)
        {
            return  _pictureDal.GetAllPicturesWithoutParameter(page, 55);
        }

        public async Task<Picture> GetById(int? id)
        {
            if (id != null)
            {
                return await _pictureDal.GetPitureById(id);
            }
            throw new Exception("Id is null");
        }

        public Picture GetPictureByIdSync(int? id)
        {
            if (id != null)
            {
                return _pictureDal.GetPictureByIdSync(id);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<Picture> GetPictureSync()
        {
            return _pictureDal.GetPictureSync();
        }

        public async Task<bool> SetActive(int id)
        {
            await _pictureDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _pictureDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _pictureDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _pictureDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(Picture entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _pictureDal.UpdateAsync(entity);
            return true;
        }
    }
}