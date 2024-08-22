using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace mail_web_app.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}