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
    public class ConvidadosController : Controller
    {
        private readonly PortariaInteligenteContext _context;

        public ConvidadosController(PortariaInteligenteContext context)
        {
            _context = context;
        }

        // GET: Convidados
        public async Task<IActionResult> Index(string searchString)
        {
            var portariaInteligenteContext = _context.ExternalUsers.Include(c => c.IdDocument);
            var convidados = from m in _context.ExternalUsers select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                convidados = convidados.Where(s => s.UserName.Contains(searchString));
            }
            return View(await convidados .ToListAsync());           
        }

        // GET: Convidados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidado = await _context.ExternalUsers 
                .Include(c => c.IdDocument )
                .FirstOrDefaultAsync(m => m.IdExternalUser == id);
            if (convidado == null)
            {
                return NotFound();
            }

            return View(convidado);
        }

        // GET: Convidados/Create
        public IActionResult Create()
        {
            ViewData["IdDocument"] = new SelectList(_context.Documents, "IdDocument", "NameDocument");
            return View();
        }

        // POST: Convidados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExternalUSer,UserName,IdCompany,Email,PhoneNumber,IdDocument,NumberDoc,PlateCar,BrandCar,ModelCar,ColorCar")] ExternalUser convidado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convidado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentoId"] = new SelectList(_context.Documents, "IdDocument", "NameDocument", convidado.IdDocument);
            return View(convidado);
        }

        // GET: Convidados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidado = await _context.ExternalUsers .FindAsync(id);
            if (convidado == null)
            {
                return NotFound();
            }
            ViewData["IdDocument"] = new SelectList(_context.Documents, "IdDocument", "NameDocument", convidado.IdDocument);
            return View(convidado);
        }

        // POST: Convidados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExternalUSer,UserName,IdCompany,Email,PhoneNumber,IdDocument,NumberDoc,PlateCar,BrandCar,ModelCar,ColorCar")] ExternalUser convidado)
        {
            if (id != convidado.IdExternalUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convidado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvidadoExists(convidado.IdExternalUser))
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
            ViewData["IdDocument"] = new SelectList(_context.Documents, "IdDocument", "NameDocument", convidado.IdDocument);
            return View(convidado);
        }

        // GET: Convidados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidado = await _context.ExternalUsers 
                .Include(c => c.IdDocument)
                .FirstOrDefaultAsync(m => m.IdExternalUser == id);
            if (convidado == null)
            {
                return NotFound();
            }

            return View(convidado);
        }

        // POST: Convidados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convidado = await _context.ExternalUsers.FindAsync(id);
            _context.ExternalUsers.Remove(convidado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvidadoExists(int id)
        {
            return _context.ExternalUsers.Any(e => e.IdExternalUser== id);
        }
    }
}
