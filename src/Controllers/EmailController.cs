using mail_web_app.Models;
using mail_web_app.Services.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace mail_web_app.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailInterface _emailInterface;

        public EmailController(IEmailInterface emailInterface)
        {
            _emailInterface = emailInterface;
        }
        public async Task<ActionResult<List<EmailModel>>> Index(string? search)
        {
            if(search != null)
            {
                var searchFilter = await _emailInterface.ListMails(search);
                return View(searchFilter);
            }

            var registryEmails = await _emailInterface.ListMails();
            return View(registryEmails);
        }
    }
}
