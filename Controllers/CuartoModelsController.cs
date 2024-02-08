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
    public class CuartoModelsController : Controller
    {
        private readonly ConexionSQLServer _context;

        public CuartoModelsController(ConexionSQLServer context)
        {
            _context = context;
        }

        // GET: CuartoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuarto.ToListAsync());
        }

        // GET: CuartoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuartoModel = await _context.Cuarto
                .FirstOrDefaultAsync(m => m.IdCuarto == id);
            if (cuartoModel == null)
            {
                return NotFound();
            }

            return View(cuartoModel);
        }

        // GET: CuartoModels/Create
        //public async IActionResult Create()
        public async Task<ActionResult> Create()
        {
            ViewBag.TipoCuarto = await _context.TipoCuarto.ToListAsync();

            return View();
        }

        // POST: CuartoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCuarto,IdCasa,IdTipoCuarto,Color,WcPropio,Medida")] CuartoModel cuartoModel)
        {
            
           // if (ModelState.IsValid)
           // {
                _context.Add(cuartoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           // }
           // return View(cuartoModel);
        }

        // GET: CuartoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuartoModel = await _context.Cuarto.FindAsync(id);
            if (cuartoModel == null)
            {
                return NotFound();
            }
            ViewBag.TipoCuarto = await _context.TipoCuarto.ToListAsync();
            return View(cuartoModel);
        }

        // POST: CuartoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCuarto,IdCasa,IdTipoCuarto,Color,BañoPropio,Medida")] CuartoModel cuartoModel)
        {
            if (id != cuartoModel.IdCuarto)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(cuartoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuartoModelExists(cuartoModel.IdCuarto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
           //return View(cuartoModel);
        }

        // GET: CuartoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuartoModel = await _context.Cuarto
                .FirstOrDefaultAsync(m => m.IdCuarto == id);
            if (cuartoModel == null)
            {
                return NotFound();
            }

            return View(cuartoModel);
        }

        // POST: CuartoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuartoModel = await _context.Cuarto.FindAsync(id);
            if (cuartoModel != null)
            {
                _context.Cuarto.Remove(cuartoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuartoModelExists(int id)
        {
            return _context.Cuarto.Any(e => e.IdCuarto == id);
        }

    }
}
