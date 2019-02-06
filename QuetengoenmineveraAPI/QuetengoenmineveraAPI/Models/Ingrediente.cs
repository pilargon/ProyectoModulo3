using System;
using System.Collections.Generic;

namespace QuetengoenmineveraAPI.Models
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            IngredienteReceta = new HashSet<IngredienteReceta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }

        public ICollection<IngredienteReceta> IngredienteReceta { get; set; }
    }
}
