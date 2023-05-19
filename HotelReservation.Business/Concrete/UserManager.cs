using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete.Identity;

namespace HotelReservation.Business.Concrete
{
    public class UserManager : IUserService
    {
        readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<bool> Delete(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _userDal.DeleteAsync(entity);
            return true;
        }

        public IEnumerable<AppUser> GetAll(int page, int pageCount)
        {
            return _userDal.GetAllUsers(page, 25);
        }

        public IEnumerable<AppUser> GetAllAdminUsers(int page, int pageCount)
        {
            return _userDal.GetAllAdminUsers(page, 25);
        }

        public IEnumerable<AppUser> GetAllMemberUser(int page, int pageCount)
        {
            return _userDal.GetAllMemberUser(page, 25);
        }

        public IEnumerable<AppUser> GetAllUsersWithoutParameter(int page, int pageCount)
        {
            return _userDal.GetAllUsersWithoutParameter(page, 45);
        }

        public async Task<AppUser> GetById(string id)
        {
            if (id != null)
            {
                return await _userDal.GetUserById(id);
            }
            throw new Exception("There is not Id");
        }

        public AppUser GetUserByIdSync(string id)
        {
            if (id != null)
            {
                return _userDal.GetUserByIdSync(id);
            }
            throw new Exception("There is not Id");
        }

        public async Task<bool> SetActive(string id)
        {
            if (id != null)
            {
                await _userDal.SetActive(id);
                return true;
            }
            return false;
        }

        public async Task<bool> SetDeActive(string id)
        {
            if (id != null)
            {
                await _userDal.SetDeActive(id);
                return true;
            }
            return false;
        }

        public async Task<bool> SetDeleted(string id)
        {
            if (id != null)
            {
                await _userDal.SetDeleted(id);
                return true;
            }
            return false;
        }

        public async Task<bool> SetNotDeleted(string id)
        {
            if (id != null)
            {
                await _userDal.SetNotDeleted(id);
                return true;
            }
            return false;
        }
    }
}
