using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRABALHOFINALDOPI.Data;
using TRABALHOFINALDOPI.Models;

namespace TRABALHOFINALDOPI.Controllers
{
    public class DoarOuRecebersController : Controller
    {


        private readonly TRABALHOFINALDOPIContext _context;

        public DoarOuRecebersController(TRABALHOFINALDOPIContext context)
        {
            _context = context;
        }

        // GET: DoarOuRecebers
        public async Task<IActionResult> Index()
        {
            var tRABALHOFINALDOPIContext = _context.DoarOuReceber.Include(d => d.Nome_Item).Include(d => d.Nome_Ong);
            return View(await tRABALHOFINALDOPIContext.ToListAsync());
        }

        // GET: DoarOuRecebers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DoarOuReceber == null)
            {
                return NotFound();
            }

            var doarOuReceber = await _context.DoarOuReceber
                .Include(d => d.Nome_Item)
                .Include(d => d.Nome_Ong)
                .FirstOrDefaultAsync(m => m.DoarOuReceberId == id);
            if (doarOuReceber == null)
            {
                return NotFound();
            }

            return View(doarOuReceber);
        }

        // GET: DoarOuRecebers/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedido>(), "PedidoId", "Nome_Item");
            ViewData["OngId"] = new SelectList(_context.Set<Ong>(), "OngId", "Nome_Ong");
            return View();
        }

        // POST: DoarOuRecebers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoarOuReceberId,Nome,Sobrenome,Email,Celular,QuerDoar,QuerReceber,DataPedido,PedidoId,OngId")] DoarOuReceber doarOuReceber)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(doarOuReceber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedido>(), "PedidoId", "Nome_Item", doarOuReceber.PedidoId);
            ViewData["OngId"] = new SelectList(_context.Set<Ong>(), "OngId", "Nome_Ong", doarOuReceber.OngId);
            return View(doarOuReceber);
        }

        // GET: DoarOuRecebers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DoarOuReceber == null)
            {
                return NotFound();
            }

            var doarOuReceber = await _context.DoarOuReceber.FindAsync(id);
            if (doarOuReceber == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedido>(), "PedidoId", "Nome_Item", doarOuReceber.PedidoId);
            ViewData["OngId"] = new SelectList(_context.Set<Ong>(), "OngId", "Nome_Ong", doarOuReceber.OngId);
            return View(doarOuReceber);
        }

        // POST: DoarOuRecebers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoarOuReceberId,Nome,Sobrenome,Email,Celular,QuerDoar,QuerReceber,DataPedido,PedidoId,OngId")] DoarOuReceber doarOuReceber)
        {
            if (id != doarOuReceber.DoarOuReceberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doarOuReceber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoarOuReceberExists(doarOuReceber.DoarOuReceberId))
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
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedido>(), "PedidoId", "Nome_Item", doarOuReceber.PedidoId);
            ViewData["OngId"] = new SelectList(_context.Set<Ong>(), "OngId", "Nome_Ong", doarOuReceber.OngId);
            return View(doarOuReceber);
        }

        // GET: DoarOuRecebers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DoarOuReceber == null)
            {
                return NotFound();
            }

            var doarOuReceber = await _context.DoarOuReceber
                .Include(d => d.Nome_Item)
                .Include(d => d.Nome_Ong)
                .FirstOrDefaultAsync(m => m.DoarOuReceberId == id);
            if (doarOuReceber == null)
            {
                return NotFound();
            }

            return View(doarOuReceber);
        }

        // POST: DoarOuRecebers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DoarOuReceber == null)
            {
                return Problem("Entity set 'TRABALHOFINALDOPIContext.DoarOuReceber'  is null.");
            }
            var doarOuReceber = await _context.DoarOuReceber.FindAsync(id);
            if (doarOuReceber != null)
            {
                _context.DoarOuReceber.Remove(doarOuReceber);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoarOuReceberExists(int id)
        {
          return (_context.DoarOuReceber?.Any(e => e.DoarOuReceberId == id)).GetValueOrDefault();
        }
    }
}
