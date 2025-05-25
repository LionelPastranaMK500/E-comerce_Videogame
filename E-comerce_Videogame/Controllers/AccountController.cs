using E_comerce_Videogame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_comerce_Videogame.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Muestra la página de login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Procesa el login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Correo y contraseña son obligatorios.";
                return View();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                ViewBag.Error = "Usuario no encontrado.";
                return View();
            }

            bool match = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            ViewBag.DebugMatch = match;
            ViewBag.DebugHash = user.PasswordHash;
            ViewBag.DebugPlain = password;

            if (!match)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View();
            }

            var roles = await _context.UserRoles
                .Where(ur => ur.UserId == user.UserId)
                .Join(_context.Roles,
                      ur => ur.RoleId,
                      r => r.RoleId,
                      (ur, r) => r.Name)
                .ToListAsync();

            // Creamos los claims básicos
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Name)
        };
            // Añadimos un claim por cada rol
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            // Creamos la identidad con el esquema "CookieAuth"
            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                "CookieAuth",
                principal,
                new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) }
            );

            return RedirectToAction("Index", "Home");
        }

        // Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}