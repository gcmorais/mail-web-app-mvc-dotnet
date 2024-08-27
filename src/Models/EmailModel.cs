using System.ComponentModel.DataAnnotations;

namespace mail_web_app.Models
{
    public class EmailModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; } = true;
        public DateTime DataDeRegistro { get; set; } = DateTime.Now;
    }
}
