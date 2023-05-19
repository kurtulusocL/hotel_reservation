using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class ServiceDal : EntityRepositoryBase<Service, ApplicationDbContext>, IServiceDal
    {
        public async Task<IEnumerable<Service>> GetAllServices()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Service>().Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public IEnumerable<Service> GetAllServicesForAdmin()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Service>().Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false&&i.Reservations.Count()>0).OrderByDescending(i => i.Reservations.Count()).ToList();
            }
        }

        public IEnumerable<Service> GetAllServicesForUser()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Service>().Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false && i.Reservations.Count() > 3).OrderByDescending(i => i.Reservations.Count()).ToList();
            }
        }

        public async Task<IEnumerable<Service>> GetAllServicesWithoutParameter()
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Service>().Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToListAsync();
            }
        }

        public IEnumerable<Service> GetAllServiceSync()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Set<Service>().Include("Reservations").Where(i => i.IsConfirmed == true && i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToList();
            }
        }

        public async Task<Service> GetServiceById(int? id)
        {
            using (ApplicationDbContext context = new())
            {
                return await context.Set<Service>().Include("Reservations").Where(i => i.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<Service>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<Service>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<Service>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = true;
                deleted.DeletedDate = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetNotDeleted(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<Service>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
