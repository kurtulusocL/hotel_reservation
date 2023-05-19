using HotelReservation.Core.DataAccess;
using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
       Task<IEnumerable<Comment>> GetAllComments();
        IEnumerable<Comment> GetAllComments(int page, int pageCount);
        IEnumerable<Comment> GetAllCommentsByHotelId(int? id, int page, int pageCount);
        IEnumerable<Comment> GetAllCommentsByPictureId(int? id, int page, int pageCount);
        IEnumerable<Comment> GetAllCommentsWithoutParameter(int page, int pageCount);
        Task<IEnumerable<Comment>> GetAllCommentsByUserId(string userId);
        IEnumerable<Comment> GetAllCommentsForAdmin();
        IEnumerable<Comment> GetAllCommentsForHome();
        Task<Comment> GetCommentById(int? id);
        IEnumerable<Comment> GetAllCommentsByHotelIdSync(int? id);
        IEnumerable<Comment> GetAllCommentsByPictureIdSync(int? id);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
