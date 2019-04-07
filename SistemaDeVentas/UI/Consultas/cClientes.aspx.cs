using BLL;
using Entities;
using SistemaDeVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaDeVentas.UI.Consultas
{
    public partial class cClientes : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Repositorio<Clientes> repositorio = new Repositorio<Clientes>();

        Expression<Func<Clientes, bool>> filtro = x => true;

        public void Mensaje()
        {

            if (repositorio.GetList(filtro).Count() == 0)
            {
                Utils.ShowToastr(this.Page, "No hay Registros con el Criterio Buscado", "Informacion", "info");
                return;
            }

        }


        public void RetornaLista()
        {


            int id = 0;


            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://ID
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.ClienteId == id;
                    Mensaje();

                    break;

                case 1://  Nombres
                    filtro = c => c.Nombres.Contains(CriterioTextBox.Text);
                    Mensaje();
                    break;

                case 2:// CEDULA


                    filtro = c => c.Cedula == CriterioTextBox.Text;
                    Mensaje();
                    break;

                case 3:// Direccion


                    filtro = c => c.Direccion == CriterioTextBox.Text;
                    Mensaje();
                    break;


                case 4:// Telefono


                    filtro = c => c.Telefono == CriterioTextBox.Text;
                    Mensaje();
                    break;

                case 5://Todos

                    filtro = x => true;
                    Mensaje();
                    break;





            }

            var lista = repositorio.GetList(filtro);
            Session["Clientes"] = lista;

            DatosGridView.DataSource = lista;
            DatosGridView.DataBind();
            CriterioTextBox.Text = "";

            if (DatosGridView.Rows.Count > 0)
            {
                ImprimirButton.Visible = true;
            }
            else { ImprimirButton.Visible = false; }

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RetornaLista();
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteCliente.aspx");
        }
    }
}