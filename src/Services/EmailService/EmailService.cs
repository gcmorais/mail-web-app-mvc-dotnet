using System.Collections.Generic;
using mail_web_app.Data;
using mail_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace mail_web_app.Services.EmailService
{
    public class EmailService : IEmailInterface
    {
        private readonly AppDbContext _context;

        public EmailService(AppDbContext context)
        {
            _context = context;
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
    }
}
