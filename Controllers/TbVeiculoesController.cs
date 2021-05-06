using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocalizaCS.Data;
using LocalizaCS.Models;

namespace LocalizaCS.Views.TbVeiculos
{
    public class TbVeiculoesController : Controller
    {
        private readonly LocalizaCSContext _context;

        public TbVeiculoesController(LocalizaCSContext context)
        {
            _context = context;
        }

        // GET: TbVeiculoes
        public async Task<IActionResult> Index()
        {
            var localizaCSContext = _context.TbVeiculo.Include(t => t.Marca).Include(t => t.Modelo);
            return View(await localizaCSContext.ToListAsync());
        }

        // GET: TbVeiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVeiculo = await _context.TbVeiculo
                .Include(t => t.Marca)
                .Include(t => t.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbVeiculo == null)
            {
                return NotFound();
            }

            return View(tbVeiculo);
        }

        // GET: TbVeiculoes/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca");
            ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>(), "Id", "Modelo");

            return View();
        }

        // POST: TbVeiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,MarcaId,ModeloId,Ano,ValorHora,Combustivel,LtPortaMala,Categoria")] TbVeiculo tbVeiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbVeiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca", tbVeiculo.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>(), "Id", "Modelo", tbVeiculo.ModeloId);
            return View(tbVeiculo);
        }

        // GET: TbVeiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVeiculo = await _context.TbVeiculo.FindAsync(id);
            if (tbVeiculo == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca", tbVeiculo.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>(), "Id", "Modelo", tbVeiculo.ModeloId);
            return View(tbVeiculo);
        }

        // POST: TbVeiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,MarcaId,ModeloId,Ano,ValorHora,Combustivel,LtPortaMala,Categoria")] TbVeiculo tbVeiculo)
        {
            if (id != tbVeiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbVeiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbVeiculoExists(tbVeiculo.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca", tbVeiculo.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>(), "Id", "Modelo", tbVeiculo.ModeloId);
            return View(tbVeiculo);
        }

        // GET: TbVeiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVeiculo = await _context.TbVeiculo
                .Include(t => t.Marca)
                .Include(t => t.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbVeiculo == null)
            {
                return NotFound();
            }

            return View(tbVeiculo);
        }

        // POST: TbVeiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbVeiculo = await _context.TbVeiculo.FindAsync(id);
            _context.TbVeiculo.Remove(tbVeiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbVeiculoExists(int id)
        {
            return _context.TbVeiculo.Any(e => e.Id == id);
        }
    }
}
