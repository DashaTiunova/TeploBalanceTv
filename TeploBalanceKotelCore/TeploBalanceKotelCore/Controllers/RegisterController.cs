using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeploBalanceKotelCore.Data;
using TeploBalanceKotelCore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TeploBalanceKotelCore.Controllers
{
    public class RegisterController : Controller
    {
        
        //private HttpContext _httpContext;
            private readonly DataContext_TverdToplivo _context;

            public RegisterController(DataContext_TverdToplivo context)
            {
                _context = context;
            }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            { 
                var existinguser= await _context.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName);
                if (existinguser != null)
                {
                    ModelState.AddModelError("UserName", "Пользователь с таким логином уже существует.");
                    return View(model); // Вернуть представление с ошибкой
                }
                var newUser = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Role = UserRole.User,
                    Password = model.Password // Обратите внимание: здесь лучше использовать хэширование паролей!
                };
              
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                
                var claims = new List<Claim> {
                    new Claim("UserId", newUser.ID_User.ToString()),
                    new Claim(ClaimTypes.Name, newUser.UserName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                //реализовать авторизацию
                return RedirectToAction("Index", "Auth");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
