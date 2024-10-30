using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_Josue_Riera.Data;

namespace Examen_Josue_Riera.Controllers
{
    public class JRierasController : Controller
    {
        private readonly Examen_Josue_RieraContext _context;

        public JRierasController(Examen_Josue_RieraContext context)
        {
            _context = context;
        }

        // GET: JRieras
        public async Task<IActionResult> Index()
        {
            var examen_Josue_RieraContext = _context.JRiera.Include(j => j.Celular);
            return View(await examen_Josue_RieraContext.ToListAsync());
        }

        // GET: JRieras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jRiera = await _context.JRiera
                .Include(j => j.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jRiera == null)
            {
                return NotFound();
            }

            return View(jRiera);
        }

        // GET: JRieras/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Celular, "Id", "Modelo");
            return View();
        }

        // POST: JRieras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,Salario,Activo,FechaRegistro,IdCelular")] JRiera jRiera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jRiera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Celular, "Id", "Modelo", jRiera.IdCelular);
            return View(jRiera);
        }

        // GET: JRieras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jRiera = await _context.JRiera.FindAsync(id);
            if (jRiera == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Celular, "Id", "Modelo", jRiera.IdCelular);
            return View(jRiera);
        }

        // POST: JRieras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,Salario,Activo,FechaRegistro,IdCelular")] JRiera jRiera)
        {
            if (id != jRiera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jRiera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JRieraExists(jRiera.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Celular, "Id", "Modelo", jRiera.IdCelular);
            return View(jRiera);
        }

        // GET: JRieras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jRiera = await _context.JRiera
                .Include(j => j.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jRiera == null)
            {
                return NotFound();
            }

            return View(jRiera);
        }

        // POST: JRieras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jRiera = await _context.JRiera.FindAsync(id);
            if (jRiera != null)
            {
                _context.JRiera.Remove(jRiera);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JRieraExists(int id)
        {
            return _context.JRiera.Any(e => e.Id == id);
        }
    }
}
