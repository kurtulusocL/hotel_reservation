using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class ReservationDal : EntityRepositoryBase<Reservation, ApplicationDbContext>, IReservationDal
    {
        public bool AccountTotalPrice(Reservation model, decimal totalPrice)
        {
            if (model.PricingId != null || model.ServiceId != null)
            {
                model.TotalPrice = (model.NumberOfRoom * model.Pricing.Price) + (model.Service.Price);
                model.TotalPrice = Convert.ToDecimal(totalPrice);
                return true;
            }
            return false;
        }

        public IEnumerable<Reservation> GetAllApprovedReservations(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.IsReservationApproved == true).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 24);
            }
        }

        public IEnumerable<Reservation> GetAllConfirmedReservationByUserId(string userId)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.IsReservationApproved == true&&i.AppUserId==userId).OrderByDescending(i => i.CreatedDate).ToList();
            }
        }

        public async Task<IEnumerable<Reservation>> GetAllConfirmedReservationForUserByUserId(string userId)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.IsReservationApproved == true && i.AppUserId == userId).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public IEnumerable<Reservation> GetAllLastReservationForAdmin()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.IsReservationApproved == false).OrderByDescending(i => i.CreatedDate).Take(30).ToList();
            }
        }

        public IEnumerable<Reservation> GetAllNotApprovedReservations(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.IsReservationApproved == false).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 24);
            }
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationByUserId(string userId)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.AppUserId == userId).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public IEnumerable<Reservation> GetAllReservationForAdmin()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.IsReservationApproved == false).OrderByDescending(i => i.CreatedDate).Take(25).ToList();
            }
        }

        public IEnumerable<Reservation> GetAllReservations(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 25);
            }
        }

        public IEnumerable<Reservation> GetAllReservationsByPriceId(int? id, int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.PricingId == id).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 25);
            }
        }

        public IEnumerable<Reservation> GetAllReservationsByServiceId(int? id, int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.ServiceId == id).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 24);
            }
        }

        public IEnumerable<Reservation> GetAllReservationsByUserId(string userId, int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.AppUserId == userId).OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 24);
            }
        }

        public IEnumerable<Reservation> GetAllReservationsByUserIdSync(string userId)
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.AppUserId == userId).OrderByDescending(i => i.CreatedDate).ToList();
            }
        }

        public IEnumerable<Reservation> GetAllReservationsWithoutParameter(int page, int pageCount)
        {
            using (ApplicationDbContext context = new())
            {
                var result = context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").OrderByDescending(i => i.CreatedDate).AsEnumerable();
                return result.ToPagedList(page, 34);
            }
        }

        public IEnumerable<Reservation> GetAllSomeReservationForAdmin()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).Take(30).ToList();
            }
        }

        public async Task<Reservation> GetReservationById(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Reservation>().Include("Pricing").Include("Service").Include("AppUser").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<Reservation>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetApproved(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var approved = await context.Set<Reservation>().Where(i => i.Id == id).FirstOrDefaultAsync();
                approved.IsReservationApproved = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var active = await context.Set<Reservation>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var deleted = await context.Set<Reservation>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetNotApproved(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var approved = await context.Set<Reservation>().Where(i => i.Id == id).FirstOrDefaultAsync();
                approved.IsReservationApproved = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            using (ApplicationDbContext context = new())
            {
                var deleted = await context.Set<Reservation>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
