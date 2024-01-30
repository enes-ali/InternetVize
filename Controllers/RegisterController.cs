using MessagingApp.Models;
using MessagingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessagingApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public RegisterController(ILogger<HomeController> logger, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
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
        public async Task<IActionResult> Index(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var identityResult = await _userManager.CreateAsync(new()
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name
            }, model.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            var userRole = model.IsAdmin ? "Admin" : "User";
            var userRoleExists = await _roleManager.RoleExistsAsync(userRole);

            if (!userRoleExists)
            {
                var role = new Role { Name = userRole };
                await _roleManager.CreateAsync(role);
            }

            await _userManager.AddToRoleAsync(user, userRole);

            await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            return RedirectToAction("Index", "Home");
        }
    }
}
