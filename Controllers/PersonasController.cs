using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReportesMVC.Models;

namespace ReportesMVC.Controllers
{
    public class PersonasController : Controller
    {
        private readonly BdreportesContext _context;

        public PersonasController(BdreportesContext context)
        {
            _context = context;
        }

        // GET: Personas/Grid?usuarioId=1
        public async Task<IActionResult> Grid(int? usuarioId)
         {
             if (usuarioId == null) return NotFound();

             // Trae solo la persona del usuario logueado
             var persona = await _context.Personas
                 .Where(p => p.Iidpersona == usuarioId)
                 .ToListAsync();

             return View(persona); // Views/Personas/Grid.cshtml
         }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null) return NotFound();
            ViewBag.ListaSexo = new SelectList(
            await _context.Sexos
            .Where(s => s.Bhabilitado == 1) // opcional si usas habilitado
            .ToListAsync(),
           "Iidsexo",
           "Nombre",
             persona.Iidsexo // esto deja seleccionado el actual
    );

            return View(persona); // Views/Personas/Edit.cshtml
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Persona persona)
        {
            if (id != persona.Iidpersona) return NotFound();

            var personaDb = await _context.Personas.FindAsync(id);
            if (personaDb == null) return NotFound();

            // Actualizamos SOLO los campos que se editan
            personaDb.Nombre = persona.Nombre;
            personaDb.Appaterno = persona.Appaterno;
            personaDb.Apmaterno = persona.Apmaterno;
            personaDb.Iidsexo = persona.Iidsexo;
            personaDb.Correo = persona.Correo;
            personaDb.Telefonoocelular1 = persona.Telefonoocelular1;
            personaDb.Iidtipodocumento = persona.Iidtipodocumento;
            personaDb.Numeroidentificacion = persona.Numeroidentificacion;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Grid), new { usuarioId = id });
        }
    }
}