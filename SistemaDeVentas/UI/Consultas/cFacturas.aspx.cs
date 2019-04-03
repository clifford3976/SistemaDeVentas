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
    public partial class cFacturas : System.Web.UI.Page
    {
        Expression<Func<Facturas, bool>> filtro = x => true;
        Repositorio<Facturas> repositorio = new Repositorio<Facturas>();

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            Filtrar();
            facturaGridView.DataSource = repositorio.GetList(filtro);
            facturaGridView.DataBind();
        }
        private void Filtrar()
        {
            int id = 0;
            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;

                case 1://Factura ID
                    id = int.Parse(TextCriterio.Text);
                    filtro = (x => x.FacturaId == id);
                    break;
                case 2://cliente ID
                    id = int.Parse(TextCriterio.Text);
                    filtro = (x => x.ClienteId == id);
                    break;

                case 3://total
                    filtro = (x => x.Total.Equals(TextCriterio.Text));
                    break;


            }
        }


        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteFactura.aspx");
        }

        protected void facturaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            facturaGridView.DataSource = repositorio.GetList(filtro);
            facturaGridView.PageIndex = e.NewPageIndex;
            facturaGridView.DataBind();
        }
    }
}