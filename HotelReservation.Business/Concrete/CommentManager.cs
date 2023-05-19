using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public async Task<bool> Create(Comment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _commentDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Comment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _commentDal.DeleteAsync(entity);
            return true;
        }

        public IEnumerable<Comment> GetAll(int page, int pageCount)
        {
            return _commentDal.GetAllComments(page, 35);
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _commentDal.GetAllComments();
        }

        public IEnumerable<Comment> GetAllCommentsByHotelId(int? id, int page, int pageCount)
        {
            if (id != null)
            {
                return _commentDal.GetAllCommentsByHotelId(id, page, 35);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<Comment> GetAllCommentsByHotelIdSync(int? id)
        {
            if (id != null)
            {
                return _commentDal.GetAllCommentsByHotelIdSync(id);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<Comment> GetAllCommentsByPictureId(int? id, int page, int pageCount)
        {
            return _commentDal.GetAllCommentsByPictureId(id, page, 35);
        }

        public IEnumerable<Comment> GetAllCommentsByPictureIdSync(int? id)
        {
            if (id != null)
            {
                return _commentDal.GetAllCommentsByPictureIdSync(id);
            }
            throw new Exception("Id is null");
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsByUserId(string userId)
        {
            if (userId != null)
            {
                return await _commentDal.GetAllCommentsByUserId(userId);
            }
            throw new Exception("User Id is null");
        }

        public IEnumerable<Comment> GetAllCommentsForAdmin()
        {
            return _commentDal.GetAllCommentsForAdmin();
        }

        public IEnumerable<Comment> GetAllCommentsForHome()
        {
            return _commentDal.GetAllCommentsForHome();
        }

        public IEnumerable<Comment> GetAllCommentsWithoutParameter(int page, int pageCount)
        {
            return _commentDal.GetAllCommentsWithoutParameter(page, 35);
        }

        public async Task<Comment> GetById(int? id)
        {
            if (id != null)
            {
                return await _commentDal.GetCommentById(id);
            }
            throw new Exception("Id is null");
        }

        public async Task<bool> SetActive(int id)
        {
            await _commentDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _commentDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _commentDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _commentDal.SetNotDeleted(id);
            return true;
        }
    }
}
