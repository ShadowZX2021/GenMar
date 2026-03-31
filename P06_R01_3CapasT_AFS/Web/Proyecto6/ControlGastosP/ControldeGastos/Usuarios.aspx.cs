using System;
using System.Web.UI;
using BLL;
using VO;

namespace ControlGastosWeb
{
    public partial class Usuarios : Page
    {
        B_Usuarios negocio = new B_Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                CargarUsuarios();
                CargarDropDatos();
            }
        }

        private void CargarUsuarios()
        {
            gvUsuarios.DataSource = negocio.Listar();
            gvUsuarios.DataBind();
        }

        private void CargarDropDatos()
        {
            ddlDatos.DataSource = negocio.DropListDP();
            ddlDatos.DataTextField = "Nombre";
            ddlDatos.DataValueField = "IdDatos";
            ddlDatos.DataBind();

            ddlDatos.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Selecciona --", "0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddlDatos.SelectedValue == "0")
            {
                lblMensajeModal.Text = "Selecciona una persona";
                AbrirModal();
                return;
            }

            V_Usuarios usuario = new V_Usuarios()
            {
                IdUsuario = string.IsNullOrEmpty(hfIdUsuario.Value) ? 0 : Convert.ToInt32(hfIdUsuario.Value),
                IdDatos = Convert.ToInt32(ddlDatos.SelectedValue),
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            string respuesta;
            try
            {
                respuesta = (usuario.IdUsuario == 0)
                    ? negocio.InsertarUsuario(usuario)
                    : negocio.ActualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }

            if (respuesta == "OK")
            {
                Limpiar();
                CargarUsuarios();
                CerrarModal();
                lblMensajeTabla.Text = "Usuario guardado correctamente";
            }
            else
            {
                lblMensajeModal.Text = respuesta;
                AbrirModal();
            }
        }

        protected void gvUsuarios_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvUsuarios.DataKeys[index].Value);

            if (e.CommandName == "Editar")
            {
                var usuario = negocio.ObtenerPorId(id);
                hfIdUsuario.Value = usuario.IdUsuario.ToString();
                ddlDatos.SelectedValue = usuario.IdDatos.ToString();
                txtNombre.Text = usuario.Nombre;
                txtEmail.Text = usuario.Email;
                txtPassword.Text = usuario.Password;

                ScriptManager.RegisterStartupScript(this, GetType(), "abrir",
                    "document.getElementById('tituloModal').innerText='Editar Usuario'; abrirModal();", true);
            }
            else if (e.CommandName == "Eliminar")
            {
                string mensajeTabla;
                try
                {
                    mensajeTabla = negocio.EliminarUsuario(id);
                    if (mensajeTabla == "OK")
                        mensajeTabla = "Usuario eliminado correctamente";
                }
                catch (Exception ex)
                {
                    if (ex is System.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 547)
                        mensajeTabla = "No se puede borrar porque tiene gastos asignados";
                    else if (ex.InnerException is System.Data.SqlClient.SqlException innerSqlEx && innerSqlEx.Number == 547)
                        mensajeTabla = "No se puede borrar porque tiene gastos asignados";
                    else
                        mensajeTabla = "Error al eliminar: " + ex.Message;
                }

                CargarUsuarios();
                lblMensajeTabla.Text = mensajeTabla;
                ScriptManager.RegisterStartupScript(this, GetType(), "scrollTop", "window.scrollTo(0,0);", true);
            }
        }

        private void Limpiar()
        {
            hfIdUsuario.Value = "";
            ddlDatos.SelectedIndex = 0;
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
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