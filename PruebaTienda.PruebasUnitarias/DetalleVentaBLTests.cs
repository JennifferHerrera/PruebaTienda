using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaTienda.LogicaDeNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PruebaTienda.EntidadesDeNegocio;

namespace PruebaTienda.LogicaDeNegocios.Tests
{
    [TestClass()]
    public class DetalleVentaBLTests
    {
        private static DetalleVenta detalleventaInicial = new DetalleVenta { IdDetalleVenta = 3, IdVenta = 2, IdProducto = 2, CantidadProducto  = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var detalleventa = new DetalleVenta();
            detalleventa.IdVenta = 2;
            detalleventa.IdProducto = 2;
            detalleventa.CantidadProducto = 1;
            int result = await new DetalleVentaBL().CrearAsync(detalleventa);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var detalleventa = new DetalleVenta();
            detalleventa.IdDetalleVenta = detalleventaInicial.IdDetalleVenta;
            detalleventa.IdVenta = 2;
            detalleventa.IdProducto = 1;
            detalleventa.CantidadProducto = 4;
            int result = await new DetalleVentaBL().ModificarAsync(detalleventa);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var detalleventa = new DetalleVenta();
            detalleventa.IdDetalleVenta = detalleventaInicial.IdDetalleVenta;
            var resultDetalleVenta = await new DetalleVentaBL().ObtenerPorIdAsync(detalleventa);
            Assert.AreEqual(detalleventa.IdDetalleVenta, resultDetalleVenta.IdDetalleVenta);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultDetalleVenta = await new DetalleVentaBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultDetalleVenta.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var detalleventa = new DetalleVenta();
            detalleventa.IdVenta = 2;
            detalleventa.IdProducto = 1;
            detalleventa.CantidadProducto = 4;
            var resultDetalleVenta = await new DetalleVentaBL().BuscarAsync(detalleventa);
            Assert.AreNotEqual(0, resultDetalleVenta.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var detalleventa = new DetalleVenta();
            detalleventa.IdDetalleVenta = detalleventaInicial.IdDetalleVenta;
            int result = await new DetalleVentaBL().EliminarAsync(detalleventa);
            Assert.IsTrue(result != 0);
        }
    }
}