using System;
using System.Collections.Generic;

namespace QuetengoenmineveraAPI.Models
{
    public partial class IngredienteReceta
    {
        public int Id { get; set; }
        public int RecetaId { get; set; }
        public int IngredienteId { get; set; }

        public Ingrediente Ingrediente { get; set; }
        public Receta Receta { get; set; }
    }
}
