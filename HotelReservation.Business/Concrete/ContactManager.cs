using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class ContactManager : IContactService
    {
        readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public async Task<bool> Create(Contact entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _contactDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Contact entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _contactDal.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var result = await _contactDal.GetAllAsync(i => i.IsConfirmed == true && i.IsDeleted == false);
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public IEnumerable<Contact> GetAllContactForHomeSync()
        {
            return _contactDal.GetAll(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).Take(1).ToList();
        }

        public async Task<IEnumerable<Contact>> GetAllWtihoutParameter()
        {
            var result = await _contactDal.GetAllAsync();
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<Contact> GetById(int? id)
        {
            if (id != null)
            {
                return await _contactDal.GetAsync(i => i.Id == id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _contactDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _contactDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _contactDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _contactDal.SetNotDeleted(id);
            return true;
        }

        public async Task<bool> Update(Contact entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _contactDal.UpdateAsync(entity);
            return true;
        }
    }
}
