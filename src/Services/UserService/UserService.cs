using System.Security.Cryptography;
using mail_web_app.Data;
using mail_web_app.Dto;
using mail_web_app.Models;

namespace mail_web_app.Services.UserService
{
    public class UserService : IUserInterface
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateHashPassword(string password, out byte[] hashPassword, out byte[] saltPassword)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                saltPassword = hmac.Key;
                hashPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<UserModel> Register(UserCreationDto userCreationDto)
        {
            try
            {
                CreateHashPassword(userCreationDto.Password, out byte[] hashPassword, out byte[] saltPassword);

                var user = new UserModel()
                {
                    User = userCreationDto.User,
                    Email = userCreationDto.Email,
                    HashPassword = hashPassword,
                    SaltPassword = saltPassword
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
