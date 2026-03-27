using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TransportesWeb
{
    public partial class Rutas : System.Web.UI.Page
    {
        private N_Ruta obj = new N_Ruta();       // capa de negocio de rutas
        private N_Choferes objChofer = new N_Choferes();
        private N_Camion objCamion = new N_Camion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropdowns();
                CargarRutas();
            }
        }

        private void CargarDropdowns()
        {
            ddlChofer.Items.Clear();
            foreach (var c in objChofer.ListarChoferes())
            {
                ddlChofer.Items.Add(new ListItem(c.NombreCompleto, c.IdChofer.ToString()));
            }

            ddlCamion.Items.Clear();
            foreach (var c in objCamion.ListarCamiones())
            {
                ddlCamion.Items.Add(new ListItem(c.Matricula, c.IdCamion.ToString()));
            }
        }

        private void CargarRutas()
        {
            gvRutas.DataSource = obj.ListarRutas();
            gvRutas.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdRuta.Text = "0";
            ddlChofer.SelectedIndex = 0;
            ddlCamion.SelectedIndex = 0;
            txtOrigen.Text = "";
            txtDestino.Text = "";
            txtFechaSalida.Text = "";
            txtFechaLlegada.Text = "";
            txtDistancia.Text = "";
            chkATiempo.Checked = true;

            pnlModal.Visible = true;
            pnlMensaje.Visible = false;
        }

        protected void btnGuardarRuta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrigen.Text) || string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                lblMensaje.Text = "Origen y Destino son obligatorios";
                pnlMensaje.Visible = true;
                return;
            }

            if (!DateTime.TryParse(txtFechaSalida.Text, out DateTime fechaSalida) ||
                !DateTime.TryParse(txtFechaLlegada.Text, out DateTime fechaLlegada))
            {
                lblMensaje.Text = "Fechas inválidas";
                pnlMensaje.Visible = true;
                return;
            }

            E_Rutas r = new E_Rutas
            {
                IdRuta = string.IsNullOrEmpty(txtIdRuta.Text) ? 0 : int.Parse(txtIdRuta.Text),
                IdChofer = int.Parse(ddlChofer.SelectedValue),
                IdCamion = int.Parse(ddlCamion.SelectedValue),
                Origen = txtOrigen.Text,
                Destino = txtDestino.Text,
                FechaSalida = fechaSalida,
                FechaLlegada = fechaLlegada,
                Distancia = double.TryParse(txtDistancia.Text, out double d) ? d : 0,
                ATiempo = chkATiempo.Checked,
                FechaRegistro = DateTime.Now
            };

            string rta = r.IdRuta == 0 ? obj.InsertarRuta(r) : obj.ActualizarRuta(r);

            if (rta == "OK")
            {
                pnlModal.Visible = false;
                CargarRutas();
            }
            else
            {
                lblMensaje.Text = "Error al guardar la ruta";
                pnlMensaje.Visible = true;
            }
        }

        protected void gvRutas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                // obtener ruta completa
                var r = obj.ObtenerRutaPorId(id); // Método debe estar en N_Ruta con solo idRuta

                if (r != null)
                {
                    txtIdRuta.Text = r.IdRuta.ToString();
                    ddlChofer.SelectedValue = r.IdChofer.ToString();
                    ddlCamion.SelectedValue = r.IdCamion.ToString();
                    txtOrigen.Text = r.Origen;
                    txtDestino.Text = r.Destino;
                    txtFechaSalida.Text = r.FechaSalida.ToString("yyyy-MM-ddTHH:mm");
                    txtFechaLlegada.Text = r.FechaLlegada.ToString("yyyy-MM-ddTHH:mm");
                    txtDistancia.Text = r.Distancia.ToString();
                    chkATiempo.Checked = r.ATiempo;

                    pnlModal.Visible = true;
                    pnlMensaje.Visible = false;
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                obj.EliminarRuta(id, 0, 0); // ajustar si se requiere IdChofer/IdCamion
                CargarRutas();
            }
        }

        protected void gvRutas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRutas.PageIndex = e.NewPageIndex;
            CargarRutas();
        }

        protected void btnCerrarRuta_Click(object sender, EventArgs e)
        {
            pnlModal.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarRutas();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            var lista = obj.ListarRutas();
            int filtroEstado = int.Parse(ddlEstadoFiltro.SelectedValue);

            if (filtroEstado != -1)
                lista = lista.FindAll(r => r.ATiempo == (filtroEstado == 1));

            gvRutas.DataSource = lista;
            gvRutas.DataBind();
        }
    }
}