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

        [HttpGet]
        public async Task<ActionResult<EmailModel>> DetailsEmail(int id)
        {
            var registerEmail = await _emailInterface.ListMailsById(id);
            return View(registerEmail);
        }

        [HttpPost]
        public async Task<ActionResult<EmailModel>> SendEmail(string adressEmail,string subjectEmail, string textEmail, int id)
        {
            var email = await _emailInterface.ListMailsById(id);

            if (email.Status == false)
            {
                TempData["ErrorMessage"] = "Cannot send email to an inactive record!";
                return View("DetailsEmail", email);
            }

            if (textEmail == null || subjectEmail == null)
            {

                TempData["ErrorMessage"] = "Enter a subject and body for the email!";
                return View("DetailsEmail", email);
            }


            bool resultado = _emailInterface.SendEmail(adressEmail, subjectEmail, textEmail);

            if (resultado == true)
            {
                TempData["MessageSuccess"] = "Email sent successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "There was a problem sending the email!";
            }


            return RedirectToAction("Index");
        }
    }
}
