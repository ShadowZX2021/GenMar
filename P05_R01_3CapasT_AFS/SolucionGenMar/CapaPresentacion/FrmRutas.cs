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
    public partial class FrmRutas : Form
    {
        N_Ruta objNegocio = new N_Ruta();
        int idRutaSeleccionada = 0;
        int idChoferSeleccionado = 0;
        int idCamionSeleccionado = 0;
        public FrmRutas()
        {
            InitializeComponent();
        }

        private void FrmRutas_Load(object sender, EventArgs e)
        {
            CargarRutas();
            CargarCombos();

            distancia_rt.Minimum = 0;
            distancia_rt.Maximum = 200000;
            distancia_rt.Value = 0;

            kilometraje_rt.Minimum = 0;
            kilometraje_rt.Maximum = 200000;
            kilometraje_rt.Value = 0;

            filtro_atiempo.Items.Add("Todos");
            filtro_atiempo.Items.Add("A tiempo");
            filtro_atiempo.Items.Add("Retrasado");

            filtro_atiempo.SelectedIndex = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tex_IdCART_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_Origen_TextChanged(object sender, EventArgs e)
        {

        }

        private void tex_Destino_TextChanged(object sender, EventArgs e)
        {

        }

        private void fch_salida_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fch_llegada_ValueChanged(object sender, EventArgs e)
        {

        }

        private void distancia_rt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void kilometraje_rt_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Grid_ruta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = Grid_ruta.Rows[e.RowIndex];

                idRutaSeleccionada = Convert.ToInt32(fila.Cells["IdRuta"].Value);
                idChoferSeleccionado = Convert.ToInt32(fila.Cells["IdChofer"].Value);
                idCamionSeleccionado = Convert.ToInt32(fila.Cells["IdCamion"].Value);

                text_Origen.Text = fila.Cells["Origen"].Value.ToString();
                tex_Destino.Text = fila.Cells["Destino"].Value.ToString();
                fch_salida.Value = Convert.ToDateTime(fila.Cells["FechaSalida"].Value);
                fch_llegada.Value = Convert.ToDateTime(fila.Cells["FechaLlegada"].Value);
                chk_Atiempo.Checked = Convert.ToBoolean(fila.Cells["ATiempo"].Value);
                distancia_rt.Value = Convert.ToDecimal(fila.Cells["Distancia"].Value);

                cmbChofer.SelectedValue = idChoferSeleccionado;
                cmbCamion.SelectedValue = idCamionSeleccionado;
            }
        }

        private void filtro_atiempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = filtro_atiempo.SelectedItem.ToString();

            var lista = objNegocio.ListarRutas();

            if (filtro == "A tiempo")
            {
                lista = lista.Where(x => x.ATiempo == true).ToList();
            }
            else if (filtro == "Retrasado")
            {
                lista = lista.Where(x => x.ATiempo == false).ToList();
            }

            Grid_ruta.DataSource = lista;
        }

        private void buscar_rt_Click(object sender, EventArgs e)
        {

        }

        private void cancelar_rt_Click(object sender, EventArgs e)
        {
            nuevo_rt_Click(null, null);
        }

        private void eliminar_rt_Click(object sender, EventArgs e)
        {
            if (idRutaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una ruta");
                return;
            }

            var confirm = MessageBox.Show("¿Eliminar ruta?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                string respuesta = objNegocio.EliminarRuta(
                    idRutaSeleccionada,
                    idChoferSeleccionado,
                    idCamionSeleccionado
                );

                if (respuesta == "OK")
                {
                    MessageBox.Show("Ruta eliminada");
                    CargarRutas();
                    filtro_atiempo_SelectedIndexChanged(null, null);
                }
                else
                {
                    MessageBox.Show(respuesta);
                }
            }
        }

        private void modificar_rt_Click(object sender, EventArgs e)
        {
            if (idRutaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una ruta");
                return;
            }

            E_Rutas ruta = new E_Rutas()
            {
                IdRuta = idRutaSeleccionada,
                IdChofer = idChoferSeleccionado,
                IdCamion = idCamionSeleccionado,
                Origen = text_Origen.Text,
                Destino = tex_Destino.Text,
                FechaSalida = fch_salida.Value,
                FechaLlegada = fch_llegada.Value,
                ATiempo = chk_Atiempo.Checked,
                Distancia = Convert.ToDouble(distancia_rt.Value)
            };

            string respuesta = objNegocio.ActualizarRuta(ruta);

            if (respuesta == "OK")
            {
                MessageBox.Show("Ruta actualizada");
                CargarRutas();
                filtro_atiempo_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show(respuesta);
            }
        }

        private void guardar_rt_Click(object sender, EventArgs e)
        {
            if (cmbChofer.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un chofer");
                return;
            }

            E_Rutas ruta = new E_Rutas()
            {
                IdChofer = Convert.ToInt32(cmbChofer.SelectedValue),
                IdCamion = Convert.ToInt32(cmbCamion.SelectedValue),
                Origen = text_Origen.Text,
                Destino = tex_Destino.Text,
                FechaSalida = fch_salida.Value,
                FechaLlegada = fch_llegada.Value,
                ATiempo = chk_Atiempo.Checked,
                Distancia = Convert.ToDouble(distancia_rt.Value),
                FechaRegistro = DateTime.Now
            };

            string respuesta = objNegocio.InsertarRuta(ruta);

            if (respuesta == "OK")
            {
                MessageBox.Show("Ruta guardada");
                CargarRutas();
                filtro_atiempo_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show(respuesta);
            }
        }

        private void nuevo_rt_Click(object sender, EventArgs e)
        {
            idRutaSeleccionada = 0;

            text_Origen.Text = "";
            tex_Destino.Text = "";
            distancia_rt.Value = 0;
            kilometraje_rt.Value = 0;
            chk_Atiempo.Checked = true;
            cmbChofer.SelectedIndex = -1;
            cmbCamion.SelectedIndex = -1;
        }

        private void chk_Atiempo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CargarRutas()
        {
            Grid_ruta.DataSource = objNegocio.ListarRutas();
        }

        private void CargarCombos()
        {
            N_Choferes nChofer = new N_Choferes();
            cmbChofer.DataSource = nChofer.ListarChoferes();
            cmbChofer.DisplayMember = "NombreCompleto";
            cmbChofer.ValueMember = "IdChofer";

            // Aquí deberías tener N_Camiones
            N_Camion nCamion = new N_Camion();
            cmbCamion.DataSource = nCamion.ListarCamiones();
            cmbCamion.DisplayMember = "Matricula";
            cmbCamion.ValueMember = "IdCamion";
        }
    }
}
