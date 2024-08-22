using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SwapnaliTask.Data;
using SwapnaliTask.Models.ViewModels;

namespace SwapnaliTask.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext db;

        public AuthController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginvm)
        {
            if (ModelState.IsValid)
            {
                var user = db.users.FirstOrDefault(x => (x.Username.Equals(loginvm.Username) || x.Email.Equals(loginvm.Username)) && x.PasswordHash.Equals(loginvm.Password));
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.Username),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties{};

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToAction(nameof(Index), "Home");
                }
            }
            TempData["message"] = "Credentials are not right";
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registervm)
        {
            if (ModelState.IsValid)
            {
                var user = new Models.User
                {
                    Username = registervm.Username,
                    Email = registervm.Email,
                    PasswordHash = registervm.Password
                };

                db.users.Add(user);
                db.SaveChanges();
                TempData["message"] = "User Registered Successfully";
                return RedirectToAction(nameof(Login));
            }
            return View();
        }
    }
}
