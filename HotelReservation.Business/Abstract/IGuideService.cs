using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Abstract
{
    public interface IGuideService
    {
        Task<IEnumerable<Guide>> GetAll();
        Task<IEnumerable<Guide>> GetAllWtihoutParameter();
        IEnumerable<Guide> GetAllGuidesForAbout();
        Task<Guide> GetById(int? id);
        Task<bool> Create(Guide entity);
        Task<bool> Update(Guide entity);
        Task<bool> Delete(Guide entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
