using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IPricingService
    {
        Task<IEnumerable<Pricing>> GetAll();
        Task<IEnumerable<Pricing>> GetAllWtihoutParameter();
        IEnumerable<Pricing> GetAllPricingsForAdmin();
        IEnumerable<Pricing> GetAllPricingsForUser();
        Task<Pricing> GetById(int? id);
        Task<bool> Create(Pricing entity);
        Task<bool> Update(Pricing entity);
        Task<bool> Delete(Pricing entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
