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

namespace LocalizaCS.Controllers
{
    public class TbClientesController : Controller
    {
        private readonly LocalizaCSContext _context;

        public TbClientesController(LocalizaCSContext context)
        {
            _context = context;
        }

        // GET: TbClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbClientes.ToListAsync());
        }

        // GET: TbClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbClientes = await _context.TbClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbClientes == null)
            {
                return NotFound();
            }

            return View(tbClientes);
        }

        // GET: TbClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Aniversario,Cep,Logradouro,Nro,Complemento,Cidade,Estado")] TbClientes tbClientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbClientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbClientes);
        }

        // GET: TbClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbClientes = await _context.TbClientes.FindAsync(id);
            if (tbClientes == null)
            {
                return NotFound();
            }
            return View(tbClientes);
        }

        // POST: TbClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Aniversario,Cep,Logradouro,Nro,Complemento,Cidade,Estado")] TbClientes tbClientes)
        {
            if (id != tbClientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbClientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbClientesExists(tbClientes.Id))
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
            return View(tbClientes);
        }

        // GET: TbClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbClientes = await _context.TbClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbClientes == null)
            {
                return NotFound();
            }

            return View(tbClientes);
        }

        // POST: TbClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbClientes = await _context.TbClientes.FindAsync(id);
            _context.TbClientes.Remove(tbClientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbClientesExists(int id)
        {
            return _context.TbClientes.Any(e => e.Id == id);
        }
    }
}
