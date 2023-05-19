using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class PricingDal : EntityRepositoryBase<Pricing, ApplicationDbContext>, IPricingDal
    {
        public async Task<IEnumerable<Pricing>> GetAllPricings()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Pricing>().Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public IEnumerable<Pricing> GetAllPricingsForAdmin()
        {
            using (ApplicationDbContext context = new())
            {
                return  context.Set<Pricing>().Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false&&i.Reservations.Count()>0).OrderByDescending(i => i.Reservations.Count()).ToList();
            }
        }

        public IEnumerable<Pricing> GetAllPricingsForUser()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Pricing>().Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.Reservations.Count() > 3).OrderByDescending(i => i.Reservations.Count()).ToList();
            }
        }

        public async Task<IEnumerable<Pricing>> GetAllWtihoutParameter()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Pricing>().Include("Reservations").OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public async Task<Pricing> GetPricingById(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Pricing>().Include("Reservations").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<Pricing>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<Pricing>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var deleted = await context.Set<Pricing>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var deleted = await context.Set<Pricing>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
