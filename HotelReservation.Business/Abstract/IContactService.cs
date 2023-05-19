using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<IEnumerable<Contact>> GetAllWtihoutParameter();
        IEnumerable<Contact> GetAllContactForHomeSync();
        Task<Contact> GetById(int? id);
        Task<bool> Create(Contact entity);
        Task<bool> Update(Contact entity);
        Task<bool> Delete(Contact entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
