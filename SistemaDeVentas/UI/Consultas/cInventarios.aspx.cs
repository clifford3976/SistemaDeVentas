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
    public partial class cInventarios : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        Expression<Func<Inventarios, bool>> filtro = x => true;
        Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();

        public void Mensaje()
        {


            if (repositorio.GetList(filtro).Count() == 0)
            {
                Utils.ShowToastr(this.Page, "No hay Registros", "Informacion", "info");
                return;
            }

        }
        public void RetornaLista()
        {


            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);



            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://ID
                    id = Utils.ToInt(CriterioTextBox.Text);

                    filtro = c => c.InventarioId == id && (c.Fecha >= desde && c.Fecha <= hasta);


                    Mensaje();

                    break;

                case 1://  ropaid
                    id = Utils.ToInt(CriterioTextBox.Text);

                    filtro = c => c.RopaId == id && (c.Fecha >= desde && c.Fecha <= hasta);


                    Mensaje();

                    break;


                case 2:// cantidad

                    filtro = c => c.Cantidad == Utils.ToDecimal(CriterioTextBox.Text) && (c.Fecha >= desde && c.Fecha <= hasta);

                    Mensaje();

                    break;

                case 4://Todos

                    filtro = x => true && (x.Fecha >= desde && x.Fecha <= hasta);
                    Mensaje();
                    break;

            }

            var lista = repositorio.GetList(filtro);
            Session["Inventarios"] = lista;
            CriterioTextBox.Text = "";
            DatosGridView.DataSource = lista;
            DatosGridView.DataBind();

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
            Response.Redirect("../Reportes/ReporteInventario.aspx");
        }
    }  
}