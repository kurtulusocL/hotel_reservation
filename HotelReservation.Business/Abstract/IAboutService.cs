using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IAboutService
    {
        Task<IEnumerable<About>> GetAll();
        Task<IEnumerable<About>> GetAllWtihoutParameter();
        Task<About> GetById(int? id);
        About HitRead(int? id);
        Task<bool> Create(About entity);
        Task<bool> Update(About entity);
        Task<bool> Delete(About entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
