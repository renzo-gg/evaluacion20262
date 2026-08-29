using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoGasHogar.Data;
using TecnoGasHogar.Models;

namespace TecnoGasHogar.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly AppDbContext _context;
        public SolicitudesController(AppDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            var solicitudes = await _context.SolicitudesServicio
                .OrderByDescending(s => s.FechaRegistro)
                .ToListAsync();
            return View(solicitudes);
        }

        [HttpGet]
        public IActionResult Crear() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(SolicitudServicio solicitud)
        {
            if (ModelState.IsValid)
            {
                solicitud.FechaRegistro = DateTime.Now;
                _context.SolicitudesServicio.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitud);
        }
    }
}
