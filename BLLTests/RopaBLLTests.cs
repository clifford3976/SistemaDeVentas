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
    public class RopaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            Ropas ropa = new Ropas();
            bool paso = false;

            ropa.RopaId = 1;
            ropa.Descripcion = "camiseta";
            ropa.Size = "M";
            ropa.Marca = "LV";
            ropa.Precio = 1500;
            ropa.Inventario = 5;

            paso = repositorio.Guardar(ropa);
            Assert.AreEqual(true, paso);

        }

        [TestMethod()]
        public void ModificarTest()
        {
            var ropa = BuscarM();
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();

            bool paso = false;
            ropa.Descripcion = "Poloche";
            paso = repositorio.Modificar(ropa);
            Assert.AreEqual(true, paso);

        }
        public Ropas BuscarM()
        {
            int id = 2;
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            Ropas ropa = new Ropas();
            ropa = repositorio.Buscar(id);
            return ropa;
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            int id = 2;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);

        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            Ropas ropa = new Ropas();
            ropa = repositorio.Buscar(id);
            Assert.IsNotNull(ropa);

        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
            List<Ropas> lista = new List<Ropas>();
            Expression<Func<Ropas, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);

        }
    }
}