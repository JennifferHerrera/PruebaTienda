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
    public class RolBLTests
    {
        private static Rol rolInicial = new Rol { IdRol = 3, Nombre = "Rol Ejemplo" };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "Rol Ejemplo";
            int result = await new RolBL().CrearAsync(rol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var rol = new Rol();
            rol.IdRol = rolInicial.IdRol;
            rol.Nombre = "Rol Modificado";
            int result = await new RolBL().ModificarAsync(rol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var rol = new Rol();
            rol.IdRol = rolInicial.IdRol;
            var resultRol = await new RolBL().ObtenerPorIdAsync(rol);
            Assert.AreEqual(rol.IdRol, resultRol.IdRol);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultRol = await new RolBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultRol.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "Ejemplo";
            var resultRol = await new RolBL().BuscarAsync(rol);
            Assert.AreNotEqual(0, resultRol.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var rol = new Rol();
            rol.IdRol = rolInicial.IdRol;
            int result = await new RolBL().EliminarAsync(rol);
            Assert.IsTrue(result != 0);
        }
    }
}