using HotelReservation.Business.Abstract;
using HotelReservation.Business.Concrete;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservation.Business.DependencyResolver.DependencyInjection
{
    public static class DependencyContainer
    {
        public static void DependencyService(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequiredLength = 2;
                //opt.User.AllowedUserNameCharacters =
                //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAuditDal, AuditDal>();
            services.AddScoped<IAuditService, AuditManager>();
            services.AddScoped<ICommentDal, CommentDal>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentAnswerDal, CommentAnswerDal>();
            services.AddScoped<ICommentAnswerService, CommentAnswerManager>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IExceptionLoggerDal, ExceptionLoggerDal>();
            services.AddScoped<IExceptionLoggerService, ExceptionLoggerManager>();
            services.AddScoped<IGuideDal, GuideDal>();
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IHotelDal, HotelDal>();
            services.AddScoped<IHotelService, HotelManager>();
            services.AddScoped<IServiceDal, ServiceDal>();
            services.AddScoped<IOurServiceService, OurServiceManager>();
            services.AddScoped<IPictureDal, PictureDal>();
            services.AddScoped<IPictureService, PictureManager>();
            services.AddScoped<IPricingDal, PricingDal>();
            services.AddScoped<IPricingService, PricingManager>();
            services.AddScoped<IProfileImageDal, ProfileImageDal>();
            services.AddScoped<IProfileImageService, ProfileImageManager>();
            services.AddScoped<IReservationDal, ReservationDal>();
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationPolicyDal, ReservationPolicyDal>();
            services.AddScoped<IReservationPolicyService, ReservationPolicyManager>();
            services.AddScoped<IRoleDal, RoleDal>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<ISendMailDal, SendMailDal>();
            services.AddScoped<ISendMailService, SendMailManager>();
            services.AddScoped<ISocialMediaDal, SocialMediaDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<IUserService, UserManager>();

            services.AddSingleton<ICaptchaValidatorService, CaptchaValidatorManager>();
        }
    }
}
