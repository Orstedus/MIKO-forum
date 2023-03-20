using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MIKO.Models;
using System.Security.Claims;
using MIKO.Models.UserModels;
using MIKO.Models.CoctailModels;

namespace MIKO.Controllers
{
    public class AccountController : Controller
    {

        ApplicationContext db;
        public AccountController(ApplicationContext context) { db = context; }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(UserModel model)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(model);
                db.SaveChangesAsync();
                Console.WriteLine(model.Login + " was registered!");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;


            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Home", "Forum");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {

            UserModel user = db.Users.FirstOrDefault(p => p.Login == model.Login && p.Password == model.Password);

            if (user != null)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, model.Login),
                    new Claim("OtherProperties","Role")

                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {

                    AllowRefresh = true,
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                CurrentUserModel.CurrentUser = db.Users.FirstOrDefault(p => p.Login == model.Login);

                return RedirectToAction("Home", "Forum");
            }



            ViewData["ValidateMessage"] = "user not found";
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            CurrentUserModel.CurrentUser.Login = "Guest";
            CurrentUserModel.CurrentUser.Id = 0;
            CurrentUserModel.CurrentUser.Email = "None";
            CurrentUserModel.CurrentUser.Password = "None";
            return RedirectToAction("Login", "Account");
        }
    }
}
