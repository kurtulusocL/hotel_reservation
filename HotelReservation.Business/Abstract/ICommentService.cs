using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllComments();
        IEnumerable<Comment> GetAll(int page, int pageCount);
        IEnumerable<Comment> GetAllCommentsByHotelId(int? id, int page, int pageCount);
        IEnumerable<Comment> GetAllCommentsByPictureId(int? id, int page, int pageCount);
        IEnumerable<Comment> GetAllCommentsWithoutParameter(int page, int pageCount);
        Task<Comment> GetById(int? id);
        IEnumerable<Comment> GetAllCommentsForAdmin();
        IEnumerable<Comment> GetAllCommentsForHome();
        IEnumerable<Comment> GetAllCommentsByHotelIdSync(int? id);
        IEnumerable<Comment> GetAllCommentsByPictureIdSync(int? id);
        Task<IEnumerable<Comment>> GetAllCommentsByUserId(string userId);
        Task<bool> Create(Comment entity);
        Task<bool> Delete(Comment entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
