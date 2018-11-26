using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QueTengoEnMiNevera.Models
{
    public class IngredienteReceta
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Receta")]
        public int RecetaId { get; set; }
        [ForeignKey("Ingrediente")]
        public int IngredienteId { get; set; }
        public Receta Receta { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
