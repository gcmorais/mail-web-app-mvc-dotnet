using System.ComponentModel.DataAnnotations;

namespace mail_web_app.Dto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Enter a Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter a Password!")]
        public string Password { get; set; }
    }
}
