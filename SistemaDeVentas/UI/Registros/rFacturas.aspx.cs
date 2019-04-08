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

namespace SistemaDeVentas.UI.Registros
{
    public partial class rFacturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaCombo();


            }
        }

        private void LlenaCombo()
        {

            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Repositorio<Ropas> repository = new Repositorio<Ropas>();



            ClienteDropDownList.DataSource = repositorio.GetList(t => true);
            ClienteDropDownList.DataValueField = "ClienteId";
            ClienteDropDownList.DataTextField = "Nombres";
            ClienteDropDownList.DataBind();

            RopaDropDownList.DataSource = repository.GetList(t => true);
            RopaDropDownList.DataValueField = "RopaId";
            RopaDropDownList.DataTextField = "Descripcion";
            RopaDropDownList.DataBind();
        }

        private void Limpiar()
        {
            FacturaIdTextbox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CantidadTexbox.Text = "0";
            PrecioTextbox.Text = "0";
            ImporteTextbox.Text = " ";
            MontoTextBox.Text = "0";
            DevueltaTextBox.Text = "0";
            SubtotalTextBox.Text = "0";
            TotalTextBox.Text = "0";
            detalleGridView.DataSource = null;
            detalleGridView.DataBind();
            LlenaCombo();
            ViewState["Facturacion"] = null;
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (detalleGridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar.", "Error", "error");
                HayErrores = true;
            }
            if (Utils.ToIntObjetos(ClienteDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay un Cliente guardado.", "Error", "error");
                HayErrores = true;
            }
            if (Utils.ToIntObjetos(RopaDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay un Producto guardado.", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        private void LlenarCampos(Facturas facturacion)
        {
            FacturasDetalles detalle = new FacturasDetalles();

            
           
            FacturaIdTextbox.Text = facturacion.FacturaId.ToString();
            MontoTextBox.Text = facturacion.Monto.ToString();
            SubtotalTextBox.Text = facturacion.SubTotal.ToString();
            TotalTextBox.Text = facturacion.Total.ToString();
            DevueltaTextBox.Text = facturacion.Devuelta.ToString();


            //Cargar el detalle al Grid
            ViewState["Facturacion"] = facturacion.Detalles;
            detalleGridView.DataSource = (List<FacturasDetalles>)ViewState["Facturacion"];
            detalleGridView.DataBind();
        }

        private Facturas LlenaClase()
        {
            Facturas facturacion = new Facturas();
            FacturasDetalles detalle = new FacturasDetalles();
            facturacion.FacturaId = Utilities.Utils.ToInt(FacturaIdTextbox.Text);
            facturacion.ClienteId = Utilities.Utils.ToInt(ClienteDropDownList.Text);
            facturacion.Fecha = DateTime.Parse(FechaTextBox.Text);
            facturacion.Monto = Utilities.Utils.ToDecimal(MontoTextBox.Text);
            facturacion.Devuelta = Utilities.Utils.ToDecimal(DevueltaTextBox.Text);
            facturacion.SubTotal = Utils.ToDecimal(SubtotalTextBox.Text);
            facturacion.Total = Utils.ToDecimal(TotalTextBox.Text);
            facturacion.Detalles = (List<FacturasDetalles>)ViewState["Facturacion"];



            return facturacion;

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        protected void agregarLinkButton_Click(object sender, EventArgs e)
        {
            List<FacturasDetalles> facturacions = new List<FacturasDetalles>();

            Facturas facturacion = new Facturas();



            if (string.IsNullOrEmpty(ImporteTextbox.Text))
            {
                Utilities.Utils.ShowToastr(this, "Importe esta vacio", "Fallido", "error");
            }

            if (detalleGridView.Rows.Count != 0)
            {
                facturacion.Detalles = (List<FacturasDetalles>)ViewState["Facturacion"];
            }

            int cliente = Utilities.Utils.ToInt(ClienteDropDownList.SelectedValue);
            int ropaId = Utilities.Utils.ToInt(RopaDropDownList.SelectedValue);
            int cantidad = Utilities.Utils.ToInt(CantidadTexbox.Text);
            decimal precio = Utilities.Utils.ToDecimal(PrecioTextbox.Text);
            decimal Importe = Utilities.Utils.ToDecimal(ImporteTextbox.Text);


            facturacion.Detalles.Add(new FacturasDetalles(0, Utilities.Utils.ToInt(FacturaIdTextbox.Text), ropaId, cantidad, precio, Importe));

            decimal subtotal = 0;
            decimal total = 0;
            foreach (var item in facturacion.Detalles)
            {
                subtotal += item.Importe;

            }

            SubtotalTextBox.Text = subtotal.ToString();

            total += subtotal;

            TotalTextBox.Text = total.ToString();

            ViewState["Facturacion"] = facturacion.Detalles;


            detalleGridView.DataSource = ViewState["Facturacion"];
            detalleGridView.DataBind();
            MontoTextBox.Text = "";
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
           
        }

        protected void CantidadTexbox_TextChanged(object sender, EventArgs e)
        {
            int articulo = Utilities.Utils.ToInt(RopaDropDownList.SelectedValue);

            List<Ropas> A = RopaBLL.GetList(x => x.RopaId == articulo);

            foreach (var item in A)
            {
                PrecioTextbox.Text = item.Precio.ToString();

                int cantidad = Utils.ToInt(CantidadTexbox.Text);
                decimal importe;

                importe = FacturasBLL.CalcularImporte(item.Precio, cantidad);
                ImporteTextbox.Text = importe.ToString();
            }
        }

        protected void PrecioTextbox_TextChanged(object sender, EventArgs e)
        {
            int articulo = Utilities.Utils.ToInt(RopaDropDownList.SelectedValue);

            List<Ropas> A = RopaBLL.GetList(x => x.RopaId == articulo);

            foreach (var item in A)
            {
                PrecioTextbox.Text = item.Precio.ToString();

                int cantidad = Utils.ToInt(CantidadTexbox.Text);
                decimal importe;

                importe = FacturasBLL.CalcularImporte( item.Precio, cantidad);
                ImporteTextbox.Text = importe.ToString();
            }
           
        }
        protected void Remover_Click(object sender, EventArgs e)
        {
            /*if (detalleGridView.Rows.Count > 0
             && detalleGridView.SelectedRow != null)
            {

                List<FacturasDetalles> detalle = (List<FacturasDetalles>)detalleGridView.DataSource;



                detalle.RemoveAt(detalleGridView.SelectedRow.RowIndex);


                decimal subtotal = 0;
                decimal total = 0;

                foreach (var item in detalle)
                {
                    subtotal += item.Importe;
                }

                SubtotalTextBox.Text = subtotal.ToString();

                total += Convert.ToInt32(SubtotalTextBox.Text);

                TotalTextBox.Text = total.ToString();

                detalleGridView.DataSource = null;
                detalleGridView.DataSource = detalle;



            }*/
        }


        protected void RemoverButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void MontoTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal total = Utils.ToDecimal(TotalTextBox.Text);
            decimal monto = Utils.ToDecimal(MontoTextBox.Text);
            decimal devuelta;

            if (monto < total)
            {
                Utilities.Utils.ShowToastr(this, "le falta dinero para pagar el articulo", "Fallido", "error");
            }
            else if (monto >= total)
            {
                devuelta = FacturasBLL.CalcularDevuelta(monto, total);
                DevueltaTextBox.Text = devuelta.ToString();
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            FacturasBLL repositorio = new FacturasBLL();
            Facturas factura = new Facturas();

            if (HayErrores())
            {
                return;
            }
            else
            {
                factura = LlenaClase();

                if (Utils.ToInt(FacturaIdTextbox.Text) == 0)
                {
                    paso = FacturasBLL.Guardar(factura);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    FacturasBLL repository = new FacturasBLL();
                    int id = Utils.ToInt(FacturaIdTextbox.Text);
                    factura = FacturasBLL.Buscar(id);

                    if (factura != null)
                    {
                        paso = FacturasBLL.Modificar(LlenaClase());
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");
                        Limpiar();
                    }
                    else
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                }

                if (paso)
                {
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            FacturasBLL repositorio = new FacturasBLL();
            int id = Utils.ToInt(FacturaIdTextbox.Text);

            var factura = FacturasBLL.Buscar(id);

            if (factura != null)
            {
                if (FacturasBLL.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            FacturasBLL repositorio = new FacturasBLL();

            var factura = FacturasBLL.Buscar(Utils.ToInt(FacturaIdTextbox.Text));
            if (factura != null)
            {
                LlenarCampos(factura);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No se pudo encontrar la factura", "Error", "error");
            }
        }

        private void Precio()
        {
            int articulo = Utilities.Utils.ToInt(RopaDropDownList.SelectedValue);

            List<Ropas> A = RopaBLL.GetList(x => x.RopaId == articulo);

            foreach (var item in A)

            {
                PrecioTextbox.Text = item.Precio.ToString();
                

            }
        }

        protected void RopaDropDownList_TextChanged(object sender, EventArgs e)
        {
            Precio();
        }
       

        protected void detalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
        }

        protected void ClienteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ImporteTextbox_TextChanged(object sender, EventArgs e)
        {
            int articulo = Utilities.Utils.ToInt(RopaDropDownList.SelectedValue);

            List<Ropas> A = RopaBLL.GetList(x => x.RopaId == articulo);

            foreach (var item in A)
            {
                PrecioTextbox.Text = item.Precio.ToString();

                int cantidad = Utils.ToInt(CantidadTexbox.Text);
                decimal importe;

                importe = FacturasBLL.CalcularImporte(item.Precio, cantidad);
                ImporteTextbox.Text = importe.ToString();
            }
        }

        protected void DevueltaTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void ReporteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteRecibido.aspx");
        }


        protected void InventarioTextBox_TextChanged(object sender, EventArgs e)
        {
            Precio();
        }

        protected void detalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Expression<Func<Ropas, bool>> filtro = p => true;
                Repositorio<Ropas> repositorio = new Repositorio<Ropas>();
                var lista = repositorio.GetList(c => true);
                var ropa = repositorio.Buscar(lista[index].RopaId);

                Facturas facturacion = new Facturas();

                decimal subtotal = 0;
                decimal total = 0;
                foreach (var item in facturacion.Detalles)
                {
                    subtotal += item.Importe;

                }

                SubtotalTextBox.Text = subtotal.ToString();

                total += subtotal;

                TotalTextBox.Text = total.ToString();

                ((List<FacturasDetalles>)ViewState["Facturacion"]).RemoveAt(index);
                detalleGridView.DataSource = ViewState["Facturacion"];
                detalleGridView.DataBind();
                MontoTextBox.Text = "";
                DevueltaTextBox.Text = "";
            
        }
    }

        protected void detalleGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void detalleGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void detalleGridView_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            detalleGridView.DataSource = ViewState["Facturacion"];
            detalleGridView.PageIndex = e.NewPageIndex;
            detalleGridView.DataBind();
        }
    }
}