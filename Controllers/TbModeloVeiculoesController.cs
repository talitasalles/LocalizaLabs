using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocalizaCS.Data;
using LocalizaCS.Models;

namespace LocalizaCS.Views.TbModeloVeiculos
{
    public class TbModeloVeiculoesController : Controller
    {
        private readonly LocalizaCSContext _context;

        public TbModeloVeiculoesController(LocalizaCSContext context)
        {
            _context = context;
        }

        // GET: TbModeloVeiculoes
        public async Task<IActionResult> Index()
        {
            var localizaCSContext = _context.TbModeloVeiculo.Include(t => t.Marca);
            return View(await localizaCSContext.ToListAsync());
        }

        // GET: TbModeloVeiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbModeloVeiculo = await _context.TbModeloVeiculo
                .Include(t => t.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbModeloVeiculo == null)
            {
                return NotFound();
            }

            return View(tbModeloVeiculo);
        }

        // GET: TbModeloVeiculoes/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca");
            return View();
        }

        // POST: TbModeloVeiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MarcaId,Modelo")] TbModeloVeiculo tbModeloVeiculo)
        {
            tbModeloVeiculo.Modelo = tbModeloVeiculo.Modelo.ToUpper();

            if (ModelState.IsValid)
            {
                _context.Add(tbModeloVeiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca", tbModeloVeiculo.MarcaId);
            return View(tbModeloVeiculo);
        }

        // GET: TbModeloVeiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbModeloVeiculo = await _context.TbModeloVeiculo.FindAsync(id);
            if (tbModeloVeiculo == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca", tbModeloVeiculo.MarcaId);
            return View(tbModeloVeiculo);
        }

        // POST: TbModeloVeiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MarcaId,Modelo")] TbModeloVeiculo tbModeloVeiculo)
        {
            if (id != tbModeloVeiculo.Id)
            {
                return NotFound();
            }

            tbModeloVeiculo.Modelo = tbModeloVeiculo.Modelo.ToUpper();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbModeloVeiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbModeloVeiculoExists(tbModeloVeiculo.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca", tbModeloVeiculo.MarcaId);
            return View(tbModeloVeiculo);
        }

        // GET: TbModeloVeiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbModeloVeiculo = await _context.TbModeloVeiculo
                .Include(t => t.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbModeloVeiculo == null)
            {
                return NotFound();
            }

            return View(tbModeloVeiculo);
        }

        // POST: TbModeloVeiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbModeloVeiculo = await _context.TbModeloVeiculo.FindAsync(id);
            _context.TbModeloVeiculo.Remove(tbModeloVeiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbModeloVeiculoExists(int id)
        {
            return _context.TbModeloVeiculo.Any(e => e.Id == id);
        }
    }
}
