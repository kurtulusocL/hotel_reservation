using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class RoleDal : EntityRepositoryBase<AppRole, ApplicationDbContext>, IRoleDal
    {
        public async Task<bool> SetActive(string id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<AppRole>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(string id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<AppRole>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(string id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<AppRole>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetNotDeleted(string id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<AppRole>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
