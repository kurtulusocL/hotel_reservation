using HotelReservation.Core.DataAccess;
using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Abstract
{
    public interface IServiceDal : IEntityRepository<Service>
    {
        Task<IEnumerable<Service>> GetAllServices();
        Task<IEnumerable<Service>> GetAllServicesWithoutParameter();
        IEnumerable<Service> GetAllServicesForAdmin();
        IEnumerable<Service> GetAllServicesForUser();
        IEnumerable<Service> GetAllServiceSync();
        Task<Service> GetServiceById(int? id);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
