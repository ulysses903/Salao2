using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salao.Models;

namespace Salao.Controllers
{
    public class ProcedimentosController : Controller
    {
        private readonly SalaoContext _context;

        public ProcedimentosController(SalaoContext context)
        {
            _context = context;
        }

        // GET: Procedimentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procedimentos.ToListAsync());
        }

        // GET: Procedimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimentos = await _context.Procedimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimentos == null)
            {
                return NotFound();
            }

            return View(procedimentos);
        }

        // GET: Procedimentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Procedimentos procedimentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedimentos);
        }

        // GET: Procedimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimentos = await _context.Procedimentos.FindAsync(id);
            if (procedimentos == null)
            {
                return NotFound();
            }
            return View(procedimentos);
        }

        // POST: Procedimentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Procedimentos procedimentos)
        {
            if (id != procedimentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentosExists(procedimentos.Id))
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
            return View(procedimentos);
        }

        // GET: Procedimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimentos = await _context.Procedimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimentos == null)
            {
                return NotFound();
            }

            return View(procedimentos);
        }

        // POST: Procedimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedimentos = await _context.Procedimentos.FindAsync(id);
            _context.Procedimentos.Remove(procedimentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentosExists(int id)
        {
            return _context.Procedimentos.Any(e => e.Id == id);
        }
    }
}
