using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class ProfileImageDal : EntityRepositoryBase<ProfileImage, ApplicationDbContext>, IProfileImageDal
    {
        public async Task<IEnumerable<ProfileImage>> GetAllProfileImages()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<ProfileImage>().Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<IEnumerable<ProfileImage>> GetAllProfileImagesByUserId(string id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<ProfileImage>().Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.AppUserId == id).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<IEnumerable<ProfileImage>> GetAllProfileImagesWithoutParameter()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<ProfileImage>().Include("AppUser").OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<ProfileImage> GetProfileImageById(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<ProfileImage>().Include("AppUser").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public ProfileImage GetProfileImageByIdSync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<ProfileImage>().Include("AppUser").Where(i => i.Id == id).FirstOrDefault();
            }
        }

        public ProfileImage GetProfileImageByUserIdSync(string id)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<ProfileImage>().Include("AppUser").Where(i => i.AppUserId == id).FirstOrDefault();
            }
        }

        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<ProfileImage>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<ProfileImage>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<ProfileImage>().Where(i => i.Id == id).FirstOrDefaultAsync();
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
                var deleted = await context.Set<ProfileImage>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
