using BLL;
using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaDeVentas.UI.Reportes
{
    public partial class ReporteCliente : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Repositorio<Clientes> repositorio = new Repositorio<Clientes>();

                ClienteReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ClienteReportViewer.Reset();

                ClienteReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/ClienteReporte.rdlc");
                ClienteReportViewer.LocalReport.DataSources.Clear();
                ClienteReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Cliente", (List<Clientes>)Session["Clientes"]));

                ClienteReportViewer.LocalReport.Refresh();
            }
        }
    }
}