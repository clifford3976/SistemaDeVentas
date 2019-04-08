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
    public partial class ReporteFactura : System.Web.UI.Page
    {
        Repositorio<FacturasDetalles> repositorio = new Repositorio<FacturasDetalles>();
        Expression<Func<FacturasDetalles, bool>> filtro = C => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Repositorio<FacturasDetalles> repositorio = new Repositorio<FacturasDetalles>();

                FacturaReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                FacturaReportViewer.Reset();

                FacturaReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/FacturaReporte.rdlc");
                FacturaReportViewer.LocalReport.DataSources.Clear();
                FacturaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Factura", repositorio.GetList(c => true)));
               // FacturaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Factura", (List<FacturasDetalles>)Session["FacturasDetalles"]));

                FacturaReportViewer.LocalReport.Refresh();
            }
        }
    }
}