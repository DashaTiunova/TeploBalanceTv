using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeploBalanceKotelCore.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
namespace TeploBalanceKotelCore.Controllers
{
    public class AuthController : Controller
    {
        //private HttpContext _httpContext;
        private readonly DataContext_TverdToplivo _context;

        public AuthController(DataContext_TverdToplivo context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string login,string password)
        {
            var user = _context.Users.FirstOrDefault(x=> x.UserName == login && x.Password == password);
            if (user == null)
            {
                Console.WriteLine("Пользователь не найден.");
            }
            if (user != null)
            {
                var claims = new List<Claim> {
                    new Claim("UserId", user.ID_User.ToString()),
                    new Claim(ClaimTypes.Name, login) 
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("DataInputTverd", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

     
        public async Task<IActionResult> Logout()
        {
           
                await HttpContext.SignOutAsync();
                //реализовать авторизацию
                return RedirectToAction("DataInputTverd", "Home");
            }

           
        }
    }

