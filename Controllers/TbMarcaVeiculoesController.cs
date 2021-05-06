using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocalizaCS.Data;
using LocalizaCS.Models;

namespace LocalizaCS.Views.TbMarcasVeiculos
{
    public class TbMarcaVeiculoesController : Controller
    {
        private readonly LocalizaCSContext _context;

        public TbMarcaVeiculoesController(LocalizaCSContext context)
        {
            _context = context;
        }

        // GET: TbMarcaVeiculoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbMarcaVeiculo.ToListAsync());
        }

        // GET: TbMarcaVeiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMarcaVeiculo = await _context.TbMarcaVeiculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbMarcaVeiculo == null)
            {
                return NotFound();
            }

            return View(tbMarcaVeiculo);
        }

        // GET: TbMarcaVeiculoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbMarcaVeiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca")] TbMarcaVeiculo tbMarcaVeiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMarcaVeiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMarcaVeiculo);
        }

        // GET: TbMarcaVeiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMarcaVeiculo = await _context.TbMarcaVeiculo.FindAsync(id);
            if (tbMarcaVeiculo == null)
            {
                return NotFound();
            }
            return View(tbMarcaVeiculo);
        }

        // POST: TbMarcaVeiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca")] TbMarcaVeiculo tbMarcaVeiculo)
        {
            if (id != tbMarcaVeiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMarcaVeiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMarcaVeiculoExists(tbMarcaVeiculo.Id))
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
            return View(tbMarcaVeiculo);
        }

        // GET: TbMarcaVeiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMarcaVeiculo = await _context.TbMarcaVeiculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbMarcaVeiculo == null)
            {
                return NotFound();
            }

            return View(tbMarcaVeiculo);
        }

        // POST: TbMarcaVeiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMarcaVeiculo = await _context.TbMarcaVeiculo.FindAsync(id);
            _context.TbMarcaVeiculo.Remove(tbMarcaVeiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMarcaVeiculoExists(int id)
        {
            return _context.TbMarcaVeiculo.Any(e => e.Id == id);
        }
    }
}
