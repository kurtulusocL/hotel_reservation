using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Concrete
{
    public class AboutManager : IAboutService
    {
        readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public async Task<bool> Create(About entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _aboutDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(About entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _aboutDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<About>> GetAll()
        {
            var result = await _aboutDal.GetAllAsync(i => i.IsConfirmed == true && i.IsDeleted == false);
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<IEnumerable<About>> GetAllWtihoutParameter()
        {
            var result = await _aboutDal.GetAllAsync();
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<About> GetById(int? id)
        {
            if (id != null)
            {
                return await _aboutDal.GetAsync(i => i.Id == id);
            }
            throw new Exception("Id is null");
        }

        public About HitRead(int? id)
        {
            return _aboutDal.HitRead(id);
        }

        public async Task<bool> SetActive(int id)
        {
            await _aboutDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _aboutDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _aboutDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _aboutDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(About entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _aboutDal.UpdateAsync(entity);
            return true;
        }
    }
}
