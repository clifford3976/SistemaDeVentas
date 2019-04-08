using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Linq.Expressions;

namespace BLL.Tests
{
    [TestClass()]
    public class InventarioRepositorioTests
    {
        [TestMethod()]
        public void GuardarTest()
        {

            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            Inventarios inventario = new Inventarios();
            bool paso = false;

            inventario.InventarioId = 1;
            inventario.Descripcion = "camiseta";
            inventario.RopaId = 1;
            inventario.Cantidad = 5;

            paso = repositorio.Guardar(inventario);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {

            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            Inventarios inventario = new Inventarios();
            bool paso = false;
            inventario.Descripcion ="camiseta";
            paso = repositorio.Modificar(inventario);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            int id = 1;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            Inventarios inventario = new Inventarios();
            inventario = repositorio.Buscar(id);
            Assert.IsNotNull(inventario);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            List<Inventarios> lista = new List<Inventarios>();
            Expression<Func<Inventarios, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}