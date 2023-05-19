using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class PictureDal : EntityRepositoryBase<Picture, ApplicationDbContext>, IPictureDal
    {
        public IEnumerable<Picture> GetAllPictures(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Picture>().Include("Comments").Where(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 35);
            }
        }

        public async Task<IEnumerable<Picture>> GetAllPictures()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Picture>().Include("Comments").Where(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public IEnumerable<Picture> GetAllPicturesForHomeSync()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Picture>().Include("Comments").Where(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i => Guid.NewGuid()).Take(4).ToList();
            }
        }

        public IEnumerable<Picture> GetAllPicturesSync()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Picture>().Include("Comments").Where(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).ToList();
            }
        }

        public IEnumerable<Picture> GetAllPicturesWithoutParameter(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Picture>().Include("Comments").OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 45);
            }
        }

        public Picture GetPictureByIdSync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Picture>().Include("Comments").Where(i => i.IsDeleted == false && i.IsConfirmed == true && i.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<Picture> GetPictureSync()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Picture>().Include("Comments").Where(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i => Guid.NewGuid()).Take(1).ToList();
            }
        }

        public async Task<Picture> GetPitureById(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Picture>().Include("Comments").Where(i => i.IsDeleted == false && i.IsConfirmed == true && i.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<Picture>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<Picture>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var deleted = await context.Set<Picture>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
                return true; ;
            }
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var deleted = await context.Set<Picture>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
