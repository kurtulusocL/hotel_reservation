using HotelReservation.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IRoleService
    {
        Task<IEnumerable<AppRole>> GetAll();
        Task<IEnumerable<AppRole>> GetAllWtihoutParameter();
        Task<AppRole> GetById(string id);
        Task<bool> Create(AppRole entity);
        Task<bool> Update(AppRole entity);
        Task<bool> Delete(AppRole entity);
        Task<bool> SetActive(string id);
        Task<bool> SetDeActive(string id);
        Task<bool> SetDeleted(string id);
        Task<bool> SetNotDeleted(string id);
    }
}
