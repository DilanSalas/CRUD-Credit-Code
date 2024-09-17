using CreditFullSA.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CreditFullSA.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly DbContextCreditos _context;

        public AdministradorController(DbContextCreditos context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Administrador admin)
        {
            if (ModelState.IsValid)
            {
                var temp = ValidarUsuario(admin);
                if (temp != null)
                {
                    var userClaims = new List<Claim> { new Claim(ClaimTypes.Name, admin.email) };
                    var grandIdentity = new ClaimsIdentity(userClaims, "UserIdentity");
                    var adminPrincipal = new ClaimsPrincipal(new[] { grandIdentity });
                    await HttpContext.SignInAsync(adminPrincipal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Mensaje"] = "Credenciales incorrectas";
                }
            }
            return View(admin);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private Administrador ValidarUsuario(Administrador temp)
        {
            var user = _context.Administradores.FirstOrDefault(u => u.email == temp.email);
            if (user != null && user.Password.Equals(temp.Password))
            {
                return user;
            }
            return null;
        }
    }
}
