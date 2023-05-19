using HotelReservation.Core.DataAccess;
using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Abstract
{
    public interface IPricingDal : IEntityRepository<Pricing>
    {
        Task<IEnumerable<Pricing>> GetAllPricings();
        Task<IEnumerable<Pricing>> GetAllWtihoutParameter();
        IEnumerable<Pricing> GetAllPricingsForAdmin();
        IEnumerable<Pricing> GetAllPricingsForUser();
        Task<Pricing> GetPricingById(int? id);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
