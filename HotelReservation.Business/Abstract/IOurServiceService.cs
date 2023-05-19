using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IOurServiceService
    {
        Task<IEnumerable<Service>> GetAll();
        Task<IEnumerable<Service>> GetAllServicesWithoutParameter();
        IEnumerable<Service> GetAllServicesForAdmin();
        IEnumerable<Service> GetAllServicesForUser();
        IEnumerable<Service> GetAllSync();
        Task<Service> GetById(int? id);
        Task<bool> Create(Service entity);
        Task<bool> Update(Service entity);
        Task<bool> Delete(Service entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
