using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PruebaTienda.EntidadesDeNegocio;

namespace PruebaTienda.AccesoADatos
{
    public class DetalleVentaDAL
    {
        public static async Task<int> CrearAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pDetalleVenta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var detalleventa = await bdContexto.DetalleVenta.FirstOrDefaultAsync(s => s.IdDetalleVenta == pDetalleVenta.IdDetalleVenta);
                detalleventa.IdVenta = pDetalleVenta.IdVenta;
                detalleventa.IdProducto = pDetalleVenta.IdProducto;
                detalleventa.CantidadProducto = pDetalleVenta.CantidadProducto;
                bdContexto.Update(detalleventa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var detalleventa = await bdContexto.DetalleVenta.FirstOrDefaultAsync(s => s.IdDetalleVenta == pDetalleVenta.IdDetalleVenta);
                bdContexto.DetalleVenta.Remove(detalleventa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<DetalleVenta> ObtenerPorIdAsync(DetalleVenta pDetalleVenta)
        {
            var detalleventa = new DetalleVenta();
            using (var bdContexto = new BDContexto())
            {
                detalleventa = await bdContexto.DetalleVenta.FirstOrDefaultAsync(s => s.IdDetalleVenta == pDetalleVenta.IdDetalleVenta);
            }
            return detalleventa;
        }

        public static async Task<List<DetalleVenta>> ObtenerTodosAsync()
        {
            var detalleventas = new List<DetalleVenta>();
            using (var bdContexto = new BDContexto())
            {
                detalleventas = await bdContexto.DetalleVenta.ToListAsync();
            }
            return detalleventas;
        }

        internal static IQueryable<DetalleVenta> QuerySelect(IQueryable<DetalleVenta> pQuery, DetalleVenta pDetalleVenta)
        {
            if (pDetalleVenta.IdDetalleVenta > 0)
                pQuery = pQuery.Where(s => s.IdDetalleVenta == pDetalleVenta.IdDetalleVenta);
            if (pDetalleVenta.IdVenta > 0)
                pQuery = pQuery.Where(s => s.IdVenta == pDetalleVenta.IdVenta);
            if (pDetalleVenta.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pDetalleVenta.IdProducto);
            if (pDetalleVenta.CantidadProducto > 0)
                pQuery = pQuery.Where(s => s.CantidadProducto == pDetalleVenta.CantidadProducto);
            pQuery = pQuery.OrderByDescending(s => s.IdDetalleVenta).AsQueryable();
            if (pDetalleVenta.Top_Aux > 0)
                pQuery = pQuery.Take(pDetalleVenta.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<DetalleVenta>> BuscarAsync(DetalleVenta pDetalleVenta)
        {
            var detalleventas = new List<DetalleVenta>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.DetalleVenta.AsQueryable();
                select = QuerySelect(select, pDetalleVenta);
                detalleventas = await select.ToListAsync();
            }
            return detalleventas;
        }
    }
}
