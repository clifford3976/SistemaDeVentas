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
    public partial class rClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
                    var cliente = repositorio.Buscar(id);

                    if (cliente == null)
                        Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    else
                        LlenaCampos(cliente);
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes clientes = repositorio.Buscar(Utils.ToInt(ClienteIdTextbox.Text));

            if (IsValid)
            {
                if (clientes != null)
                {
                    Utils.MostrarMensaje(this, "Hay Resultado", "Exito!!", "info");
                    Limpiar();
                    LlenaCampos(clientes);
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Hay Resultado", "Error", "error");
                    Limpiar();
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected bool ValidarNombres(Clientes clientes)
        {
            bool validar = false;
            Expression<Func<Clientes, bool>> filtro = p => true;
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            var lista = repositorio.GetList(c => true);
            foreach (var item in lista)
            {
                if (clientes.Cedula == item.Cedula)
                {
                    Utils.ShowToastr(this.Page, "Cliente ya Existe", "Error", "error");
                    return validar = true;
                }
            }

            return validar;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes cliente = repositorio.Buscar(Utils.ToInt(ClienteIdTextbox.Text));

            if (IsValid)
            {
                if (ValidarNombres(LlenaClase()))
                {
                    return;
                }
                else
                {
                    if (cliente == null)
                    {
                        if (repositorio.Guardar(LlenaClase()))
                        {
                            Utils.MostrarMensaje(this, "Guardado", "Exito!!", "success");
                            Limpiar();
                        }
                        else
                        {
                            Utils.MostrarMensaje(this, "No Guardado", "Advertencia", "warning");
                            Limpiar();
                        }
                    }
                    else
                    {
                        if (repositorio.Modificar(LlenaClase()))
                        {
                            Utils.MostrarMensaje(this, "Modificado", "Exito!!", "info");
                            Limpiar();
                        }
                        else
                        {
                            Utils.MostrarMensaje(this, "No Modificado", "Advertencia", "warning");
                            Limpiar();
                        }

                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Clientes> repositorio = new Repositorio<Clientes>();
            Clientes clientes = repositorio.Buscar(Utils.ToInt(ClienteIdTextbox.Text));

            if (IsValid)
            {
                if (clientes != null)
                {
                    repositorio.Eliminar(clientes.ClienteId);
                    Utils.MostrarMensaje(this, "Eliminado", "Exito!!", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostrarMensaje(this, "No Eliminado", "Advertencia", "warning");
                    Limpiar();
                }
            }
        }

        private Clientes LlenaClase()
        {
            Clientes cliente = new Clientes();
            cliente.ClienteId = Utils.ToInt(ClienteIdTextbox.Text);

            cliente.Nombres = NombreTextBox.Text;
            cliente.Apellidos = ApellidoTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Email = EmailTextBox.Text;
            cliente.Cedula = CedulaTextBox.Text;
            cliente.Telefono = TelefonoTextBox.Text;

            return cliente;
        }

        private void LlenaCampos(Clientes cliente)
        {
            ClienteIdTextbox.Text = cliente.ClienteId.ToString();

            NombreTextBox.Text = cliente.Nombres;
            ApellidoTextBox.Text = cliente.Apellidos;
            DireccionTextBox.Text = cliente.Direccion;
            EmailTextBox.Text = cliente.Email;
            CedulaTextBox.Text = cliente.Cedula;
            TelefonoTextBox.Text = cliente.Telefono;
        }

        private void Limpiar()
        {
            ClienteIdTextbox.Text = "";

            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            DireccionTextBox.Text = "";
            EmailTextBox.Text = "";
            CedulaTextBox.Text = "";
            TelefonoTextBox.Text = "";
        }
    }
}