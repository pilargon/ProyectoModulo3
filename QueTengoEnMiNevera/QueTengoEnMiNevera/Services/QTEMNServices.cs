using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueTengoEnMiNevera.Data;
using QueTengoEnMiNevera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueTengoEnMiNevera.Services
{
    public class QTEMNServices
    {
        private readonly ApplicationDbContext _context;

        //METODO PARA QUE VAYA AL DBCONTEXT
        public QTEMNServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Receta> GetRecetasDB()
        {
            List<Receta> recetas = _context.Receta.ToList();
            return recetas;
        }

        public List<Ingrediente> GetIngredientesDB()
        {
            List<Ingrediente> ingredientes = _context.Ingrediente.ToList();
            return ingredientes;
        }


        public async Task<List<Receta>> BuscarRecetasPorIngredientes(string[] ingredientes)
        {
            List<string> listaIngredientes = ingredientes.ToList();

            // hacer lo que sea con la lista
            // la pasarias por url del siguiente modo:
            // https://localhost:44341/NombreControlador/NombreAccion/?ingredientes=sal&ingredientes=azucar
            // te faltaria todavia de javascript pasarlo, 
            // pero de momento con eso puedes ir probando metiendo la direccion a mano
            // me dices si te sirve vale?
            //listaIngredientes.Add(ingredientes[i]);

            List<Receta> resultados = new List<Receta>();
            List<Receta> todasLasRecetas = await _context.Receta.ToListAsync();

            int ingredientesEnReceta = 0;
            foreach (Receta receta in todasLasRecetas)
            {
                ingredientesEnReceta = 0;
                foreach (string ingrediente in listaIngredientes)
                {
                   //este for tiene funcion de contador de ingredientes que coinciden entre cada receta y 
                   //los ingredientes introducidos por el usuario.
                    for (int i = 0; i < listaIngredientes.Count(); i++)
                    {

                        if (receta.IngredientePrincipal.ToUpper().Contains(ingrediente.ToUpper())
                        || receta.IngredientesSecundarios.ToUpper().Contains(ingrediente.ToUpper())
                        || receta.IngredientesTerciarios.ToUpper().Contains(ingrediente.ToUpper()))
                        {

                            ingredientesEnReceta++;
                        }
                    }
                }
                int ingredientesTotalesReceta = 2; //TODO: contar comas y sumar 1
                //TODO:NO INCLUIR EN LA SUMA TOTAL A LOS TERCIARIOS
                int contadorPrincipal = 0;
                foreach (string ingrediente in listaIngredientes)
                {
                    if (receta.IngredientePrincipal.ToUpper().Contains(ingrediente.ToUpper()) && ingredientesEnReceta >= ingredientesTotalesReceta / 2)
                    {//TODO:TIENE QUE INCLUIR A TOOOOODOS LOS PRINCIPALES

                        contadorPrincipal++;

                        if (contadorPrincipal == 2/*receta.IngredientePrincipal.Length*/)
                            //TODO:ANTES DE QUE ESTO FUNCIONE,TENGO QUE SEPARAR CADA ELEMENTO DE LOS INGREDIENTES
                            //PORQUE EN VEZ DE SUMARME ELEMENTOS DE LA LISTA,ME SUMA CARACTERES.(LINEA 70).
                        {
                            resultados.Add(receta);
                        }
                    }
                }
            }

            return resultados;
        }

    }
}
