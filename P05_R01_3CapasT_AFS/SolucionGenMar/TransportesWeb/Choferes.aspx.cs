using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TransportesWeb
{
    public partial class Choferes : System.Web.UI.Page
    {
        private N_Choferes obj = new N_Choferes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarChoferes();
        }

        private void CargarChoferes()
        {
            gvChoferes.DataSource = obj.ListarChoferes();
            gvChoferes.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            int filtro = int.Parse(ddlFiltro.SelectedValue); // 0=Todos, 1=Disponibles, 2=No Disponibles
            List<E_Chofer> lista = obj.ListarChoferes(); // obtienes todos los choferes

            switch (filtro)
            {
                case 1: // Disponibles
                    lista = lista.FindAll(c => c.Disponibilidad);
                    break;
                case 2: // No Disponibles
                    lista = lista.FindAll(c => !c.Disponibilidad);
                    break;
                case 0:
                default: // Todos
                    break;
            }

            gvChoferes.DataSource = lista;
            gvChoferes.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtApPaterno.Text = "";
            txtApMaterno.Text = "";
            txtTelefono.Text = "";
            txtLicencia.Text = "";
            txtFechaNacimiento.Text = "";
            chkDisponible.Checked = true;

            pnlModal.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1️⃣ Validar que el campo no esté vacío
            if (string.IsNullOrWhiteSpace(txtFechaNacimiento.Text))
            {
                lblMensaje.Text = " La fecha de nacimiento es obligatoria.";
                pnlMensaje.Visible = true;
                return; // salir del método, no guardar
            }

            // Intentar convertir la fecha
            DateTime fechaNacimiento;
            if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            {
                lblMensaje.Text = " Fecha de nacimiento inválida.";
                pnlMensaje.Visible = true;
                return; // salir del método
            }

            //  Crear objeto E_Chofer con fecha obligatoria
            E_Chofer c = new E_Chofer
            {
                IdChofer = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                ApPaterno = txtApPaterno.Text,
                ApMaterno = txtApMaterno.Text,
                Telefono = txtTelefono.Text,
                Licencia = txtLicencia.Text,
                Disponibilidad = chkDisponible.Checked,
                FechaNacimiento = fechaNacimiento // obligatoria
            };

            // 4️⃣ Guardar o actualizar
            string r = c.IdChofer == 0
                ? obj.InsertarChofer(c)
                : obj.ActializarChofer(c);

            if (r == "OK")
            {
                pnlModal.Visible = false;
                CargarChoferes();
            }
            else
            {
                lblMensaje.Text = " Error al guardar el chofer.";
                pnlMensaje.Visible = true;
            }
        }

        protected void gvChoferes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                var c = obj.ObtenerChoferPorId(id);

                txtId.Text = c.IdChofer.ToString();
                txtNombre.Text = c.Nombre;
                txtApPaterno.Text = c.ApPaterno;
                txtApMaterno.Text = c.ApMaterno;
                txtTelefono.Text = c.Telefono;
                txtLicencia.Text = c.Licencia;
                chkDisponible.Checked = c.Disponibilidad;
                txtFechaNacimiento.Text = c.FechaNacimiento.ToString("yyyy-MM-dd");

                pnlModal.Visible = true;
            }
            else if (e.CommandName == "Eliminar")
            {
                obj.EliminarChofer(id);
                CargarChoferes();
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlModal.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarChoferes();
        }

        protected void gvChoferes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvChoferes.PageIndex = e.NewPageIndex;
            CargarChoferes(); // o el método que ya uses para llenar el grid
        }
    }
}