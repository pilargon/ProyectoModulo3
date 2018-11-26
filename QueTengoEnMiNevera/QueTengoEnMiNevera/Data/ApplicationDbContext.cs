using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QueTengoEnMiNevera.Models;

namespace QueTengoEnMiNevera.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<QueTengoEnMiNevera.Models.Cliente> Cliente { get; set; }
        public DbSet<QueTengoEnMiNevera.Models.IngredienteReceta> IngredienteReceta { get; set; }
        public DbSet<QueTengoEnMiNevera.Models.Receta> Receta { get; set; }
        public DbSet<QueTengoEnMiNevera.Models.Ingrediente> Ingrediente { get; set; }
    }
}
