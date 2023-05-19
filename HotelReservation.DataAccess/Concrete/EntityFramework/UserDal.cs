using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete.Identity;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class UserDal : EntityRepositoryBase<AppUser, ApplicationDbContext>, IUserDal
    {
        public IEnumerable<AppUser> GetAllAdminUsers(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<AppUser>().Include("ProfileImages").Include("Comments").Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.Title != null || i.Title != "").OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 25);
            }
        }

        public IEnumerable<AppUser> GetAllMemberUser(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<AppUser>().Include("ProfileImages").Include("Comments").Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.Title == "" || i.Title == null).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 25);
            }
        }

        public IEnumerable<AppUser> GetAllUsers(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<AppUser>().Include("ProfileImages").Include("Comments").Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 25);
            }
        }

        public IEnumerable<AppUser> GetAllUsersWithoutParameter(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result= context.Set<AppUser>().Include("ProfileImages").Include("Comments").Include("Reservations").OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 45);
            }
        }

        public async Task<AppUser> GetUserById(string id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<AppUser>().Include("ProfileImages").Include("Comments").Include("Reservations").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public AppUser GetUserByIdSync(string id)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<AppUser>().Include("ProfileImages").Include("Comments").Include("Reservations").Where(i => i.Id == id).FirstOrDefault();
            }
        }

        public async Task<bool> SetActive(string id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<AppUser>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(string id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<AppUser>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(string id)
        {
            using (ApplicationDbContext context = new())
            {
                var deleted = await context.Set<AppUser>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetNotDeleted(string id)
        {
            using (ApplicationDbContext context = new())
            {
                var deleted = await context.Set<AppUser>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
