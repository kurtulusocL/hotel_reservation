using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class CommentAnswerDal : EntityRepositoryBase<CommentAnswer, ApplicationDbContext>, ICommentAnswerDal
    {
        public async Task<bool> Dislike(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var liked = context.Set<CommentAnswer>().Where(i => i.Id == id).SingleOrDefault();
                liked.Dislike++;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public IEnumerable<CommentAnswer> GetAllCommentAnswers(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<CommentAnswer>().Include("Comment").Where(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 45);
            }
        }

        public async Task<IEnumerable<CommentAnswer>> GetAllCommentAnswersByCommentId(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<CommentAnswer>().Include("Comment").Where(i => i.IsDeleted == false && i.IsConfirmed == true && i.CommentId == id).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public IEnumerable<CommentAnswer> GetAllCommentAnswersByCommentIdSync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<CommentAnswer>().Include("Comment").Where(i => i.IsDeleted == false && i.IsConfirmed == true && i.CommentId == id).OrderByDescending(i => i.CreatedDate).ToList();
            }
        }

        public IEnumerable<CommentAnswer> GetAllCommentAnswersForUserSync(string id)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<CommentAnswer>().Include("Comment").Where(i => i.IsDeleted == false && i.IsConfirmed == true && i.Comment.AppUserId == id).OrderByDescending(i => i.CreatedDate).Take(15).ToList();
            }
        }

        public IEnumerable<CommentAnswer> GetAllCommentAnswersWithoutParameter(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<CommentAnswer>().Include("Comment").OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 45);
            }
        }

        public async Task<CommentAnswer> GetAnswerById(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<CommentAnswer>().Include("Comment").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public CommentAnswer HitRead(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                var hit = context.Set<CommentAnswer>().Where(i => i.Id == id).SingleOrDefault();
                hit.Hit++;
                context.SaveChanges();
                return hit;
            }
        }

        public async Task<bool> Like(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var liked = context.Set<CommentAnswer>().Where(i => i.Id == id).SingleOrDefault();
                liked.Like++;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<CommentAnswer>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<CommentAnswer>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var deleted = await context.Set<CommentAnswer>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
                return true; ;
            }
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var deleted = await context.Set<CommentAnswer>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
