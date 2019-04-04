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
    public partial class ReporteRecibido : System.Web.UI.Page
    {
        Repositorio<Facturas> repositorio = new Repositorio<Facturas>();
        Expression<Func<Facturas, bool>> filtro = C => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReciboReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReciboReportViewer.Reset();

                ReciboReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/RecibidoReporte.rdlc");

                ReciboReportViewer.LocalReport.DataSources.Clear();

                ReciboReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Factura", repositorio.GetList(c => true)));
                ReciboReportViewer.LocalReport.Refresh();
            }
        }
    }
}