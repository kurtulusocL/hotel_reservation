using HotelReservation.Core.DataAccess;
using HotelReservation.Entities.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<AppUser>
    {
        IEnumerable<AppUser> GetAllUsers(int page, int pageCount);
        IEnumerable<AppUser> GetAllAdminUsers(int page, int pageCount);
        IEnumerable<AppUser> GetAllMemberUser(int page, int pageCount);
        IEnumerable<AppUser> GetAllUsersWithoutParameter(int page, int pageCount);
        Task<AppUser> GetUserById(string id);
        AppUser GetUserByIdSync(string id);
        Task<bool> SetActive(string id);
        Task<bool> SetDeActive(string id);
        Task<bool> SetDeleted(string id);
        Task<bool> SetNotDeleted(string id);
    }
}
