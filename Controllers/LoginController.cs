using MessagingApp.Models;
using MessagingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessagingApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(ILogger<HomeController> logger, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya parola yanlış girildi!");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", $"Çok fazla başarısız denemeden dolayı {user.LockoutEnd} tarihine kadar giriş yapamazsınız");
                return View();
            }

            var failedLoginAttemptCount = await _userManager.GetAccessFailedCountAsync(user);
            ModelState.AddModelError("", $"Başarısız giriş sayısı {failedLoginAttemptCount} / 3");
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
