namespace mail_web_app.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] SaltPassword { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
