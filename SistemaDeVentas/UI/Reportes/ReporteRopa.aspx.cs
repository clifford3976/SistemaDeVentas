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
    public partial class ReporteRopa : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Repositorio<Ropas> repositorio = new Repositorio<Ropas>();

                RopaReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                RopaReportViewer.Reset();

                RopaReportViewer.LocalReport.ReportPath = Server.MapPath(@"../Reportes/RopaReporte.rdlc");
                RopaReportViewer.LocalReport.DataSources.Clear();
                RopaReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Ropa", (List<Ropas>)Session["Ropas"]));

                RopaReportViewer.LocalReport.Refresh();
            }
        }
    }
}