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
    public class ClienteBLTests
    {
        private static Cliente clienteInicial = new Cliente { IdCliente = 3, Nombre = "Cliente Nuevo", Direccion = "Direccion", Telefono = 77335522 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Nombre = "Cliente Nuevo";
            cliente.Direccion = "Direccion";
            cliente.Telefono = 77335522;
            int result = await new ClienteBL().CrearAsync(cliente);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.IdCliente = clienteInicial.IdCliente;
            cliente.Nombre = "Nombre Modificado";
            cliente.Direccion = "Direccion modificada";
            cliente.Telefono = 77688655;
            int result = await new ClienteBL().ModificarAsync(cliente);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var cliente = new Cliente();
            cliente.IdCliente = clienteInicial.IdCliente;
            var resultCliente = await new ClienteBL().ObtenerPorIdAsync(cliente);
            Assert.AreEqual(cliente.IdCliente, resultCliente.IdCliente);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultCliente = await new ClienteBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCliente.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Nombre = "Nombre Modificado";
            cliente.Direccion = "Direccion Modificada";
            cliente.Telefono = 77688655;
            var resultCliente = await new ClienteBL().BuscarAsync(cliente);
            Assert.AreNotEqual(0, resultCliente.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.IdCliente = clienteInicial.IdCliente;
            int result = await new ClienteBL().EliminarAsync(cliente);
            Assert.IsTrue(result != 0);
        }
    }
}