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
    public class ProductoBLTests
    {
        private static Producto productoInicial = new Producto { IdProducto = 3, Nombre = "Producto 3", Descripcion = "Descripcion 3", Precio = 20, CantidadDisponible = 20, IdCategoria = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var producto = new Producto();
            producto.Nombre = "Producto 3";
            producto.Descripcion = "Descripcion 3";
            producto.Precio = 20;
            producto.CantidadDisponible = 20;
            producto.IdCategoria = 1;
            int result = await new ProductoBL().CrearAsync(producto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var producto = new Producto();
            producto.IdProducto = productoInicial.IdProducto;
            producto.Nombre = "Producto Modificado";
            producto.Descripcion = "Descripcion Modificada";
            producto.Precio = 20;
            producto.CantidadDisponible = 20;
            producto.IdCategoria = 2;
            int result = await new ProductoBL().ModificarAsync(producto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var producto = new Producto();
            producto.IdProducto = productoInicial.IdProducto;
            var resultProducto = await new ProductoBL().ObtenerPorIdAsync(producto);
            Assert.AreEqual(producto.IdProducto, resultProducto.IdProducto);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProducto = await new ProductoBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProducto.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var producto = new Producto();
            producto.Nombre = "Modificado";
            producto.Descripcion = "Descripcion";
            producto.Precio = 20;
            producto.CantidadDisponible = 20;
            producto.IdCategoria = 2;
            var resultProducto = await new ProductoBL().BuscarAsync(producto);
            Assert.AreNotEqual(0, resultProducto.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var producto = new Producto();
            producto.IdProducto = productoInicial.IdProducto;
            int result = await new ProductoBL().EliminarAsync(producto);
            Assert.IsTrue(result != 0);
        }
    }
}