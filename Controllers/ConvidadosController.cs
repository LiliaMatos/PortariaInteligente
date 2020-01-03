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
    public class ConvidadosController : Controller
    {
        private readonly PortariaInteligenteContext _context;

        public ConvidadosController(PortariaInteligenteContext context)
        {
            _context = context;
        }

        // GET: Convidados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Convidados.ToListAsync());
        }

        // GET: Convidados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidado = await _context.Convidados
                .FirstOrDefaultAsync(m => m.ConvidadoId == id);
            if (convidado == null)
            {
                return NotFound();
            }

            return View(convidado);
        }

        // GET: Convidados/Create
        public IActionResult Create()
        {
            ViewBag.Id = new SelectList
                (
                    new TipoDocto().ListaDoctos(),
                    "tipoDoctoId",
                    "nomeDocto"
                );

            return View();
        }

        // POST: Convidados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConvidadoId,nomeConvidado,emailConvidado,celConvidado,doctoConvidado")] Convidado convidado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convidado);
                ViewBag.Id = new SelectList
                         (
                             new TipoDocto().ListaDoctos(),
                             "tipoDoctoId",
                             "nomeDocto"
                            // tipoDoctoId
                         );
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(convidado);
        }

        // GET: Convidados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidado = await _context.Convidados.FindAsync(id);
            if (convidado == null)
            {
                return NotFound();
            }
            return View(convidado);
        }

        // POST: Convidados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConvidadoId,nomeConvidado,emailConvidado,celConvidado,doctoConvidado")] Convidado convidado)
        {
            if (id != convidado.ConvidadoId)
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
                    if (!ConvidadoExists(convidado.ConvidadoId))
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
            return View(convidado);
        }

        // GET: Convidados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convidado = await _context.Convidados
                .FirstOrDefaultAsync(m => m.ConvidadoId == id);
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
            var convidado = await _context.Convidados.FindAsync(id);
            _context.Convidados.Remove(convidado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvidadoExists(int id)
        {
            return _context.Convidados.Any(e => e.ConvidadoId == id);
        }

        public ActionResult CreateDropDownList()
        {
            // Criando uma ViewBag com uma lista de doctos.
            // new SelectList significa retornar uma
            // estrutura de DropDownList
            ViewBag.Id = new SelectList
                (
                    new TipoDocto().ListaDoctos(),
                    "tipoDoctoId",
                    "nomeDocto"
                );

            return View();
        }

        public ActionResult PostDropDownList(string tipoDoctoId)
        {
            // O quarto parametro "tipoDoctoId" diz qual é o ID
            // que deve vir pré-selecionado ao montar o DropDownList
            ViewBag.Id = new SelectList
                (
                    new TipoDocto().ListaDoctos(),
                    "tipoDoctoId",
                    "nomeDocto",
                    tipoDoctoId
                );

            return View();
        }


    }
}
