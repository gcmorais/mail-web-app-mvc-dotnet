using mail_web_app.Models;
using Microsoft.EntityFrameworkCore;

namespace mail_web_app.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<EmailModel> Emails { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
