using HotelReservation.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IUserService
    {
        IEnumerable<AppUser> GetAll(int page, int pageCount);
        IEnumerable<AppUser> GetAllAdminUsers(int page, int pageCount);
        IEnumerable<AppUser> GetAllMemberUser(int page, int pageCount);
        IEnumerable<AppUser> GetAllUsersWithoutParameter(int page, int pageCount);
        Task<AppUser> GetById(string id);
        AppUser GetUserByIdSync(string id);        
        Task<bool> Delete(AppUser entity);
        Task<bool> SetActive(string id);
        Task<bool> SetDeActive(string id);
        Task<bool> SetDeleted(string id);
        Task<bool> SetNotDeleted(string id);
    }
}
