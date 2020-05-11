using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortariaInteligente.Data;
using PortariaInteligente.Models;

namespace PortariaInteligente.Controllers
{
    //[Authorize]
    public class EventosController : Controller
    {
        private readonly PortariaInteligenteContext _context;

        public EventosController(PortariaInteligenteContext context)
        {
            _context = context;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            var portariaInteligenteContext = _context.Meetings.Include(e => e.InternalUser);
            return View(await portariaInteligenteContext.ToListAsync());
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Meetings 
                .Include(e => e.InternalUser)
                .FirstOrDefaultAsync(m => m.IdMeeting == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            ViewData["IdInternalUser"] = new SelectList(_context.InternalUsers, "IdInternalUser", "UserName");
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMeeting,NameMeeting,DateMeeting, TimeMeeting,PlaceMeeting,IdInternalUser")] Meeting evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInternalUser"] = new SelectList(_context.InternalUsers, "IdInternalUser", "UserName", evento.IdInternalUser);
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Meetings.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["IdInternalUser"] = new SelectList(_context.InternalUsers, "IdInternalUser", "UserName", evento.IdInternalUser);
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMeeting,NameMeeting,DateMeeting,TimeMeeting,PlaceMeeting,IdInternalUser")] Meeting  evento)
        {
            if (id != evento.IdMeeting)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.IdMeeting))
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
            ViewData["IdInternalUser"] = new SelectList(_context.InternalUsers, "IdInternalUser", "UserName", evento.IdInternalUser);
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Meetings
                .Include(e => e.InternalUser)
                .FirstOrDefaultAsync(m => m.IdMeeting == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Meetings.FindAsync(id);
            _context.Meetings.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Meetings.Any(e => e.IdMeeting == id);
        }
    }
}
