using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortariaInteligente.Data;
using PortariaInteligente.Models;

namespace PortariaInteligente.Controllers
{
    public class TipoDoctosController : Controller
    {
        private readonly PortariaInteligenteContext _context;

        public TipoDoctosController(PortariaInteligenteContext context)
        {
            _context = context;
        }

        // GET: TipoDoctos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDoctos.ToListAsync());
        }

        // GET: TipoDoctos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocto = await _context.TipoDoctos
                .FirstOrDefaultAsync(m => m.tipoDoctoId == id);
            if (tipoDocto == null)
            {
                return NotFound();
            }

            return View(tipoDocto);
        }

        // GET: TipoDoctos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDoctos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tipoDoctoId,nomeDocto")] TipoDocto tipoDocto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocto);
        }

        // GET: TipoDoctos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocto = await _context.TipoDoctos.FindAsync(id);
            if (tipoDocto == null)
            {
                return NotFound();
            }
            return View(tipoDocto);
        }

        // POST: TipoDoctos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tipoDoctoId,nomeDocto")] TipoDocto tipoDocto)
        {
            if (id != tipoDocto.tipoDoctoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDoctoExists(tipoDocto.tipoDoctoId))
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
            return View(tipoDocto);
        }

        // GET: TipoDoctos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocto = await _context.TipoDoctos
                .FirstOrDefaultAsync(m => m.tipoDoctoId == id);
            if (tipoDocto == null)
            {
                return NotFound();
            }

            return View(tipoDocto);
        }

        // POST: TipoDoctos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDocto = await _context.TipoDoctos.FindAsync(id);
            _context.TipoDoctos.Remove(tipoDocto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDoctoExists(int id)
        {
            return _context.TipoDoctos.Any(e => e.tipoDoctoId == id);
        }
    }
}
