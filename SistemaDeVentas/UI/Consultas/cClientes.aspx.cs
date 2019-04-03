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
    public partial class cClientes : System.Web.UI.Page
    {
        Expression<Func<Clientes, bool>> filtro = x => true;
        Repositorio<Clientes> repositorio = new Repositorio<Clientes>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBuscar_Click1(object sender, EventArgs e)
        {
            Filtrar();
            ClienteGridView.DataSource = repositorio.GetList(filtro);
            ClienteGridView.DataBind();
        }

        private void Filtrar()
        {
            int id = 0;
            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;

                case 1://Cliente ID
                    id = int.Parse(TextCriterio.Text);
                    filtro = (x => x.ClienteId == id);
                    break;

                case 2://Nombre cliente
                    filtro = (x => x.Nombres.Contains(TextCriterio.Text));
                    break;

                case 3://ApellidoCliente
                    filtro = (x => x.Apellidos.Contains(TextCriterio.Text));
                    break;


            }
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteCliente.aspx");
        }

        protected void ClienteGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ClienteGridView.DataSource = repositorio.GetList(filtro);
            ClienteGridView.PageIndex = e.NewPageIndex;
            ClienteGridView.DataBind();
        }

        protected void ClienteGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}