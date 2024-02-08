using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClaseCasa.Models;
using ClaseCasa2.Context;

namespace ClaseCasa2.Controllers
{
    public class TipoCuartoModelsController : Controller
    {
        private readonly ConexionSQLServer _context;

        public TipoCuartoModelsController(ConexionSQLServer context)
        {
            _context = context;
        }

        // GET: TipoCuartoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoCuarto.ToListAsync());
        }

        // GET: TipoCuartoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCuartoModel = await _context.TipoCuarto
                .FirstOrDefaultAsync(m => m.IdTipoCuarto == id);
            if (tipoCuartoModel == null)
            {
                return NotFound();
            }

            return View(tipoCuartoModel);
        }

        // GET: TipoCuartoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCuartoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCuarto,Descripcion")] TipoCuartoModel tipoCuartoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoCuartoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCuartoModel);
        }

        // GET: TipoCuartoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCuartoModel = await _context.TipoCuarto.FindAsync(id);
            if (tipoCuartoModel == null)
            {
                return NotFound();
            }
            return View(tipoCuartoModel);
        }

        // POST: TipoCuartoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCuarto,Descripcion")] TipoCuartoModel tipoCuartoModel)
        {
            if (id != tipoCuartoModel.IdTipoCuarto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCuartoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCuartoModelExists(tipoCuartoModel.IdTipoCuarto))
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
            return View(tipoCuartoModel);
        }

        // GET: TipoCuartoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCuartoModel = await _context.TipoCuarto
                .FirstOrDefaultAsync(m => m.IdTipoCuarto == id);
            if (tipoCuartoModel == null)
            {
                return NotFound();
            }

            return View(tipoCuartoModel);
        }

        // POST: TipoCuartoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoCuartoModel = await _context.TipoCuarto.FindAsync(id);
            if (tipoCuartoModel != null)
            {
                _context.TipoCuarto.Remove(tipoCuartoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCuartoModelExists(int id)
        {
            return _context.TipoCuarto.Any(e => e.IdTipoCuarto == id);
        }
    }
}
