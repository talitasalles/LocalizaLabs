using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocalizaCS.Data;
using LocalizaCS.Models;
using ceTe.DynamicPDF.Conversion;

namespace LocalizaCS.Views.TbLocacao
{
    public class TbLocacoesController : Controller
    {
        private readonly LocalizaCSContext _context;

        public TbLocacoesController(LocalizaCSContext context)
        {
            _context = context;
        }

        // GET: TbLocacoes
        public async Task<IActionResult> Index()
        {
            var localizaCSContext = _context.TbLocacoes.Include(t => t.Cliente).Include(t => t.Veiculo);
            return View(await localizaCSContext.ToListAsync());
        }

        // GET: TbLocacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLocacoes = await _context.TbLocacoes
                .Include(t => t.Cliente)
                .Include(t => t.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbLocacoes == null)
            {
                return NotFound();
            }

            return View(tbLocacoes);
        }

        // GET: TbLocacoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Set<TbClientes>(), "Id", "Nome");
            ViewData["VeiculoId"] = new SelectList(_context.Set<TbVeiculo>(), "Id", "Placa");

            return View();
        }

        // POST: TbLocacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,VeiculoId,Inicio,Termino")] TbLocacoes tbLocacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbLocacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<TbClientes>(), "Id", "Nome", tbLocacoes.ClienteId);
            ViewData["VeiculoId"] = new SelectList(_context.Set<TbVeiculo>(), "Id", "Placa", tbLocacoes.VeiculoId);
            return View(tbLocacoes);
        }

        // GET: TbLocacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLocacoes = await _context.TbLocacoes.FindAsync(id);
            if (tbLocacoes == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<TbClientes>(), "Id", "Nome", tbLocacoes.ClienteId);
            ViewData["VeiculoId"] = new SelectList(_context.Set<TbVeiculo>(), "Id", "Placa", tbLocacoes.VeiculoId);
            return View(tbLocacoes);
        }

        // POST: TbLocacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,VeiculoId,Inicio,Termino")] TbLocacoes tbLocacoes)
        {
            if (id != tbLocacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLocacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLocacoesExists(tbLocacoes.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Set<TbClientes>(), "Id", "Nome", tbLocacoes.ClienteId);
            ViewData["VeiculoId"] = new SelectList(_context.Set<TbVeiculo>(), "Id", "Placa", tbLocacoes.VeiculoId);
            return View(tbLocacoes);
        }

        // GET: TbLocacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLocacoes = await _context.TbLocacoes
                .Include(t => t.Cliente)
                .Include(t => t.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbLocacoes == null)
            {
                return NotFound();
            }

            return View(tbLocacoes);
        }

        // POST: TbLocacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLocacoes = await _context.TbLocacoes.FindAsync(id);
            _context.TbLocacoes.Remove(tbLocacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLocacoesExists(int id)
        {
            return _context.TbLocacoes.Any(e => e.Id == id);
        }

        public static double CalculaHoras(DateTime Inicio, DateTime Termino)
        {
            return 125.5;
        }

        public decimal GetValorHoraVeiculo (int id)
        {
            var tbVeiculos = _context.TbVeiculo.Find(id);
            return tbVeiculos.ValorHora.Value;

        }

        public IActionResult Simulacao()
        {
            ViewData["ClienteId"] = new SelectList(_context.Set<TbClientes>(), "Id", "Nome");
            ViewData["VeiculoId"] = new SelectList(_context.Set<TbVeiculo>(), "Id", "Placa");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Simulacao([Bind("Id,ClienteId,VeiculoId,Inicio,Termino")] TbLocacoes tbLocacoes)
        {
            if (ModelState.IsValid)
            {
                return Json(data: GetValorHoraVeiculo(tbLocacoes.VeiculoId));
                //_context.Add(tbLocacoes);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Set<TbClientes>(), "Id", "Nome", tbLocacoes.ClienteId);
            ViewData["VeiculoId"] = new SelectList(_context.Set<TbVeiculo>(), "Id", "Placa", tbLocacoes.VeiculoId);
            return View(tbLocacoes);
        }
        public IActionResult Simular(int id)
        {
            ViewData["ValorHora"] = GetValorHoraVeiculo(id);

            return View();
        }

        // GET: TbLocacoes/Contrato/5
        public async Task<IActionResult> Contrato(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLocacoes = await _context.TbLocacoes
                .Include(t => t.Cliente)
                .Include(t => t.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbLocacoes == null)
            {
                return NotFound();
            }

            return View(tbLocacoes);
        }

        public static void Convert(string URL)
        {
            HtmlConversionOptions options = new HtmlConversionOptions(false);
            HtmlConverter htmlConverter = new HtmlConverter(new Uri(URL), options);
            htmlConverter.Convert("converter-output.pdf");
        }

        public async Task<IActionResult> SaveDocument(int id)
        {
            HtmlConversionOptions options = new HtmlConversionOptions(false);
            options.Title = "Contrato " + id + " - LocalizaCS";
            HtmlConverter htmlConverter = new HtmlConverter(new Uri("http://localhost:8680/TbLocacoes/Contrato/" + id), options);
            htmlConverter.Convert("C:/Users/talita.salles/source/repos/LocalizaCS/wwwroot/Contratos/Contrato_" + id + ".pdf");

            return Redirect("http://localhost:8680/Contratos/Contrato_2.pdf");
        }
    }
}
