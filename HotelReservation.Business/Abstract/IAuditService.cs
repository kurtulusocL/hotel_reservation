using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IAuditService
    {
        IEnumerable<Audit> GetAll(int page, int pageCount);
        IEnumerable<Audit> GetAllUserAuidts(int page, int pageCount);
        IEnumerable<Audit> GetAllVisitorAuidts(int page, int pageCount);
        IEnumerable<Audit> GetAllWtihoutParameter(int page, int pageCount);
        Task<Audit> GetById(int? id);
        Task<bool> Delete(Audit entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
