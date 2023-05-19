using HotelReservation.Core.Entities.EntityFramework;
using HotelReservation.Entities.Concrete;
using HotelReservation.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.DataAccess.Concrete.EntityFramework.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KURTULUSOCAL\\KURTULUSOCL;Database=Hotel;user Id=sa;Password=123");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentAnswer> CommentAnswer { get; set; }
        public DbSet<ExceptionLogger> ExceptionLoggers { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<ProfileImage> ProfileImages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationPolicy> ReservationPolicies { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SendMail> SendMails { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.Now.ToLocalTime(),
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.Now.ToLocalTime(),
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
