using HotelReservation.Business.Abstract;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.Entities.Concrete;

namespace HotelReservation.Business.Concrete
{
    public class CommentAnswerManager : ICommentAnswerService
    {
        readonly ICommentAnswerDal _answerDal;
        public CommentAnswerManager(ICommentAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }
        public async Task<bool> Create(CommentAnswer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _answerDal.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(CommentAnswer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _answerDal.DeleteAsync(entity);
            return true;
        }

        public async Task<bool> Dislike(int id)
        {
            await _answerDal.Dislike(id);
            return true;
        }

        public IEnumerable<CommentAnswer> GetAll(int page, int pageCount)
        {
            return _answerDal.GetAllCommentAnswers(page, 35);
        }

        public async Task<IEnumerable<CommentAnswer>> GetAllCommentAnswersByCommentId(int? id)
        {
            if (id != null)
            {
                return await _answerDal.GetAllCommentAnswersByCommentId(id);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<CommentAnswer> GetAllCommentAnswersByCommentIdSync(int? id)
        {
            if (id != null)
            {
                return _answerDal.GetAllCommentAnswersByCommentIdSync(id);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<CommentAnswer> GetAllCommentAnswersForUserSync(string id)
        {
            if (id != null)
            {
                return _answerDal.GetAllCommentAnswersForUserSync(id);
            }
            throw new Exception("Id is null");
        }

        public IEnumerable<CommentAnswer> GetAllCommentAnswersWithoutParameter(int page, int pageCount)
        {
            return _answerDal.GetAllCommentAnswersWithoutParameter(page, 35);
        }

        public async Task<CommentAnswer> GetById(int? id)
        {
            if (id != null)
            {
                return await _answerDal.GetAnswerById(id);
            }
            throw new Exception("Id is not null");
        }

        public CommentAnswer HitRead(int? id)
        {
            if (id != null)
            {
                return _answerDal.HitRead(id);
            }
            throw new Exception("Id is not null");
        }

        public async Task<bool> Like(int id)
        {
            await _answerDal.Like(id);
            return true;
        }

        public async Task<bool> SetActive(int id)
        {
            await _answerDal.SetActive(id);
            return true;
        }

        public async Task<bool> SetDeActive(int id)
        {
            await _answerDal.SetDeActive(id);
            return true;
        }

        public async Task<bool> SetDeleted(int id)
        {
            await _answerDal.SetDeleted(id);
            return true;
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            await _answerDal.SetNotDeleted(id);
            return true;
        }
    }
}
