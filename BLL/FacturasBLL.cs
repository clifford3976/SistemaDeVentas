using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturasBLL
    {
        private static Usuarios user = new Usuarios();

        public static bool Guardar(Facturas Factura)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            Clientes Cliente = new Clientes();
            try
            {
                if (contexto.Facturas.Add(Factura) != null)
                {
                    //Inventarios inventario = contexto.Inventarios.Find(Factura.FacturaId);


                    foreach (var item in Factura.Detalles)
                    {
                        contexto.Ropas.Find(item.RopaId).Inventario -= item.Cantidad;
                        contexto.Inventarios.Find(item.RopaId).Cantidad -= item.Cantidad;
                    }


                    //contexto.Facturas.Find(Factura.FacturaId).Devuelta += Factura.Monto - Factura.Total;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }



        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Facturas Factura = contexto.Facturas.Find(id);


                if (Factura != null)
                {
                    foreach (var item in Factura.Detalles)
                    {
                        contexto.Ropas.Find(item.RopaId).Inventario += item.Cantidad;

                    }
                    contexto.Facturas.Find(Factura.FacturaId).Devuelta -= Factura.Monto - Factura.Total;

                    Factura.Detalles.Count();
                    contexto.Facturas.Remove(Factura);
                }




                if (contexto.SaveChanges() > 0)
                {

                    paso = true;
                }
                contexto.Dispose();


            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }




        public static Facturas Buscar(int id)
        {
            Facturas Factura = new Facturas();
            Contexto contexto = new Contexto();

            try
            {
                Factura = contexto.Facturas.Find(id);
                if (Factura != null)
                {
                    Factura.Detalles.Count();

                    foreach (var item in Factura.Detalles)
                    {

                        string s = item.Ropas.Descripcion;
                    }

                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Factura;
        }


        public static bool Modificar(Facturas Factura)
        {

            bool paso = false;
            Contexto contexto = new Contexto();



            try
            {
                var factura = FacturasBLL.Buscar(Factura.FacturaId);


                if (factura != null)
                {


                    foreach (var item in factura.Detalles)
                    {

                        contexto.Ropas.Find(item.RopaId).Inventario += item.Cantidad;



                        if (!Factura.Detalles.ToList().Exists(v => v.Id == item.Id))
                        {


                            item.Ropas = null;
                            contexto.Entry(item).State = EntityState.Deleted;
                        }



                    }


                    foreach (var item in Factura.Detalles)
                    {
                        contexto.Ropas.Find(item.RopaId).Inventario -= item.Cantidad;



                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }





                    Facturas Anterior = FacturasBLL.Buscar(Factura.FacturaId);


                    //identificar la diferencia ya sea restada o sumada
                    decimal diferencia;

                    diferencia = Factura.Devuelta - Anterior.Devuelta;

                    //aplicar diferencia al inventario
                    Facturas facturas = FacturasBLL.Buscar(Factura.FacturaId);
                    facturas.Devuelta += diferencia;
                    FacturasBLL.Modificar(facturas);





                    contexto.Entry(Factura).State = EntityState.Modified;
                }



                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;


        }



        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Facturas> Factura = new List<Facturas>();

            try
            {
                Factura = contexto.Facturas.Where(expression).ToList();

                foreach (var item in Factura)
                {
                    item.Detalles.Count();
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Factura;

        }

        public static void NombreLogin(string nombre, int id)
        {
            user.NombreUsuario = nombre;
            user.UsuarioId = id;
        }

        public static Usuarios returnUsuario()
        {
            return user;
        }

        public static decimal CalcularImporte(decimal precio, int cantidad)
        {
            decimal calculo;
            calculo = precio * cantidad;
            return calculo;
        }


        public static decimal CalcularDevuelta(decimal Monto, decimal Total)
        {
            decimal calculo;
            calculo = Monto - Total;
            return calculo;
        }
    }
}
