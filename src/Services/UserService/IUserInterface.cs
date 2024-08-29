using mail_web_app.Dto;
using mail_web_app.Models;

namespace mail_web_app.Services.UserService
{
    public interface IUserInterface
    {
        Task<UserModel> Register(UserCreationDto userCreationDto);
        Task<UserModel> Login(UserLoginDto userLoginDto);
    }
}
