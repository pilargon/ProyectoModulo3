using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QueTengoEnMiNevera.Data;
using QueTengoEnMiNevera.Models;

namespace QueTengoEnMiNevera.Controllers
{
    public class IngredienteRecetasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredienteRecetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IngredienteRecetas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IngredienteReceta.Include(i => i.Ingrediente).Include(i => i.Receta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IngredienteRecetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredienteReceta = await _context.IngredienteReceta
                .Include(i => i.Ingrediente)
                .Include(i => i.Receta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredienteReceta == null)
            {
                return NotFound();
            }

            return View(ingredienteReceta);
        }

        // GET: IngredienteRecetas/Create
        public IActionResult Create()
        {
            ViewData["IngredienteId"] = new SelectList(_context.Set<Ingrediente>(), "Id", "Id");
            ViewData["RecetaId"] = new SelectList(_context.Set<Receta>(), "Id", "Id");
            return View();
        }

        // POST: IngredienteRecetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecetaId,IngredienteId")] IngredienteReceta ingredienteReceta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredienteReceta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredienteId"] = new SelectList(_context.Set<Ingrediente>(), "Id", "Id", ingredienteReceta.IngredienteId);
            ViewData["RecetaId"] = new SelectList(_context.Set<Receta>(), "Id", "Id", ingredienteReceta.RecetaId);
            return View(ingredienteReceta);
        }

        // GET: IngredienteRecetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var ingredienteReceta = await _context.IngredienteReceta.FindAsync(id);
            if (ingredienteReceta == null)
            {
                return NotFound();
            }
            ViewData["IngredienteId"] = new SelectList(_context.Set<Ingrediente>(), "Id", "Id", ingredienteReceta.IngredienteId);
            ViewData["RecetaId"] = new SelectList(_context.Set<Receta>(), "Id", "Id", ingredienteReceta.RecetaId);
            return View(ingredienteReceta);
        }

        // POST: IngredienteRecetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecetaId,IngredienteId")] IngredienteReceta ingredienteReceta)
        {
            if (id != ingredienteReceta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredienteReceta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredienteRecetaExists(ingredienteReceta.Id))
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
            ViewData["IngredienteId"] = new SelectList(_context.Set<Ingrediente>(), "Id", "Id", ingredienteReceta.IngredienteId);
            ViewData["RecetaId"] = new SelectList(_context.Set<Receta>(), "Id", "Id", ingredienteReceta.RecetaId);
            return View(ingredienteReceta);
        }

        // GET: IngredienteRecetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredienteReceta = await _context.IngredienteReceta
                .Include(i => i.Ingrediente)
                .Include(i => i.Receta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredienteReceta == null)
            {
                return NotFound();
            }

            return View(ingredienteReceta);
        }

        // POST: IngredienteRecetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredienteReceta = await _context.IngredienteReceta.FindAsync(id);
            _context.IngredienteReceta.Remove(ingredienteReceta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredienteRecetaExists(int id)
        {
            return _context.IngredienteReceta.Any(e => e.Id == id);
        }
    }
}
