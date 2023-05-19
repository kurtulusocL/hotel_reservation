﻿using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class ExceptionLoggerDal : EntityRepositoryBase<ExceptionLogger, ApplicationDbContext>, IExceptionLoggerDal
    {
        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<ExceptionLogger>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<ExceptionLogger>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<ExceptionLogger>().Where(i => i.Id == id).FirstOrDefaultAsync();
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
                var deleted = await context.Set<ExceptionLogger>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
