using CapaEntidades;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmChoferes : Form
    {
        N_Choferes objNegocio = new N_Choferes();
        int idChoferSeleccionado = 0;

        public FrmChoferes()
        {
            InitializeComponent();
            
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = lts_FiltarporCh.SelectedItem.ToString();

            var lista = objNegocio.ListarChoferes();

            if (filtro == "Disponibles")
            {
                lista = lista.Where(x => x.Disponibilidad == true).ToList();
            }
            else if (filtro == "No disponibles")
            {
                lista = lista.Where(x => x.Disponibilidad == false).ToList();
            }

            dataGrid_Chofer2.DataSource = lista;
        }

        private void FrmChoferes_Load(object sender, EventArgs e)
        {
            CargarChoferes();
            num_TelefonoCH.Minimum = 0;
            num_TelefonoCH.Maximum = 9999999999;
            num_TelefonoCH.Value = 0;

            num_LicenciaCh.Minimum = 0;
            num_LicenciaCh.Maximum = 9999999999;
            num_LicenciaCh.Value = 0;

            lts_FiltarporCh.Items.Add("Todos");
            lts_FiltarporCh.Items.Add("Disponibles");
            lts_FiltarporCh.Items.Add("No disponibles");

            lts_FiltarporCh.SelectedIndex = 0;
        }

        private void txt_ApMaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_NombreCh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ApPaternoCh_TextChanged(object sender, EventArgs e)
        {

        }

        private void num_TelefonoCH_ValueChanged(object sender, EventArgs e)
        {

        }

        private void date_FechaNacimientoCh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void num_LicenciaCh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_UrlFotosCH_TextChanged(object sender, EventArgs e)
        {

        }

        private void chk_DisponibilidadChofer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lts_FiltarporCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lts_FiltarporCh.SelectedItem == null) return;

            string filtro = lts_FiltarporCh.SelectedItem.ToString();

            var lista = objNegocio.ListarChoferes();

            if (filtro == "Disponibles")
            {
                lista = lista.Where(x => x.Disponibilidad == true).ToList();
            }
            else if (filtro == "No disponibles")
            {
                lista = lista.Where(x => x.Disponibilidad == false).ToList();
            }

            dataGrid_Chofer2.DataSource = lista;
        }

        private void btn_buscarCH_Click(object sender, EventArgs e)
        {

        }

        private void dataGrid_Chofer2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGrid_Chofer2.Rows[e.RowIndex];

                idChoferSeleccionado = Convert.ToInt32(fila.Cells["IdChofer"].Value);

                txt_NombreCh.Text = fila.Cells["Nombre"].Value.ToString();
                txt_ApPaternoCh.Text = fila.Cells["ApPaterno"].Value.ToString();
                txt_ApMaternoCh.Text = fila.Cells["ApMaterno"].Value.ToString();
                num_TelefonoCH.Value = Convert.ToDecimal(fila.Cells["Telefono"].Value);
                num_LicenciaCh.Value = Convert.ToDecimal(fila.Cells["Licencia"].Value);
                txt_UrlFotosCH.Text = fila.Cells["UrlFoto"].Value.ToString();
                chk_DisponibilidadChofer.Checked = Convert.ToBoolean(fila.Cells["Disponibilidad"].Value);
            }
        }

        private void btn_nuevoCh_Click(object sender, EventArgs e)
        {
            idChoferSeleccionado = 0;

            txt_NombreCh.Text = "";
            txt_ApPaternoCh.Text = "";
            txt_ApMaternoCh.Text = "";
            num_TelefonoCH.Value = 0;
            num_LicenciaCh.Value = 0;
            txt_UrlFotosCH.Text = "";
            chk_DisponibilidadChofer.Checked = true;
        }

        private void btn_guardarCh_Click(object sender, EventArgs e)
        {
            E_Chofer chofer = new E_Chofer()
            {
                Nombre = txt_NombreCh.Text,
                ApPaterno = txt_ApPaternoCh.Text,
                ApMaterno = txt_ApMaternoCh.Text,
                Telefono = num_TelefonoCH.Value.ToString(),
                FechaNacimiento = date_FechaNacimientoCh.Value,
                Licencia = num_LicenciaCh.Value.ToString(),
                UrlFoto = txt_UrlFotosCH.Text,
                Disponibilidad = chk_DisponibilidadChofer.Checked
            };

            string respuesta = objNegocio.InsertarChofer(chofer);

            if (respuesta == "OK")
            {
                MessageBox.Show("Chofer guardado correctamente");
                CargarChoferes();
                cmbFiltro_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show(respuesta);
            }
        }

        private void btn_modificarCh_Click(object sender, EventArgs e)
        {
            if (idChoferSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            E_Chofer chofer = new E_Chofer()
            {
                IdChofer = idChoferSeleccionado,
                Nombre = txt_NombreCh.Text,
                ApPaterno = txt_ApPaternoCh.Text,
                ApMaterno = txt_ApMaternoCh.Text,
                Telefono = num_TelefonoCH.Value.ToString(),
                FechaNacimiento = date_FechaNacimientoCh.Value,
                Licencia = num_LicenciaCh.Value.ToString(),
                UrlFoto = txt_UrlFotosCH.Text,
                Disponibilidad = chk_DisponibilidadChofer.Checked
            };

            string respuesta = objNegocio.ActializarChofer(chofer);

            if (respuesta == "OK")
            {
                MessageBox.Show("Chofer actualizado");
                CargarChoferes();
                cmbFiltro_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show(respuesta);
            }
        }

        private void btn_eliminarCh_Click(object sender, EventArgs e)
        {
            if (idChoferSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            var confirm = MessageBox.Show("¿Eliminar chofer?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                string respuesta = objNegocio.EliminarChofer(idChoferSeleccionado);

                if (respuesta == "OK")
                {
                    MessageBox.Show("Eliminado correctamente");
                    CargarChoferes();
                    cmbFiltro_SelectedIndexChanged(null, null);
                }
                else
                {
                    MessageBox.Show(respuesta);
                }
            }
        }

        private void btn_cancelarCh_Click(object sender, EventArgs e)
        {
            btn_nuevoCh_Click(null, null);
        }

        private void CargarChoferes()
        {
            dataGrid_Chofer2.DataSource = objNegocio.ListarChoferes();
        }

        private void dataGrid_Chofer2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
