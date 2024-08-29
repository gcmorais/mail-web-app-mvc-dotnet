using mail_web_app.Dto;
using mail_web_app.Models;
using mail_web_app.Services.EmailService;
using mail_web_app.Services.SectionService;
using mail_web_app.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace mail_web_app.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmailInterface _emailInterface;
        private readonly IUserInterface _userInterface;
        private readonly ISectionInterface _sectionInterface;

        public HomeController(IEmailInterface emailInterface, IUserInterface userInterface, ISectionInterface sectionInterface)
        {
            _emailInterface = emailInterface;
            _userInterface = userInterface;
            _sectionInterface = sectionInterface;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThanksMessage(EmailModel Info)
        {
            return View(Info);
        }

        public IActionResult Login()
        {
            return View();
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

        [HttpPost]
        public async Task<ActionResult<UserModel>> Login(UserLoginDto userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = await _userInterface.Login(userLogin);

                if (user.Id == 0)
                {
                    TempData["ErrorMessage"] = "Credentials Invalid!";
                    return View(userLogin);
                }

                TempData["MessageSuccess"] = "User successfully logged in!";

                _sectionInterface.CreateSection(user);
                return RedirectToAction("Index", "Email");
            }

            return View(userLogin);
        }
    }
}