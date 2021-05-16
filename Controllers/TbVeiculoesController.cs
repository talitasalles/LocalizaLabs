using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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
            var localizaCSContext = _context.TbVeiculo.Include(t => t.Modelo);
            return View(await localizaCSContext.ToListAsync());
        }

        /*public static IEnumerable<SelectListItem> ModeloList()
        {
            LocalizaDBContext db = new LocalizaDBContext();
            List<TbModeloVeiculo> items = db.TbModeloVeiculo.OrderBy(x => x.Marca).ThenBy(x => x.Modelo).ToList();
            //return new SelectList(items, "Id", "Modelo", "TbMarcaVeiculo.Marca");
            return new SelectList(db.TbModeloVeiculo.OrderBy(x => x.Marca), "Id", "Modelo", "TbMarcaVeiculo.Marca", null);
        }

        public SelectList ModeloList()
        {

            var group1 = new SelectListGroup() { Name = "Group 1" };
            var group2 = new SelectListGroup() { Name = "Group 2" };

            var items = new List<SelectListItem>();

            items.Add(new SelectListItem() { Value = "1", Text = "Item 1", Group = group1 });
            items.Add(new SelectListItem() { Value = "2", Text = "Item 2", Group = group2 });

            return new SelectList(items, "Value", "Text");
        }*/

        // GET: TbVeiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVeiculo = await _context.TbVeiculo
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
            //ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca");
            //ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>(), "Id", "Modelo");
            ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>().Include(t => t.Marca).OrderBy(x => x.Marca), "Id", "Modelo", "Marca", "Marca.Marca");

            return View();
        }

        // POST: TbVeiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,MarcaId,ModeloId,Ano,ValorHora,Combustivel,LtPortaMala,Categoria")] TbVeiculo tbVeiculo)
        {
            tbVeiculo.Placa = tbVeiculo.Placa.ToUpper();

            if (ModelState.IsValid)
            {
                _context.Add(tbVeiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca");
            //ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>(), "Id", "Modelo");
            ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>().Include(t => t.Marca).OrderBy(x => x.Marca), "Id", "Modelo", "Marca", "Marca.Marca");
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
            //ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca");
            //ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>(), "Id", "Modelo");
            ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>().Include(t => t.Marca).OrderBy(x => x.Marca), "Id", "Modelo", "Marca", "Marca.Marca");
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

            tbVeiculo.Placa = tbVeiculo.Placa.ToUpper();

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
            //ViewData["MarcaId"] = new SelectList(_context.Set<TbMarcaVeiculo>(), "Id", "Marca");
            //ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>(), "Id", "Modelo");
            ViewData["ModeloId"] = new SelectList(_context.Set<TbModeloVeiculo>().Include(t => t.Marca).OrderBy(x => x.Marca), "Id", "Modelo", "Marca", "Marca.Marca");
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

        public IActionResult TbVeiculoPlacaExists(string placa, int id)
        {
            if (_context.TbVeiculo.Any(e => e.Placa == placa.ToUpper() && e.Id != id))
                return Json(data: "Placa já cadastrada!");

            return Json(data: true);
        }
    }
}
