using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IPictureService
    {
        Task<IEnumerable<Picture>> GetAllPictures();
        IEnumerable<Picture> GetAll(int page, int pageCount);
        IEnumerable<Picture> GetAllPicturesWithoutParameter(int page, int pageCount);
        Task<Picture> GetById(int? id);
        IEnumerable<Picture> GetAllPicturesSync();
        IEnumerable<Picture> GetAllPicturesForHomeSync();
        IEnumerable<Picture> GetPictureSync();
        Picture GetPictureByIdSync(int? id);
        Task CreateSync(Picture entity);
        void Create(Picture entity);
        Task<bool> Update(Picture entity);
        Task<bool> Delete(Picture entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
