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
    public partial class cRopas : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
        Expression<Func<Ropas, bool>> filtro = x => true;
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
                    filtro = c => c.RopaId == id;
                    Mensaje();

                    break;

                case 1://  Descripcion
                    filtro = c => c.Descripcion.Contains(CriterioTextBox.Text);
                    Mensaje();
                    break;

                case 2://  Marca
                    filtro = c => c.Marca.Contains(CriterioTextBox.Text);
                    Mensaje();
                    break;

                case 3:// Inventario

                    int inventario = Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.Inventario == inventario;
                    Mensaje();
                    break;

                case 4://Todos

                    filtro = x => true;
                    Mensaje();
                    break;





            }
            var lista = repositorio.GetList(filtro);
            DatosGridView.DataSource = lista;
            Session["Ropas"] = lista;
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
            Response.Redirect("../Reportes/ReporteRopa.aspx");
        }
    }
}