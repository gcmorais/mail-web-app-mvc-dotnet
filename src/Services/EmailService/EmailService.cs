using System.Net;
using System.Net.Mail;
using mail_web_app.Data;
using mail_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace mail_web_app.Services.EmailService
{
    public class EmailService : IEmailInterface
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public EmailService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<EmailModel>> ListMails(string search = null)
        {
            List<EmailModel> registryEmail = new List<EmailModel>();

            try
            {
                if (search == null)
                {
                    registryEmail = await _context.Emails.ToListAsync();
                }else
                {
                    registryEmail = await _context.Emails.Where(info => info.Email.Contains(search) || info.Nome.Contains(search)).ToListAsync();
                }

                return registryEmail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmailModel> ListMailsById(int id)
        {
            try
            {
                var registerEmail = await _context.Emails.FirstOrDefaultAsync(info => info.Id == id);

                return registerEmail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmailModel> SaveClientsData(EmailModel info)
        {
            try
            {
                _context.Add(info);
                await _context.SaveChangesAsync();

                return info;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SendEmail(string adressEmail, string subjectEmail, string textEmail)
        {
            try
            {
                string username = _configuration.GetValue<string>("SMTP:Username");
                string name = _configuration.GetValue<string>("SMTP:Name");
                string host = _configuration.GetValue<string>("SMTP:Host");
                string password = _configuration.GetValue<string>("SMTP:Password");
                int port = _configuration.GetValue<int>("SMTP:Port");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, name),
                };

                mail.To.Add(adressEmail);
                mail.Subject = subjectEmail;
                mail.Body = textEmail;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using(SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
