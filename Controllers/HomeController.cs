using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportesMVC.Models;
using System.Diagnostics;

namespace ReportesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BdreportesContext _context; // DbContext de la BD

        public HomeController(ILogger<HomeController> logger, BdreportesContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Index (pantalla de login)
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(string numeroIdentificacion, string password)
        {
            // Buscar el usuario en la tabla Usuarios, incluyendo la persona asociada
            var usuario = await _context.Usuarios
                .Include(u => u.IidpersonaNavigation) // nombre correcto de la navegación
                .FirstOrDefaultAsync(u => u.IidpersonaNavigation.Numeroidentificacion == numeroIdentificacion
                                      && u.Password == password);

            if (usuario != null)
            {
                // Guardar ID y nombre en TempData para usar en el grid
                TempData["IidPersona"] = usuario.Iidpersona;
                TempData["NombreUsuario"] = usuario.IidpersonaNavigation.Nombre;

                // Redirigir al Grid (PersonasController)
                return RedirectToAction("Grid", "Personas",
                   new { usuarioId = usuario.Iidpersona });
            }
            else
            {
                // Mostrar mensaje de error si los datos son incorrectos
                ViewBag.Error = "¡Datos Inválidos! Por favor Verifique.";
                return View("Index");
            }
        }

        // GET: Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}