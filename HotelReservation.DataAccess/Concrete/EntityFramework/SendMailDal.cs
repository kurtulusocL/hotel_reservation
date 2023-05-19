using HotelReservation.Core.DataAccess.EntityFramework;
using HotelReservation.DataAccess.Abstract;
using HotelReservation.DataAccess.Concrete.EntityFramework.Context;
using HotelReservation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace HotelReservation.DataAccess.Concrete.EntityFramework
{
    public class SendMailDal : EntityRepositoryBase<SendMail, ApplicationDbContext>, ISendMailDal
    {
        public void MailInformation(SendMail model)
        {
            SmtpClient client = new SmtpClient("smtp.yandex.com.tr", 587);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(model.SenderEmail, "myhotel.com");
            mail.Priority = MailPriority.High;
            mail.Subject = model.Subject;
            mail.To.Add(new MailAddress(model.RecieverEmail, ""));
            mail.Body = model.Text;
            mail.IsBodyHtml = true;

            NetworkCredential enter = new NetworkCredential(model.SenderEmail, "mail password");
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = enter;
            client.Send(mail);
        }

        public async Task<bool> SetActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<SendMail>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = true;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeActive(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var active = await context.Set<SendMail>().Where(i => i.Id == id).FirstOrDefaultAsync();
                active.IsConfirmed = false;
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> SetDeleted(int id)
        {
            using (ApplicationDbContext context = new ())
            {
                var deleted = await context.Set<SendMail>().Where(i => i.Id == id).FirstOrDefaultAsync();
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
                var deleted = await context.Set<SendMail>().Where(i => i.Id == id).FirstOrDefaultAsync();
                deleted.IsDeleted = false;
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
