using Microsoft.AspNetCore.Mvc;
using GestionConstructoraUH.Models;

namespace GestionConstructoraUH.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly GestionConstructoraUHContext _context;

        public EmpleadosController(GestionConstructoraUHContext context)
        {
            _context = context;
        }

        // Acción: Mostrar lista de empleados
        public IActionResult Index()
        {
            var empleados = _context.Empleados.ToList();
            return View(empleados);
        }

        // Acción: Mostrar formulario para crear un nuevo empleado
        public IActionResult Create()
        {
            return View();
        }

        // Acción: Procesar el formulario y crear un nuevo empleado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // Acción: Eliminar un empleado
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
