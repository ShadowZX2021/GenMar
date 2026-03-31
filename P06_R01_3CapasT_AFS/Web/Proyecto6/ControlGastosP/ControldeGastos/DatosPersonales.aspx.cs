using System;
using System.Web.UI;
using BLL;
using VO;
using System.Data.SqlClient;

namespace ControlGastosWeb
{
    public partial class DatosPersonales : Page
    {
        B_DatosPersonales negocio = new B_DatosPersonales();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
                CargarDatos();
        }

        private void CargarDatos()
        {
            gvDatos.DataSource = negocio.ListarDatosPersonales();
            gvDatos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            V_DatosPersonales datos = new V_DatosPersonales
            {
                IdDatos = string.IsNullOrEmpty(hfIdDatos.Value) ? 0 : Convert.ToInt32(hfIdDatos.Value),
                Nombre = txtNombre.Text,
                ApPaterno = txtApPaterno.Text,
                ApMaterno = txtApMaterno.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text
            };

            string respuesta;
            try
            {
                respuesta = datos.IdDatos == 0
                    ? negocio.InsertarDatosPersonales(datos)
                    : negocio.ActualizarDatosPersonales(datos);
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }

            // Si es OK cierra modal y refresca Grid
            if (respuesta == "OK")
            {
                Limpiar();
                CargarDatos();
                ScriptManager.RegisterStartupScript(this, GetType(), "cerrar", "cerrarModal();", true);
            }
            else
            {
                // Mostrar mensaje dentro del modal
                lblModalMensaje.Text = respuesta;
                ScriptManager.RegisterStartupScript(this, GetType(), "abrir", "abrirModal();", true);
            }
        }

        protected void gvDatos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvDatos.DataKeys[index].Value);

            if (e.CommandName == "Editar")
            {
                var datos = negocio.ObtenerDatosPersonalesId(id);

                hfIdDatos.Value = datos.IdDatos.ToString();
                txtNombre.Text = datos.Nombre;
                txtApPaterno.Text = datos.ApPaterno;
                txtApMaterno.Text = datos.ApMaterno;
                txtTelefono.Text = datos.Telefono;
                txtDireccion.Text = datos.Direccion;

                lblModalMensaje.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "abrir",
                    "document.getElementById('tituloModal').innerText='Editar Datos Personales'; abrirModal();", true);
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    string respuesta = negocio.EliminarDatosPersonales(id);
                    if (respuesta == "OK")
                    {
                        CargarDatos();
                        lblMensaje.Text = "Dato eliminado correctamente";
                    }
                    else
                    {
                        lblMensaje.Text = respuesta;
                    }
                }
                catch (SqlException ex)
                {
                    // Detecta violación de FK y muestra mensaje amigable
                    if (ex.Number == 547)
                        lblMensaje.Text = "No se puede eliminar porque tiene gastos asignados";
                    else
                        lblMensaje.Text = "Error: " + ex.Message;
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error: " + ex.Message;
                }
            }
        }

        private void Limpiar()
        {
            hfIdDatos.Value = "";
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            lblModalMensaje.Text = "";
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}