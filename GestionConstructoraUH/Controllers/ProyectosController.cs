using Microsoft.AspNetCore.Mvc;
using GestionConstructoraUH.Models;

namespace GestionConstructoraUH.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly GestionConstructoraUHContext _context;

        public ProyectosController(GestionConstructoraUHContext context)
        {
            _context = context;
        }

        // Acción: Mostrar lista de proyectos
        public IActionResult Index()
        {
            var proyectos = _context.Proyectos.ToList();
            return View(proyectos);
        }

        // Acción: Mostrar formulario para crear un nuevo proyecto
        public IActionResult Create()
        {
            return View();
        }

        // Acción: Procesar el formulario y crear un nuevo proyecto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Proyectos.Add(proyecto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(proyecto);
        }

        // Acción: Mostrar formulario para editar un proyecto
        public IActionResult Edit(int id)
        {
            var proyecto = _context.Proyectos.Find(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            return View(proyecto);
        }

        // Acción: Procesar el formulario y actualizar un proyecto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Proyecto proyecto)
        {
            if (id != proyecto.IdProyecto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(proyecto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(proyecto);
        }

        // Acción: Eliminar un proyecto
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var proyecto = _context.Proyectos.Find(id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
