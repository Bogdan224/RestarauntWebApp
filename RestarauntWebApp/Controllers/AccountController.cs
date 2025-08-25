using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestarauntWebApp.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace RestarauntWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            //Завершаемый текущий сеанс
            await _signInManager.SignOutAsync();

            ViewBag.ReturnUrl = returnUrl;

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            //Раздел сайта (URL), куда перенаправить пользователя после успешного логина
            ViewBag.ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
                return View(model);
            SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);

            if (result.Succeeded)
            {
                return Redirect(returnUrl ?? "/");
            }

            ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
