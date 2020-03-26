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
    public class ConvidadoEventosController : Controller
    {
        private readonly PortariaInteligenteContext _context;

        public ConvidadoEventosController(PortariaInteligenteContext context)
        {
            _context = context;
        }

        // GET: ConvidadoEventos
        public async Task<IActionResult> Index()
        {
            var portariaInteligenteContext = _context.ConvidadoEventos.Include(c => c.convidado).Include(c => c.evento);
            return View(await portariaInteligenteContext.ToListAsync());
        }

        // GET: ConvidadoEventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidadoEvento = await _context.ConvidadoEventos
                .Include(c => c.convidado)
                .Include(c => c.evento)
                .FirstOrDefaultAsync(m => m.ConvidadoEventoId == id);
            if (convidadoEvento == null)
            {
                return NotFound();
            }

            return View(convidadoEvento);
        }

        // GET: ConvidadoEventos/Create
        public IActionResult Create()
        {
            ViewData["ConvidadoId"] = new SelectList(_context.Convidados, "ConvidadoId", "emailConvidado");
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "localEvento");
            return View();
        }

        // POST: ConvidadoEventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConvidadoEventoId,EventoId,ConvidadoId")] ConvidadoEvento convidadoEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convidadoEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConvidadoId"] = new SelectList(_context.Convidados, "ConvidadoId", "emailConvidado", convidadoEvento.ConvidadoId);
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "localEvento", convidadoEvento.EventoId);
            return View(convidadoEvento);
        }

        // GET: ConvidadoEventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidadoEvento = await _context.ConvidadoEventos.FindAsync(id);
            if (convidadoEvento == null)
            {
                return NotFound();
            }
            ViewData["ConvidadoId"] = new SelectList(_context.Convidados, "ConvidadoId", "emailConvidado", convidadoEvento.ConvidadoId);
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "localEvento", convidadoEvento.EventoId);
            return View(convidadoEvento);
        }

        // POST: ConvidadoEventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConvidadoEventoId,EventoId,ConvidadoId")] ConvidadoEvento convidadoEvento)
        {
            if (id != convidadoEvento.ConvidadoEventoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convidadoEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvidadoEventoExists(convidadoEvento.ConvidadoEventoId))
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
            ViewData["ConvidadoId"] = new SelectList(_context.Convidados, "ConvidadoId", "emailConvidado", convidadoEvento.ConvidadoId);
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "localEvento", convidadoEvento.EventoId);
            return View(convidadoEvento);
        }

        // GET: ConvidadoEventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidadoEvento = await _context.ConvidadoEventos
                .Include(c => c.convidado)
                .Include(c => c.evento)
                .FirstOrDefaultAsync(m => m.ConvidadoEventoId == id);
            if (convidadoEvento == null)
            {
                return NotFound();
            }

            return View(convidadoEvento);
        }

        // POST: ConvidadoEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convidadoEvento = await _context.ConvidadoEventos.FindAsync(id);
            _context.ConvidadoEventos.Remove(convidadoEvento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvidadoEventoExists(int id)
        {
            return _context.ConvidadoEventos.Any(e => e.ConvidadoEventoId == id);
        }
    }
}
