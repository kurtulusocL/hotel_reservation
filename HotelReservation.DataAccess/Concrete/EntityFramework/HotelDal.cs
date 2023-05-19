using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class HotelDal : EntityRepositoryBase<Hotel, ApplicationDbContext>, IHotelDal
    {
        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Hotel>().Include("Comments").Where(i => i.IsDeleted == false && i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsByPromotion()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Hotel>().Include("Comments").Where(i => i.IsDeleted == false && i.IsConfirmed == true && i.IsPromotion == true).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsWithutParameter()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Hotel>().Include("Comments").OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<Hotel> GetHotelById(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Hotel>().Include("Comments").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public Hotel GetHotelByIdSync(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Hotel>().Include("Comments").Where(i => i.Id == id).FirstOrDefault();
            }
        }

        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<Hotel>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<Hotel>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<Hotel>().Where(i => i.Id == id).FirstOrDefaultAsync();
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
                var deleted = await context.Set<Hotel>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
