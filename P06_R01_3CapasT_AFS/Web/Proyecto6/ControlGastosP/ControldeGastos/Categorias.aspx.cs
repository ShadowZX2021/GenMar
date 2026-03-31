using System;
using System.Web.UI;
using BLL;
using VO;

namespace ControlGastosWeb
{
    public partial class Categorias : Page
    {
        B_Categorias negocio = new B_Categorias();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
                CargarCategorias();
        }

        private void CargarCategorias()
        {
            gvCategorias.DataSource = negocio.ListarCategorias();
            gvCategorias.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación dentro del modal
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lblMensajeModal.Text = "El nombre es obligatorio";
                AbrirModal();
                return;
            }

            V_Categorias categoria = new V_Categorias
            {
                IdCategoria = string.IsNullOrEmpty(hfIdCategoria.Value) ? 0 : Convert.ToInt32(hfIdCategoria.Value),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
            };

            string respuesta = categoria.IdCategoria == 0
                ? negocio.InsetarCategoria(categoria)
                : negocio.ActualizarCategoria(categoria);

            if (respuesta == "OK")
            {
                Limpiar();
                CargarCategorias();
                CerrarModal();
                lblMensajeTabla.Text = "Categoría guardada correctamente";
            }
            else
            {
                lblMensajeModal.Text = respuesta;
                AbrirModal();
            }
        }

        protected void gvCategorias_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvCategorias.DataKeys[index].Value);

            if (e.CommandName == "Editar")
            {
                var cat = negocio.ObtenerCategoriaPorId(id);

                hfIdCategoria.Value = cat.IdCategoria.ToString();
                txtNombre.Text = cat.Nombre;
                txtDescripcion.Text = cat.Descripcion;

                ScriptManager.RegisterStartupScript(this, GetType(), "abrir",
                    "document.getElementById('tituloModal').innerText='Editar Categoría'; abrirModal();", true);
            }
            else if (e.CommandName == "Eliminar")
            {
                string mensajeTabla = negocio.EliminarCategoria(id);
                if (mensajeTabla == "OK")
                    mensajeTabla = "Categoría eliminada correctamente";

                lblMensajeTabla.Text = mensajeTabla;
                CargarCategorias();
            }
        }

        private void Limpiar()
        {
            hfIdCategoria.Value = "";
            txtNombre.Text = "";
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