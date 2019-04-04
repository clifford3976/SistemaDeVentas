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
    public class FacturasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            FacturasBLL repositorio = new FacturasBLL();
            Facturas factura = new Facturas();
            factura.FacturaId = 1;
            factura.ClienteId = 1;
            factura.Monto = 2000;
            factura.Devuelta = 1000;
            factura.SubTotal = 1000;
            factura.Total = 1000;

            factura.Detalles.Add(new FacturasDetalles(1, 2, 1, 5, 500, 2500));
            factura.Detalles.Add(new FacturasDetalles(2, 1, 1, 4, 200, 800));

            bool paso = FacturasBLL.Guardar(factura);
            Assert.AreEqual(true, paso);

        }

        [TestMethod()]
        public void ModificarTest()
        {
            FacturasBLL repositorio = new FacturasBLL();
            int id = 2;
            var factura = FacturasBLL.Buscar(id);

            factura.Detalles.Add(new FacturasDetalles(1, 2, 1, 5, 500, 2500));
            bool paso = FacturasBLL.Modificar(factura);
            Assert.AreEqual(true, paso);
           
        }

        [TestMethod()]
        public void EliminarTest()
        {
            FacturasBLL repositorio = new FacturasBLL();
            int id = 2;
            bool paso = FacturasBLL.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            FacturasBLL repositorio = new FacturasBLL();
            Facturas factura = new Facturas();
            bool paso = factura.Detalles.Count > 0;
            factura = FacturasBLL.Buscar(id);
            Assert.IsNotNull(factura);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
            List<Facturas> lista = new List<Facturas>();
            Expression<Func<Facturas, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}