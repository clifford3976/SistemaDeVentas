using BLL;
using Entities;
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
        Expression<Func<Ropas, bool>> filtro = x => true;
        Repositorio<Ropas> repositorio = new Repositorio<Ropas>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            Filtrar();
            RopaGridView.DataSource = repositorio.GetList(filtro);
            RopaGridView.DataBind();
        }
        private void Filtrar()
        {
            int id = 0;
            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;

                case 1://Ropa ID
                    id = int.Parse(TextCriterio.Text);
                    filtro = (x => x.RopaId == id);
                    break;

                case 2://descripcion 
                    filtro = (x => x.Descripcion.Contains(TextCriterio.Text));
                    break;

                case 3://precio
                    filtro = (x => x.Precio.Equals(TextCriterio.Text));
                    break;


            }
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteRopa.aspx");
        }

        protected void RopaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RopaGridView.DataSource = repositorio.GetList(filtro);
            RopaGridView.PageIndex = e.NewPageIndex;
            RopaGridView.DataBind();
        }
    }
}