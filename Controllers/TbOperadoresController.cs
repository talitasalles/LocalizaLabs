using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocalizaCS.Data;
using LocalizaCS.Models;

namespace LocalizaCS.Views.TbOperador
{
    public class TbOperadoresController : Controller
    {
        private readonly LocalizaCSContext _context;

        public TbOperadoresController(LocalizaCSContext context)
        {
            _context = context;
        }

        // GET: TbOperadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbOperadores.ToListAsync());
        }

        // GET: TbOperadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbOperadores = await _context.TbOperadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbOperadores == null)
            {
                return NotFound();
            }

            return View(tbOperadores);
        }

        // GET: TbOperadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbOperadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Matricula")] TbOperadores tbOperadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbOperadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbOperadores);
        }

        // GET: TbOperadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbOperadores = await _context.TbOperadores.FindAsync(id);
            if (tbOperadores == null)
            {
                return NotFound();
            }
            return View(tbOperadores);
        }

        // POST: TbOperadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Matricula")] TbOperadores tbOperadores)
        {
            if (id != tbOperadores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbOperadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbOperadoresExists(tbOperadores.Id))
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
            return View(tbOperadores);
        }

        // GET: TbOperadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbOperadores = await _context.TbOperadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbOperadores == null)
            {
                return NotFound();
            }

            return View(tbOperadores);
        }

        // POST: TbOperadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbOperadores = await _context.TbOperadores.FindAsync(id);
            _context.TbOperadores.Remove(tbOperadores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbOperadoresExists(int id)
        {
            return _context.TbOperadores.Any(e => e.Id == id);
        }
    }
}
