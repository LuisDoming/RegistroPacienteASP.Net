using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PacientesRegister.Models;
using PacientesRegister.Models.ViewModels;

namespace PacientesRegister.Controllers
{
    public class TipoSangreController : Controller
    {
        private readonly PacientesDbContext _context;

        public TipoSangreController(PacientesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoSangres.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoSangreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sangre = new TipoSangre()
                {
                    Tipo = model.TipoSangre
                };
                _context.Add(sangre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
