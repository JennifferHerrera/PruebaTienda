using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PruebaTienda.EntidadesDeNegocio;

namespace PruebaTienda.AccesoADatos
{
    public class ProductoDAL
    {
        public static async Task<int> CrearAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pProducto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var producto = await bdContexto.Producto.FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);
                producto.Nombre = pProducto.Nombre;
                producto.Descripcion = pProducto.Descripcion;
                producto.Precio = pProducto.Precio;
                producto.CantidadDisponible = pProducto.CantidadDisponible;
                producto.IdCategoria = pProducto.IdCategoria;
                bdContexto.Update(producto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var producto = await bdContexto.Producto.FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);
                bdContexto.Producto.Remove(producto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            var producto = new Producto();
            using (var bdContexto = new BDContexto())
            {
                producto = await bdContexto.Producto.FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);
            }
            return producto;
        }

        public static async Task<List<Producto>> ObtenerTodosAsync()
        {
            var productos = new List<Producto>();
            using (var bdContexto = new BDContexto())
            {
                productos = await bdContexto.Producto.ToListAsync();
            }
            return productos;
        }

        internal static IQueryable<Producto> QuerySelect(IQueryable<Producto> pQuery, Producto pProducto)
        {
            if (pProducto.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pProducto.IdProducto);
            if (!string.IsNullOrWhiteSpace(pProducto.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pProducto.Nombre));
            if (!string.IsNullOrWhiteSpace(pProducto.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pProducto.Descripcion));
            if (pProducto.Precio > 0)
                pQuery = pQuery.Where(s => s.Precio == pProducto.Precio);
            if (pProducto.CantidadDisponible > 0)
                pQuery = pQuery.Where(s => s.CantidadDisponible == pProducto.CantidadDisponible);
            if (pProducto.IdCategoria > 0)
                pQuery = pQuery.Where(s => s.IdCategoria == pProducto.IdCategoria);
            pQuery = pQuery.OrderByDescending(s => s.IdProducto).AsQueryable();
            if (pProducto.Top_Aux > 0)
                pQuery = pQuery.Take(pProducto.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Producto>> BuscarAsync(Producto pProducto)
        {
            var productos = new List<Producto>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Producto.AsQueryable();
                select = QuerySelect(select, pProducto);
                productos = await select.ToListAsync();
            }
            return productos;
        }
    }
}
