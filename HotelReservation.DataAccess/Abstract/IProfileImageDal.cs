using HotelReservation.Core.DataAccess;
using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Abstract
{
    public interface IProfileImageDal : IEntityRepository<ProfileImage>
    {
        Task<IEnumerable<ProfileImage>> GetAllProfileImages(); 
        Task<IEnumerable<ProfileImage>> GetAllProfileImagesByUserId(string id);
        Task<IEnumerable<ProfileImage>> GetAllProfileImagesWithoutParameter();
        Task<ProfileImage> GetProfileImageById(int? id);
        ProfileImage GetProfileImageByIdSync(int? id);
        ProfileImage GetProfileImageByUserIdSync(string id);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
