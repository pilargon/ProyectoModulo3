using System;
using System.Collections.Generic;

namespace QuetengoenmineveraAPI.Models
{
    public partial class Receta
    {
        public Receta()
        {
            IngredienteReceta = new HashSet<IngredienteReceta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Calorias { get; set; }
        public string Tiempo { get; set; }
        public string Explicacion { get; set; }
        public string Tipo { get; set; }
        public string Foto { get; set; }
        public string IngredientePrincipal { get; set; }
        public string IngredientesSecundarios { get; set; }
        public string IngredientesTerciarios { get; set; }

        public ICollection<IngredienteReceta> IngredienteReceta { get; set; }
    }
}
