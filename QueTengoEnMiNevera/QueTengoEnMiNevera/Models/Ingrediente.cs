using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueTengoEnMiNevera.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public List<IngredienteReceta> IngredienteRecetas { get; set; }
    }
}
