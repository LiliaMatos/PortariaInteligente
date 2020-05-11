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
    public class VisitadosController : Controller
    {
        private readonly PortariaInteligenteContext _context;

        public VisitadosController(PortariaInteligenteContext context)
        {
            _context = context;
        }

        // GET: Visitados
        public async Task<IActionResult> Index()
        {
            return View(await _context.InternalUsers .ToListAsync());
        }

        // GET: Visitados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitado = await _context.InternalUsers
                .FirstOrDefaultAsync(m => m.IdInternalUser == id);
            if (visitado == null)
            {
                return NotFound();
            }

            return View(visitado);
        }

        // GET: Visitados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInternalUserId,UserName,Email,PhoneNumber,LandPhone")] InternalUser visitado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitado);
        }

        // GET: Visitados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitado = await _context.InternalUsers.FindAsync(id);
            if (visitado == null)
            {
                return NotFound();
            }
            return View(visitado);
        }

        // POST: Visitados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInternalUserId,UserName,Email,PhoneNumber,LandPhone")] InternalUser visitado)
        {
            if (id != visitado.IdInternalUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitadoExists(visitado.IdInternalUser))
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
            return View(visitado);
        }

        // GET: Visitados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitado = await _context.InternalUsers
                .FirstOrDefaultAsync(m => m.IdInternalUser == id);
            if (visitado == null)
            {
                return NotFound();
            }

            return View(visitado);
        }

        // POST: Visitados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitado = await _context.InternalUsers.FindAsync(id);
            _context.InternalUsers.Remove(visitado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitadoExists(int id)
        {
            return _context.InternalUsers.Any(e => e.IdInternalUser == id);
        }
    }
}
