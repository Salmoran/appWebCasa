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
    public class CasaModelsController : Controller
    {
        private readonly ConexionSQLServer _context;

        public CasaModelsController(ConexionSQLServer context)
        {
            _context = context;
        }

        // GET: CasaModels
        public async Task<IActionResult> Index()
        {

            var casa = await _context.Casa
            .Include(p => p.Cuartos)
            .ToListAsync();
            //return View(await _context.Casa.ToListAsync());
            return View(casa);
        }

        // GET: CasaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaModel = await _context.Casa
                .Include(cs => cs.Cuartos)
                    //.ThenInclude(t => t.TipoCuarto)
                .FirstOrDefaultAsync(c => c.IdCasa == id);
            if (casaModel == null)
            {
                return NotFound();
            }

            return View(casaModel);
        }

        // GET: CasaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCasa,NodeRejas,TieneJardin,TienePorche,TienePiscina,Color")] CasaModel casaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casaModel);
        }

        // GET: CasaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaModel = await _context.Casa.FindAsync(id);
            if (casaModel == null)
            {
                return NotFound();
            }
            return View(casaModel);
        }

        // POST: CasaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCasa,NodeRejas,TieneJardin,TienePorche,TienePiscina,Color")] CasaModel casaModel)
        {
            if (id != casaModel.IdCasa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaModelExists(casaModel.IdCasa))
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
            return View(casaModel);
        }

        // GET: CasaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casaModel = await _context.Casa
                .FirstOrDefaultAsync(m => m.IdCasa == id);
            if (casaModel == null)
            {
                return NotFound();
            }

            return View(casaModel);
        }

        // POST: CasaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casaModel = await _context.Casa.FindAsync(id);
            if (casaModel != null)
            {
                _context.Casa.Remove(casaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: CasaModels
        public async Task<IActionResult> Cuartos(int id)
        {
            var cuartos = await _context.Casa
            .Include(p => p.Cuartos)
            .FirstOrDefaultAsync(p => p.IdCasa == id);

            return View(cuartos);
        }

        // GET: CuartoModels/CreateCuarto
        public async Task<IActionResult> CreateCuarto(int id)
        {
            ViewData["idCasa"] = id;
            ViewBag.TipoCuarto = await _context.TipoCuarto.ToListAsync();
            return View();
        }
        // POST: CuartoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCuarto([Bind("IdCuarto,IdCasa,IdTipoCuarto,Color,WcPropio,Medida")] CuartoModel cuartoModel)
        {
            // if (ModelState.IsValid)
            // {
            _context.Add(cuartoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Cuartos), new { id = cuartoModel.IdCasa });

            // }
            // return View(cuartoModel);
        }

        // GET: CasaModels/EditCuarto/5
        public async Task<IActionResult> EditCuarto(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCuarto(int id, [Bind("IdCuarto,IdCasa,IdTipoCuarto,Color,BañoPropio,Medida")] CuartoModel cuartoModel)
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
                throw;
            }
            //return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Cuartos), new { id = cuartoModel.IdCasa });
            //}
            //return View(cuartoModel);
        }

        // GET: CuartoModels/Delete/5
        public async Task<IActionResult> DeleteCuarto(int? id)
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

        // POST: CuartoModels/DeleteCuarto/5
        [HttpPost, ActionName("DeleteCuarto")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCuartoConfirmed(int id)
        {
            var cuartoModel = await _context.Cuarto.FindAsync(id);
            if (cuartoModel != null)
            {
                _context.Cuarto.Remove(cuartoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Cuartos), new { id = cuartoModel.IdCasa });
        }

        private bool CasaModelExists(int id)
        {
            return _context.Casa.Any(e => e.IdCasa == id);
        }
    }
}
