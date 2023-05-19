using HotelReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Business.Abstract
{
    public interface ICommentAnswerService
    {
        IEnumerable<CommentAnswer> GetAll(int page, int pageCount);
        Task<IEnumerable<CommentAnswer>> GetAllCommentAnswersByCommentId(int? id);
        IEnumerable<CommentAnswer> GetAllCommentAnswersWithoutParameter(int page, int pageCount);
        IEnumerable<CommentAnswer> GetAllCommentAnswersByCommentIdSync(int? id);
        IEnumerable<CommentAnswer> GetAllCommentAnswersForUserSync(string id);
        Task<CommentAnswer> GetById(int? id);
        CommentAnswer HitRead(int? id);
        Task<bool> Like(int id);
        Task<bool> Dislike(int id);
        Task<bool> Create(CommentAnswer entity);
        Task<bool> Delete(CommentAnswer entity);
        Task<bool> SetActive(int id);
        Task<bool> SetDeActive(int id);
        Task<bool> SetDeleted(int id);
        Task<bool> SetNotDeleted(int id);
    }
}
