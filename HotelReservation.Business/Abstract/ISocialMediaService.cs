using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface ISocialMediaService
    {
        Task<IEnumerable<SocialMedia>> GetAll();
        IEnumerable<SocialMedia> GetAllSync();
        Task<IEnumerable<SocialMedia>> GetAllWithoutParameter();
        Task<SocialMedia> GetById(int? id);
        Task<bool> Create(SocialMedia entity);
        Task<bool> Update(SocialMedia entity);
        Task<bool> Delete(SocialMedia entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
