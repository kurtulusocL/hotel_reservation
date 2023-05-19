using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;
using X.PagedList;

namespace HotelReservation.Business.Concrete
{
    public class SendMailManager : ISendMailService
    {
        readonly ISendMailDal _sendMailDal;
        public SendMailManager(ISendMailDal sendMailDal)
        {
            _sendMailDal = sendMailDal;
        }

        public async Task<bool> Delete(SendMail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _sendMailDal.DeleteAsync(entity);
            return true;
        }

        public IEnumerable<SendMail> GetAll(int page, int pageCount)
        {
            var result = _sendMailDal.GetAll(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i=>i.CreatedDate);
            return result.ToPagedList(page, 25);
        }

        public IEnumerable<SendMail> GetAllWithoutParameter(int page, int pageCount)
        {
            var result = _sendMailDal.GetAll().OrderByDescending(i => i.CreatedDate);
            return result.ToPagedList(page, 35);
        }

        public async Task<SendMail> GetById(int? id)
        {
            if (id != null)
            {
                return await _sendMailDal.GetAsync(i => i.Id == id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> Send(SendMail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _sendMailDal.MailInformation(entity);
            await _sendMailDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> SetActive(int id)
        {
            await _sendMailDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _sendMailDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _sendMailDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _sendMailDal.SetNotDeleted(id);
            return true;
        }
    }
}
