using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PruebaTienda.EntidadesDeNegocio;

namespace PruebaTienda.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuiler)
        {
            optionBuiler.UseSqlServer(@"Data Source=JENNI;Initial Catalog=DBTienda;Integrated Security=True");
        }
    }
}
