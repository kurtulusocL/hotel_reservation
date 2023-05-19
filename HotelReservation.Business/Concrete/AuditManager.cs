using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;
using X.PagedList;

namespace HotelReservation.Business.Concrete
{
    public class AuditManager : IAuditService
    {
        readonly IAuditDal _auditDal;
        public AuditManager(IAuditDal auditDal)
        {
            _auditDal = auditDal;
        }
        public async Task<bool> Delete(Audit entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _auditDal.DeleteAsync(entity);
            return true;
        }

        public IEnumerable<Audit> GetAll(int page, int pageCount)
        {
            var result = _auditDal.GetAll(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate);
            return result.ToPagedList(page, 55);
        }

        public IEnumerable<Audit> GetAllUserAuidts(int page, int pageCount)
        {
            var result = _auditDal.GetAll(i => i.IsConfirmed == true && i.IsDeleted == false && i.UserId != null || i.UserName != null).OrderByDescending(i => i.CreatedDate);
            return result.ToPagedList(page, 45);
        }

        public IEnumerable<Audit> GetAllVisitorAuidts(int page, int pageCount)
        {
            var result = _auditDal.GetAll(i => i.IsConfirmed == true && i.IsDeleted == false && i.UserId == null || i.UserName == null).OrderByDescending(i => i.CreatedDate);
            return result.ToPagedList(page, 45);
        }

        public IEnumerable<Audit> GetAllWtihoutParameter(int page, int pageCount)
        {
            var result = _auditDal.GetAll().OrderByDescending(i => i.CreatedDate);
            return result.ToPagedList(page, 65);
        }

        public async Task<Audit> GetById(int? id)
        {
            if (id != null)
            {
                return await _auditDal.GetAsync(i => i.Id == id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _auditDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _auditDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _auditDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _auditDal.SetNotDeleted(id);
            return true;
        }
    }
}
