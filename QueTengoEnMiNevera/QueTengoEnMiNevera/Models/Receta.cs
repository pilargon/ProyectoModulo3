using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueTengoEnMiNevera.Models
{
    public class Receta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Calorias { get; set; }
        public string Tiempo { get; set; } // TODO: pasar de ints de minutos a un TimeSpan
        public string Explicacion { get; set; }
        public string Tipo { get; set; }
        public string Foto { get; set; }
        public string IngredientePrincipal { get; set; }
        public string IngredientesSecundarios { get; set; }
        public string IngredientesTerciarios { get; set; }  //la idea es que no computen en el porcentaje,como sal etc.
        public List<IngredienteReceta>IngredienteRecetas { get; set; }
    }
}
