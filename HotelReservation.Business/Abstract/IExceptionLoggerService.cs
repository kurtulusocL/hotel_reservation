using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface IExceptionLoggerService
    {
        Task<IEnumerable<ExceptionLogger>> GetAll();
        Task<IEnumerable<ExceptionLogger>> GetAllWtihoutParameter();
        Task<ExceptionLogger> GetById(int? id);
        Task<bool> Delete(ExceptionLogger entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
