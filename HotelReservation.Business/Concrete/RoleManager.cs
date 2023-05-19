using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete.Identity;

namespace HotelReservation.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        readonly IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public async Task<bool> Create(AppRole entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _roleDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(AppRole entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _roleDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<AppRole>> GetAll()
        {
            var result = await _roleDal.GetAllAsync(i => i.IsDeleted == false && i.IsConfirmed == true);
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<IEnumerable<AppRole>> GetAllWtihoutParameter()
        {
            var result = await _roleDal.GetAllAsync();
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<AppRole> GetById(string id)
        {
            if (id != null)
            {
                return await _roleDal.GetAsync(i => i.Id == id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(string id)
        {
            if (id != null)
            {
                await _roleDal.SetActive(id);
                return true;
            }
            return false;
        }

        public async Task<bool> SetDeActive(string id)
        {
            if (id != null)
            {
                await _roleDal.SetDeActive(id);
            }
            return false;
        }

        public async Task<bool> SetDeleted(string id)
        {
            if (id != null)
            {
                await _roleDal.SetDeleted(id);
                return true;
            }
            return false;
        }

        public async Task<bool> SetNotDeleted(string id)
        {
            if (id != null)
            {
                await _roleDal.SetNotDeleted(id);
                return true;
            }
            return false;
        }

        public async Task<bool> Update(AppRole entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _roleDal.UpdateAsync(entity);
            return true;
        }
    }
}
