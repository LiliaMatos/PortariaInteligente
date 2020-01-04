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
    public class AnfitrioesController : Controller
    {
        private readonly PortariaInteligenteContext _context;

        public AnfitrioesController(PortariaInteligenteContext context)
        {
            _context = context;
        }

        // GET: Anfitrioes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anfitrioes.ToListAsync());
        }

        // GET: Anfitrioes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anfitriao = await _context.Anfitrioes
                .FirstOrDefaultAsync(m => m.AnfitriaoId == id);
            if (anfitriao == null)
            {
                return NotFound();
            }

            return View(anfitriao);
        }

        // GET: Anfitrioes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anfitrioes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnfitriaoId,nomeAnfitriao,emailAnfitriao,celAnfitriao,fixoAnfitriao,senhaAnfitriao,tokenAnfitiao")] Anfitriao anfitriao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anfitriao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anfitriao);
        }

        // GET: Anfitrioes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anfitriao = await _context.Anfitrioes.FindAsync(id);
            if (anfitriao == null)
            {
                return NotFound();
            }
            return View(anfitriao);
        }

        // POST: Anfitrioes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnfitriaoId,nomeAnfitriao,emailAnfitriao,celAnfitriao,fixoAnfitriao,senhaAnfitriao,tokenAnfitiao")] Anfitriao anfitriao)
        {
            if (id != anfitriao.AnfitriaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anfitriao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnfitriaoExists(anfitriao.AnfitriaoId))
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
            return View(anfitriao);
        }

        // GET: Anfitrioes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anfitriao = await _context.Anfitrioes
                .FirstOrDefaultAsync(m => m.AnfitriaoId == id);
            if (anfitriao == null)
            {
                return NotFound();
            }

            return View(anfitriao);
        }

        // POST: Anfitrioes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anfitriao = await _context.Anfitrioes.FindAsync(id);
            _context.Anfitrioes.Remove(anfitriao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnfitriaoExists(int id)
        {
            return _context.Anfitrioes.Any(e => e.AnfitriaoId == id);
        }
    }
}
