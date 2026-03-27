using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransportesWeb
{
    public partial class Camiones : System.Web.UI.Page
    {
        private N_Camion objNegocio = new N_Camion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCamiones();
            }
        }

        protected void gvCamiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCamiones.PageIndex = e.NewPageIndex;
            CargarCamiones();
        }

        private void CargarCamiones()
        {
            try
            {
                bool? disponibilidad = null;

                if (ddlFiltro.SelectedValue == "1")
                    disponibilidad = true;
                else if (ddlFiltro.SelectedValue == "2")
                    disponibilidad = false;

                List<E_Camion> lista = objNegocio.ListarCamiones(disponibilidad);

                gvCamiones.DataSource = lista;
                gvCamiones.DataBind();

                if (lista == null || lista.Count == 0)
                    MostrarMensaje("No se encuentra camiones con el filtro seleccionado", "info");
                else
                    pnlMensaje.Visible = false;
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar camiones: " + ex.Message, "error");
            }
        }

        private void MostrarMensaje(string mensaje, string tipo)
        {
            pnlMensaje.Visible = true;
            lblMensaje.Text = mensaje;
            pnlMensaje.CssClass = "info-mensaje " + tipo;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarCamiones();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ddlFiltro.SelectedIndex = 0;
            CargarCamiones();
            pnlMensaje.Visible = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdcamion.Text = "0";
            txtMatricula.Text = "";
            txtTipo.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtCapacidad.Text = "";
            txtKilometraje.Text = "";
            chkDisponible.Checked = true;

            ViewState["IdCamion"] = 0;

            // Abrir modal correctamente
            pnlModal.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                

                // MODELO
                if (!int.TryParse(txtModelo.Text, out int modelo))
                {
                    MostrarMensaje("El modelo debe ser un número válido.", "error");
                    return;
                }

                // CAPACIDAD
                if (!int.TryParse(txtCapacidad.Text, out int capacidad))
                {
                    MostrarMensaje("La capacidad debe ser un número válido.", "error");
                    return;
                }

                // KILOMETRAJE
                if (!double.TryParse(txtKilometraje.Text, out double kilometraje))
                {
                    MostrarMensaje("El kilometraje debe ser un número válido.", "error");
                    return;
                }

                E_Camion camion = new E_Camion
                {
                    IdCamion = int.Parse(txtIdcamion.Text),
                    Matricula = txtMatricula.Text,
                    TipoCamion = txtTipo.Text,
                    Marca = txtMarca.Text,
                    Modelo = modelo,
                    Capacidad = capacidad,
                    Kilometraje = kilometraje,
                    Disponibilidad = chkDisponible.Checked
                };

                string resultado = int.Parse(txtIdcamion.Text) == 0
                    ? objNegocio.InsertarCamion(camion)
                    : objNegocio.ActualizarCamion(camion);

                if (resultado == "OK")
                {
                    MostrarMensaje("Camión guardado correctamente.", "ok");
                    pnlModal.Visible = false;
                    CargarCamiones();
                }
                else
                {
                    MostrarMensaje(resultado, "error");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, "error");
            }
        }


        protected void gvCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                E_Camion camion = objNegocio.ObtenerCamionPorId(id);
                if (camion != null)
                {
                    txtIdcamion.Text = camion.IdCamion.ToString();
                    txtMatricula.Text = camion.Matricula;
                    txtTipo.Text = camion.TipoCamion;
                    txtMarca.Text = camion.Marca;
                    txtModelo.Text = camion.Modelo.ToString();
                    txtCapacidad.Text = camion.Capacidad.ToString();
                    txtKilometraje.Text = camion.Kilometraje.ToString("N2");
                    chkDisponible.Checked = camion.Disponibilidad;

                    ViewState["IdCamion"] = id;
                    pnlModal.Visible = true;
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                string resultado = objNegocio.EliminarCamion(id);
                MostrarMensaje(resultado == "OK" ? "Camión eliminado correctamente" : resultado, "ok");
                CargarCamiones();
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlModal.Visible = false;
        }
    }
}