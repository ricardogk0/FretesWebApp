using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FretesWebApplication.Data;
using FretesWebApplication.Models;
using System.Globalization;

namespace FretesWebApplication.Controllers
{
    public class FretesController : Controller
    {
        private readonly FretesWebApplicationContext _context;

        public FretesController(FretesWebApplicationContext context)
        {
            _context = context;
        }

        // GET: Fretes
        public async Task<IActionResult> Index()
        {
            var fretesWebApplicationContext = _context.Frete.Include(f => f.Produto).Include(f => f.Veiculo);
            return View(await fretesWebApplicationContext.ToListAsync());
        }

        // GET: Fretes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Frete == null)
            {
                return NotFound();
            }

            var frete = await _context.Frete
                .Include(f => f.Produto)
                .Include(f => f.Veiculo)
                .FirstOrDefaultAsync(m => m.IdFrete == id);
            if (frete == null)
            {
                return NotFound();
            }

            return View(frete);
        }

        // GET: Fretes/Create
        public IActionResult Create()
        {
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "Denominacao");
            ViewData["IdVeiculo"] = new SelectList(_context.Veiculo, "IdVeiculo", "Denominacao");

            return View();
        }

        // POST: Fretes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("IdFrete,Distancia,IdVeiculo,IdProduto,Taxa,ValorTotal")] Frete frete)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(frete);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }

            foreach (var key in ModelState.Keys)
            {
                var errors = ModelState[key].Errors;
                foreach (var error in errors)
                {
                    Console.WriteLine($"Erro na propriedade '{key}': {error.ErrorMessage}");
                }
            }

             ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "PesoProduto", frete.IdProduto);
             ViewData["IdVeiculo"] = new SelectList(_context.Veiculo, "IdVeiculo", "PesoVeiculo", frete.IdVeiculo);
             return View(frete);
         }

        // GET: Fretes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Frete == null)
            {
                return NotFound();
            }

            var frete = await _context.Frete.FindAsync(id);
            if (frete == null)
            {
                return NotFound();
            }
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "Denominacao", frete.IdProduto);
            ViewData["IdVeiculo"] = new SelectList(_context.Veiculo, "IdVeiculo", "Denominacao", frete.IdVeiculo);
            return View(frete);
        }

        // POST: Fretes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFrete,Distancia,IdVeiculo,IdProduto,Taxa,ValorTotal")] Frete frete)
        {
            if (id != frete.IdFrete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreteExists(frete.IdFrete))
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
            ViewData["IdProduto"] = new SelectList(_context.Produto, "IdProduto", "IdProduto", frete.IdProduto);
            ViewData["IdVeiculo"] = new SelectList(_context.Veiculo, "IdVeiculo", "IdVeiculo", frete.IdVeiculo);
            return View(frete);
        }

        // GET: Fretes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Frete == null)
            {
                return NotFound();
            }

            var frete = await _context.Frete
                .Include(f => f.Produto)
                .Include(f => f.Veiculo)
                .FirstOrDefaultAsync(m => m.IdFrete == id);
            if (frete == null)
            {
                return NotFound();
            }

            return View(frete);
        }

        // POST: Fretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Frete == null)
            {
                return Problem("Entity set 'FretesWebApplicationContext.Frete'  is null.");
            }
            var frete = await _context.Frete.FindAsync(id);
            if (frete != null)
            {
                _context.Frete.Remove(frete);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BuscarPesoVeiculo(int veiculo)
        {
            var VeiculoEncontrado = _context.Veiculo.FirstOrDefault(i => i.IdVeiculo == veiculo);

            if (VeiculoEncontrado != null)
            {
                var response = new
                {
                    peso = VeiculoEncontrado.PesoVeiculo
                };

                return Json(response);
            }

            return NotFound();
        }

        public IActionResult BuscarPesoProduto(int produto)
        {
            var ProdutoEncontrado = _context.Produto.FirstOrDefault(p => p.IdProduto == produto);

            if (ProdutoEncontrado != null)
            {
                var response = new
                {
                    peso = ProdutoEncontrado.PesoProduto
                };

                return Json(response);
            }

            return NotFound();
        }

        private bool FreteExists(int id)
        {
            return (_context.Frete?.Any(e => e.IdFrete == id)).GetValueOrDefault();
        }
    }
}
