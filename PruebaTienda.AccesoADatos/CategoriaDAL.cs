using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PruebaTienda.EntidadesDeNegocio;

namespace PruebaTienda.AccesoADatos
{
    public class CategoriaDAL
    {
        public static async Task<int> CrearAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCategoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categoria = await bdContexto.Categoria.FirstOrDefaultAsync(s => s.IdCategoria == pCategoria.IdCategoria);
                categoria.Nombre = pCategoria.Nombre;
                bdContexto.Update(categoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categoria = await bdContexto.Categoria.FirstOrDefaultAsync(s => s.IdCategoria == pCategoria.IdCategoria);
                bdContexto.Categoria.Remove(categoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Categoria> ObtenerPorIdAsync(Categoria pCategoria)
        {
            var categoria = new Categoria();
            using (var bdContexto = new BDContexto())
            {
                categoria = await bdContexto.Categoria.FirstOrDefaultAsync(s => s.IdCategoria == pCategoria.IdCategoria);
            }
            return categoria;
        }

        public static async Task<List<Categoria>> ObtenerTodosAsync()
        {
            var categorias = new List<Categoria>();
            using (var bdContexto = new BDContexto())
            {
                categorias = await bdContexto.Categoria.ToListAsync();
            }
            return categorias;
        }

        internal static IQueryable<Categoria> QuerySelect(IQueryable<Categoria> pQuery, Categoria pCategoria)
        {
            if (pCategoria.IdCategoria > 0)
                pQuery = pQuery.Where(s => s.IdCategoria == pCategoria.IdCategoria);
            if (!string.IsNullOrWhiteSpace(pCategoria.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pCategoria.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.IdCategoria).AsQueryable();
            if (pCategoria.Top_Aux > 0)
                pQuery = pQuery.Take(pCategoria.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            var categorias = new List<Categoria>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Categoria.AsQueryable();
                select = QuerySelect(select, pCategoria);
                categorias = await select.ToListAsync();
            }
            return categorias;

        }
    }
}
