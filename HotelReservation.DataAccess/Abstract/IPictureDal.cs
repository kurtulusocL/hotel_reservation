using HotelReservation.Core.DataAccess;
using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Abstract
{
    public interface IPictureDal : IEntityRepository<Picture>
    {
        Task<IEnumerable<Picture>> GetAllPictures();
        IEnumerable<Picture> GetAllPictures(int page, int pageCount);        
        IEnumerable<Picture> GetAllPicturesWithoutParameter(int page, int pageCount);
        Task<Picture> GetPitureById(int? id);
        IEnumerable<Picture> GetPictureSync();
        IEnumerable<Picture> GetAllPicturesSync();
        IEnumerable<Picture> GetAllPicturesForHomeSync();
        Picture GetPictureByIdSync(int? id);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
