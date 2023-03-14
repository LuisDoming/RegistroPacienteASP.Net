using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PacientesRegister.Models;
using PacientesRegister.Models.ViewModels;

namespace PacientesRegister.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacientesDbContext _context;

        public PacienteController(PacientesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pacientes = _context.DatosPacientes.Include(b => b.TipoSangre);
            return View(await pacientes.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["TiposSangre"] = new SelectList(_context.TipoSangres, "Id", "Tipo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PacienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var paciente = new DatosPaciente()
                {
                    Clavepaciente = model.Clavepaciente,
                    Apellidos = model.Apellidos,
                    NombrePac = model.NombrePac,
                    DireccionPac = model.DireccionPac,
                    EmailPac = model.EmailPac,
                    TelefonoCasa = model.TelefonoCasa,
                    TelefonoCelular = model.TelefonoCelular,
                    SexoPac = model.SexoPac,
                    Activo = model.Activo,
                    TipoSangreId = model.TipoSangreID,
                };
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TiposSangre"] = new SelectList(_context.TipoSangres, "Id", "Tipo",model.TipoSangreID);
            return View(model);
        }
    }
}
    