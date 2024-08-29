using System.ComponentModel.DataAnnotations;

namespace mail_web_app.Dto
{
    public class UserCreationDto
    {
        [Required(ErrorMessage = "Enter a user!")]
        public string User { get; set; }
        [Required(ErrorMessage = "Enter a Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter a Password!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter a Password Confirmation!"),
         Compare("Password", ErrorMessage = "Different passwords!")]
        public string PasswordConfirm { get; set; }
    }
}
