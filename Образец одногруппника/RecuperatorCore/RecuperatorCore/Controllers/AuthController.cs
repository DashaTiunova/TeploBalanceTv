using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RecuperatorCore.Models;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authentication;
using AutoMapper;
using RecuperatorLibrary.Models;

namespace RecuperatorCore.Controllers
{
    public class AuthController : Controller
    {
        private readonly RecuperatorContext _context;
        private readonly IMapper _mapper;
        public AuthController(RecuperatorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Index(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, login) };
                // создаем объект ClaimsIdentity
                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                // установка аутентификационных куки
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
            else
            {
                TempData["AlertMessage"] = "Логин или пароль неправильный, пользователь не найден";
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(UserAddDto model)
        {
            var user = _mapper.Map<User>(model);
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Auth");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Auth");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
