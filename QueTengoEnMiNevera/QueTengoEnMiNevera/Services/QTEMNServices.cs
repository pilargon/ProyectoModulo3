using Microsoft.EntityFrameworkCore;
using QueTengoEnMiNevera.Data;
using QueTengoEnMiNevera.Models;
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


        public async Task<List<Receta>> BuscarRecetasPorIngredientes(string[] ingredientes, string[] filtros)
        {
            List<string> listaIngredientes = ingredientes.ToList();
            List<string> listaFiltros = filtros.ToList();

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

                //AQUI CONTAMOS TODOS LOS INGREDIENTES DE LA RECETA PERO NO INCLUIMOS LOS TERCIARIOS
                string cadenaTotal = receta.IngredientePrincipal + receta.IngredientesSecundarios;
                string[] separadasTotal;
                separadasTotal = cadenaTotal.Split(',');
                int numeroIngredientesTotalesReceta = separadasTotal.Count() + 1;//AQUI TENEMOS QUE SUMAR UNO 
                //PORQUE ENTRE EL PRINCIPAL Y EL SECUNDARIO NO HAY COMA


                //FILTRO
                int contadorPrincipal = 0;
                foreach (string ingrediente in listaIngredientes)
                {
                    if (receta.IngredientePrincipal.ToUpper().Contains(ingrediente.ToUpper()) && ingredientesEnReceta >= numeroIngredientesTotalesReceta / 2)
                    {
                        contadorPrincipal++;

                        //AQUI LO QUE HACEMOS ES SEPARAR LOS INGREDIENTES DE LA CADENA LOCALIZANDO LAS COMAS.
                        string cadenaPral = receta.IngredientePrincipal;
                        string[] separadasPral;
                        separadasPral = cadenaPral.Split(',');

                        //SOLAMENTE SI ESTAN TODOS LOS INGREDIENTES PRINCIPALES PASA
                        int numeroIngredientesPrincipales = separadasPral.Count();
                        if (contadorPrincipal == numeroIngredientesPrincipales)

                        {
                            resultados.Add(receta);
                        }
                    }

                }
            }


            List<Receta> resultadosFiltros = new List<Receta>();

            foreach (Receta recetaFiltrada in resultados)
            {
               
                foreach (string filtro in listaFiltros)
                {
                    if (recetaFiltrada.Calorias.ToUpper().Contains(filtro.ToUpper()))
                    {
                        resultadosFiltros.Add(recetaFiltrada);
                    }
                    else if (recetaFiltrada.Tiempo.ToUpper().Contains(filtro.ToUpper()))
                    { 
                        resultadosFiltros.Add(recetaFiltrada);
                    }
                    else if (recetaFiltrada.Tipo.ToUpper().Contains(filtro.ToUpper()))
                    {
                        resultadosFiltros.Add(recetaFiltrada);
                       
                    }
                }
               
                if (listaFiltros.Count==0)
                {
                    resultadosFiltros.Add(recetaFiltrada);
                }

            }
            return resultadosFiltros;


        }

        ////Haciendo pruebas
        //public async Task<List<Receta>> BuscarRecetasPorFiltros(string[] filtros)
        //{
        //    List<string> listaFiltros = filtros.ToList();

        //    // https://localhost:44341/NombreControlador/NombreAccion/?ingredientes=sal&ingredientes=azucar

        //    List<Receta> resultadosFiltros = new List<Receta>();
        //    List<Receta> todasLasRecetas = await _context.Receta.ToListAsync();

        //    foreach (Receta receta in todasLasRecetas)
        //    {
        //        foreach (string filtro in listaFiltros)
        //        {
        //            //for (int i = 0; i < listaFiltros.Count(); i++)
        //            //{
        //                if (receta.Calorias.ToUpper().Contains(filtro.ToUpper()))
        //                {
        //                    resultadosFiltros.Add(receta);
        //                }
        //                else if (receta.Tiempo.Equals(filtro))
        //                {
        //                    resultadosFiltros.Add(receta);
        //                }
        //                else if (receta.Tipo.ToUpper().Contains(filtro.ToUpper()))
        //                {
        //                    resultadosFiltros.Add(receta);
        //                }
        //            //}
        //        }

        //    }
        //    return resultadosFiltros;
        //}
    }
}