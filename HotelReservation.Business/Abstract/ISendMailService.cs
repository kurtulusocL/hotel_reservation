using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface ISendMailService
    {
        IEnumerable<SendMail> GetAll(int page, int pageCount);
        IEnumerable<SendMail> GetAllWithoutParameter(int page, int pageCount);
        Task<SendMail> GetById(int? id);
        Task<bool> Send(SendMail entity);
        Task<bool> Delete(SendMail entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
