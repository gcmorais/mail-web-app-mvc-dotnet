using mail_web_app.Models;
using mail_web_app.Services.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace mail_web_app.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmailInterface _emailInterface;

        public HomeController(IEmailInterface emailInterface)
        {
            _emailInterface = emailInterface;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThanksMessage(EmailModel Info)
        {
            return View(Info);
        }

        [HttpPost]
        public async Task<ActionResult> SaveClientsData(EmailModel Info)
        {
            if (ModelState.IsValid)
            {
                var registry = await _emailInterface.SaveClientsData(Info);
                return View("ThanksScreen", registry);
            }

            return RedirectToAction("Index");
        }

    }
}