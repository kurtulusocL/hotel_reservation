using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IProfileImageService
    {
        Task<IEnumerable<ProfileImage>> GetAll();
        Task<IEnumerable<ProfileImage>> GetAllProfileImagesByUserId(string id);
        Task<IEnumerable<ProfileImage>> GetAllProfileImagesWithoutParameter();
        Task<ProfileImage> GetById(int? id);
        ProfileImage GetProfileImageByIdSync(int? id);
        ProfileImage GetProfileImageByUserIdSync(string id);
        Task<bool> Create(ProfileImage entity);
        Task<bool> Delete(ProfileImage entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
