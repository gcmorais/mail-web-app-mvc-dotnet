using mail_web_app.Data;
using mail_web_app.Models;

namespace mail_web_app.Services.EmailService
{
    public class EmailService : IEmailInterface
    {
        private readonly AppDbContext _context;

        public EmailService(AppDbContext context)
        {
            _context = context;
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
