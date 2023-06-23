using demo17.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace demo17.Controllers
{
    public class AccountController : Controller
    {
     
      
        public AppDBContext AppDBContext { get; }
        public AccountController(AppDBContext appDBContext)
        {
            AppDBContext = appDBContext;
        }
        public IActionResult Login()
        {
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginmModel)
        {
            var user = AppDBContext.Users.Include(x=>x.roles).Where(u => u.email == loginmModel.email && u.password == loginmModel.password).FirstOrDefault();
            if (user != null)
            {
                var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.email)),
                    new Claim(ClaimTypes.Name,user.firstName),
                    new Claim(ClaimTypes.Role,user.roles.role_name)



                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                   

                return RedirectToAction("Index", "Home");

            }
            else
            {

                ViewBag.Message = "Invalid Credential";
                return View();
            }

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
