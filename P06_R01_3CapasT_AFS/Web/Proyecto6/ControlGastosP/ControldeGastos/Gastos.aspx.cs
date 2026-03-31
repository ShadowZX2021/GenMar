using System;
using System.Web.UI;
using BLL;
using VO;

namespace ControlGastosWeb
{
    public partial class Gastos : Page
    {
        B_Gastos negocio = new B_Gastos();
        B_Usuarios negocioUsuarios = new B_Usuarios();
        B_Categorias negocioCategorias = new B_Categorias();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                CargarGastos();
                CargarDropdowns();
            }
        }

        private void CargarGastos()
        {
            gvGastos.DataSource = negocio.ListarGastos();
            gvGastos.DataBind();
        }

        private void CargarDropdowns()
        {
            ddlUsuario.DataSource = negocioUsuarios.Listar();
            ddlUsuario.DataTextField = "Nombre";
            ddlUsuario.DataValueField = "IdUsuario";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Selecciona --", "0"));

            ddlCategoria.DataSource = negocioCategorias.ListarCategorias();
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Selecciona --", "0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones dentro del modal
            if (ddlUsuario.SelectedValue == "0" || ddlCategoria.SelectedValue == "0")
            {
                lblMensajeModal.Text = "Selecciona usuario y categoría";
                AbrirModal();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                lblMensajeModal.Text = "Ingresa un monto válido";
                AbrirModal();
                return;
            }

            V_Gastos gasto = new V_Gastos
            {
                IdGastos = string.IsNullOrEmpty(hfIdGasto.Value) ? 0 : Convert.ToInt32(hfIdGasto.Value),
                IdUsuario = Convert.ToInt32(ddlUsuario.SelectedValue),
                IdCategoria = Convert.ToInt32(ddlCategoria.SelectedValue),
                Monto = Convert.ToDecimal(txtMonto.Text),
                Descripcion = txtDescripcion.Text,
                Fecha = DateTime.Now
            };

            string respuesta = negocio.InsertarGastos(gasto);

            if (respuesta == "OK")
            {
                Limpiar();
                CargarGastos();
                lblMensajeTabla.Text = "Gasto guardado correctamente";
                CerrarModal();
            }
            else
            {
                lblMensajeModal.Text = respuesta;
                AbrirModal();
            }
        }

        protected void gvGastos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvGastos.DataKeys[index].Value);

            if (e.CommandName == "Eliminar")
            {
                string mensaje;
                try
                {
                    mensaje = negocio.EliminarGastos(id);
                    if (mensaje == "OK") mensaje = "Gasto eliminado correctamente";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al eliminar: " + ex.Message;
                }

                lblMensajeTabla.Text = mensaje;
                CargarGastos();
            }
        }

        private void Limpiar()
        {
            hfIdGasto.Value = "";
            ddlUsuario.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
            txtMonto.Text = "";
            txtDescripcion.Text = "";
            lblMensajeModal.Text = "";
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        private void AbrirModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "abrirModal", "abrirModal();", true);
        }

        private void CerrarModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "cerrarModal", "cerrarModal();", true);
        }
    }
}