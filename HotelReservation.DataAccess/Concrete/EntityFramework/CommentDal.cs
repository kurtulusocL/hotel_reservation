using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class CommentDal : EntityRepositoryBase<Comment, ApplicationDbContext>, ICommentDal
    {
        public IEnumerable<Comment> GetAllComments(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result= context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 45);
            }
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public IEnumerable<Comment> GetAllCommentsByHotelId(int? id, int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.HotelId == id).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 45);
            }
        }

        public IEnumerable<Comment> GetAllCommentsByHotelIdSync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.HotelId == id).OrderByDescending(i => i.CreatedDate).ToList();
            }
        }

        public IEnumerable<Comment> GetAllCommentsByPictureId(int? id, int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.PictureId == id).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 45);
            }
        }

        public IEnumerable<Comment> GetAllCommentsByPictureIdSync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.PictureId == id).OrderByDescending(i => i.CreatedDate).ToList();
            }
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsByUserId(string userId)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.AppUserId == userId).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public IEnumerable<Comment> GetAllCommentsForAdmin()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).Take(25).ToList();
            }
        }

        public IEnumerable<Comment> GetAllCommentsForHome()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => Guid.NewGuid()).Take(15).ToList();
            }
        }

        public IEnumerable<Comment> GetAllCommentsWithoutParameter(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 45);
            }
        }

        public async Task<Comment> GetCommentById(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Comment>().Include("Hotel").Include("Picture").Include("CommentAnswers").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<Comment>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<Comment>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<Comment>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
                return true; ;
            }
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<Comment>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
