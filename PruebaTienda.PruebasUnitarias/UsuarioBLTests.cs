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
    public class UsuarioBLTests
    {
        private static Usuario usuarioInicial = new Usuario { IdUsuario = 3, IdRol = 2, Nombre = "Nombre", Apellido = "Apellido", Login = "Usuario123@gmail.com", Password = "123456" };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = 2;
            usuario.Nombre = "Nombre";
            usuario.Apellido = "Apellido";
            usuario.Login = "Usuario123@gmail.com";
            string passw = "123456";
            usuario.Password = passw;
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            int result = await new UsuarioBL().CrearAsync(usuario);
            Assert.AreNotEqual(0, result);

        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdUsuario = usuarioInicial.IdUsuario;
            usuario.IdRol = 1;
            usuario.Nombre = "Nombre Modificado";
            usuario.Apellido = "Apellido Modificado";
            usuario.Login = "AdminM123@gmail.com";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            int result = await new UsuarioBL().ModificarAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Login = usuario.Login;
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdUsuario = usuarioInicial.IdUsuario;
            var resultUsuario = await new UsuarioBL().ObtenerPorIdAsync(usuario);
            Assert.AreEqual(usuario.IdUsuario, resultUsuario.IdUsuario);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultUsuario = await new UsuarioBL().ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultUsuario.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = 1;
            usuario.Nombre = "Modificado";
            usuario.Apellido = "Apellido";
            usuario.Login = "Admin";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            var resultUsuario = await new UsuarioBL().BuscarAsync(usuario);
            Assert.AreNotEqual(0, resultUsuario.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirRolesAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = 1;
            usuario.Nombre = "N";
            usuario.Apellido = "A";
            usuario.Login = "A";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.Top_Aux = 10;
            var resultUsuario = await new UsuarioBL().BuscarIncluirRolesAsync(usuario);
            Assert.AreNotEqual(0, resultUsuario.Count);
            var ultimoUsuario = resultUsuario.FirstOrDefault();
            Assert.IsTrue(ultimoUsuario.IdRol != null && usuario.IdRol == ultimoUsuario.Rol.IdRol);
        }

        [TestMethod()]
        public async Task T7LoginAsyncTest()
        {
            var usuario = new Usuario();
            usuario.Login = usuarioInicial.Login;
            usuario.Password = usuarioInicial.Password;
            var resultusuario = await new UsuarioBL().LoginAsync(usuario);
            Assert.AreEqual(usuario.Login, resultusuario.Login);
        }

        [TestMethod()]
        public async Task T8CambiarPasswordAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdUsuario = usuarioInicial.IdUsuario;
            string nuevoPass = "123456";
            usuario.Password = nuevoPass;
            var resultUsuario = await new UsuarioBL().CambiarPasswordAsync(usuario, usuarioInicial.Password);
            Assert.AreNotEqual(0, resultUsuario);
        }

        [TestMethod()]
        public async Task T9EliminarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdUsuario = usuarioInicial.IdUsuario;
            int result = await new UsuarioBL().EliminarAsync(usuario);
            Assert.IsTrue(result != 0);
        }
    }
}