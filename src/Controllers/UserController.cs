using mail_web_app.Dto;
using mail_web_app.Filters;
using mail_web_app.Models;
using mail_web_app.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace mail_web_app.Controllers
{
    [UserLogin]
    public class UserController : Controller
    {

        private readonly IUserInterface _userInterface;

        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Register(UserCreationDto userCreationDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userInterface.Register(userCreationDto);

                if (user != null)
                {
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index", "Email");
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro no momento do cadastro!";
                    return View(userCreationDto);
                }

            }
            else
            {
                return View(userCreationDto);
            }
        }
    }
}
