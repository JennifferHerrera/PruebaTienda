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
    public class CategoriaBLTests
    {
        private static Categoria categoriaInicial = new Categoria { IdCategoria = 3, Nombre = "Categoria Nueva" };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Nombre = "Categoria Nueva";
            int result = await new CategoriaBL().CrearAsync(categoria);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.IdCategoria = categoriaInicial.IdCategoria;
            categoria.Nombre = "Categoria Modificada";
            int result = await new CategoriaBL().ModificarAsync(categoria);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var categoria = new Categoria();
            categoria.IdCategoria = categoriaInicial.IdCategoria;
            var resultCategoria = await new CategoriaBL().ObtenerPorIdAsync(categoria);
            Assert.AreEqual(categoria.IdCategoria, resultCategoria.IdCategoria);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultCategoria = await new CategoriaBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCategoria.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Nombre = "Modificada";
            var resultCategoria = await new CategoriaBL().BuscarAsync(categoria);
            Assert.AreNotEqual(0, resultCategoria.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.IdCategoria = categoriaInicial.IdCategoria;
            int result = await new CategoriaBL().EliminarAsync(categoria);
            Assert.IsTrue(result != 0);
        }
    }
}