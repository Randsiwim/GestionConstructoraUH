using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionConstructoraUH.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionConstructoraUH.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly GestionConstructoraUHContext _context;

        public AsignacionesController(GestionConstructoraUHContext context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public IActionResult Index()
        {
            var asignaciones = _context.Asignaciones
                .Include(a => a.Empleado)
                .Include(a => a.Proyecto)
                .ToList();

            return View(asignaciones);
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            ViewData["Empleados"] = new SelectList(_context.Empleados, "IdEmpleado", "NombreCompleto");
            ViewData["Proyectos"] = new SelectList(_context.Proyectos, "IdProyecto", "NombreProyecto");
            return View();
        }

        // POST: Asignaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Asignacion asignacion)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var value = ModelState[modelStateKey];
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine($"Error en {modelStateKey}: {error.ErrorMessage}");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                _context.Asignaciones.Add(asignacion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Recargar las listas desplegables si hay un error
            ViewData["Empleados"] = new SelectList(_context.Empleados, "IdEmpleado", "NombreCompleto", asignacion.IdEmpleado);
            ViewData["Proyectos"] = new SelectList(_context.Proyectos, "IdProyecto", "NombreProyecto", asignacion.IdProyecto);

            return View(asignacion);
        }



        // POST: Asignaciones/Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var asignacion = _context.Asignaciones.Find(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
