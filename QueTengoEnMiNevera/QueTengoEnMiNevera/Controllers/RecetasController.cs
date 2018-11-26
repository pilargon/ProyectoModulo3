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
    public class RecetasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Receta.ToListAsync());
        }

        public IActionResult About([FromQuery] string[] ingredientes)
        {
            List<string> listaIngredientes = ingredientes.ToList();

            // hacer lo que sea con la lista
            // la pasarias por url del siguiente modo:
            // https://localhost:44341/NombreControlador/NombreAccion/?ingredientes=sal&ingredientes=azucar
            // te faltaria todavia de javascript pasarlo, 
            // pero de momento con eso puedes ir probando metiendo la direccion a mano
            // me dices si te sirve vale?
            return View(listaIngredientes);

        }
        public async Task<IActionResult> Buscar([FromQuery]string ingrediente)//FALTA PONER []PERO LO EH QUITADO PARA QUE NO ESTE EN ROJO
        {
            //List<string> ingredienteDisponibles = new List<string>();
            //Request.Q
            //foreach (string key in Request.Query)
            //{
            //    var value = Request.QueryString[key] ;
            //}
            List<Receta> resultados = new List<Receta>();
            List<Receta> todasLasRecetas = await _context.Receta.ToListAsync();
            foreach (Receta receta in todasLasRecetas)
            {    //si tiene el principal que salga y al menos el 50% de los ingredientes.
                 //los ingredientes terciarios no influyen en el porcentaje.
                if (receta.IngredientePrincipal.ToUpper().Contains(ingrediente.ToUpper())
                    || receta.IngredientesSecundarios.ToUpper().Contains(ingrediente.ToUpper())
                    || receta.IngredientesTerciarios.ToUpper().Contains(ingrediente.ToUpper()))
                {
                    resultados.Add(receta);
                }

                //else if (receta.IngredientePrincipal.ToUpper().Contains(ingrediente.ToUpper())
                //    || receta.IngredientesSecundarios.ToUpper().Contains(ingrediente.ToUpper())
                //    || receta.IngredientesTerciarios.ToUpper().Contains(ingrediente.ToUpper()))
                //{
                //    resultados.Add(receta);
                //}
            }
            return View(resultados);
        }

        // GET: Recetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // GET: Recetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Calorias,Tiempo,Explicacion,Tipo,Foto,IngredientePrincipal,IngredientesSecundarios,IngredientesTerciarios")] Receta receta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receta);
        }

        // GET: Recetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }
            return View(receta);
        }

        // POST: Recetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Calorias,Tiempo,Explicacion,Tipo,Foto,IngredientePrincipal,IngredientesSecundarios,IngredientesTerciarios")] Receta receta)
        {
            if (id != receta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecetaExists(receta.Id))
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
            return View(receta);
        }

        // GET: Recetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // POST: Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receta = await _context.Receta.FindAsync(id);
            _context.Receta.Remove(receta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecetaExists(int id)
        {
            return _context.Receta.Any(e => e.Id == id);
        }
    }
}
