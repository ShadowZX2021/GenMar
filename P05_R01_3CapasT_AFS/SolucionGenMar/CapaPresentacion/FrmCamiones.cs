using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class FrmCamiones : Form
    {

        private N_Camion objNegocio = new N_Camion();
        private int idCamionSeleccionado = 0;

        public FrmCamiones()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGrid_Chofer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var camion = (E_Camion)dataGrid_Chofer.Rows[e.RowIndex].DataBoundItem;

                idCamionSeleccionado = camion.IdCamion;
                txt_matricula.Text = camion.Matricula;
                comboBox1.Text = camion.TipoCamion;
                num_Modelo.Value = camion.Modelo;
                txt_ApMaterno.Text = camion.Marca;
                num_capacidad.Value  = camion.Capacidad;
                num_Kilometraje.Value = (decimal)camion.Kilometraje;
                chk_DisponibilidadCh.Checked = camion.Disponibilidad;
            }
            
        }

        private void txt_matricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void num_Telefono_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_ApMaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void num_Licencia_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmCamiones_Load(object sender, EventArgs e)
        {
            CargarCamiones();
            CargarFiltroDisponibilidad();
            CargarTiposCamion();

            num_Modelo.Minimum = 1900;
            num_Modelo.Maximum = 9999;
            num_Modelo.Value = 2020;

            num_capacidad.Minimum = 0;
            num_capacidad.Maximum = 200000;
            num_capacidad.Value = 0;

            num_Kilometraje.Minimum = 0;
            num_Kilometraje.Maximum = 200000;
            num_Kilometraje.Value = 0;
        }

        private void lts_Filtarpor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lts_Filtarpor.SelectedValue == null) return;

            var valor = lts_Filtarpor.SelectedValue as bool?;
            CargarCamiones(valor);
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void chk_DisponibilidadCh_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            idCamionSeleccionado = 0;

            txt_matricula.Clear();
            comboBox1.SelectedIndex = -1;
            num_capacidad.Value = 0;
            txt_ApMaterno.Clear();
            num_Modelo.Value = 2026;
            num_Kilometraje.Value = 0;
            chk_DisponibilidadCh.Checked = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            E_Camion camion = new E_Camion()
            {
                Matricula = txt_matricula.Text,
                TipoCamion = comboBox1.Text,
                Modelo = (int)num_Modelo.Value,
                Marca = txt_ApMaterno.Text,
                Capacidad = (int)num_capacidad.Value,
                Kilometraje = (double)num_Kilometraje.Value,
                Disponibilidad = chk_DisponibilidadCh.Checked,
                UrlFoto = null
            };

            string respuesta = objNegocio.InsertarCamion(camion);

            MessageBox.Show(respuesta);

            if (respuesta == "OK") {
                
                AplicarFiltroActual();
            }
               
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (idCamionSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un registro");
                return;
            }

            E_Camion camion = new E_Camion()
            {
                IdCamion = idCamionSeleccionado,
                Matricula = txt_matricula.Text,
                TipoCamion = comboBox1.Text,
                Modelo = (int)num_Modelo.Value,
                Marca = txt_ApMaterno.Text,
                Capacidad = (int)num_capacidad.Value,
                Kilometraje = (double)num_Kilometraje.Value,
                Disponibilidad = chk_DisponibilidadCh.Checked
            };

            string respuesta = objNegocio.ActualizarCamion(camion);

            MessageBox.Show(respuesta);

            if (respuesta == "OK") {
               
                AplicarFiltroActual();
            }
                
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (idCamionSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un registro");
                return;
            }

            string respuesta = objNegocio.EliminarCamion(idCamionSeleccionado);

            MessageBox.Show(respuesta);

            if (respuesta == "OK") {

               
                AplicarFiltroActual();
            }


        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

        private void CargarCamiones(bool? disponibilidad = null)
        {
            try
            {
                dataGrid_Chofer.DataSource = null;
                dataGrid_Chofer.DataSource = objNegocio.ListarCamiones(disponibilidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarFiltroDisponibilidad()
        {
            var lista = new List<OpcionFiltro>()
            {
                new OpcionFiltro { Texto = "Todos", Valor = null },
                new OpcionFiltro { Texto = "Disponibles", Valor = true },
                new OpcionFiltro { Texto = "No disponibles", Valor = false }
            };

            lts_Filtarpor.DataSource = lista;
            lts_Filtarpor.DisplayMember = "Texto";
            lts_Filtarpor.ValueMember = "Valor";
        }

        private void comboBoxFiltroDisp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarTiposCamion()
        {
            comboBox1.Items.Clear();

            comboBox1.Items.Add("Torton");
            comboBox1.Items.Add("Rabón");
            comboBox1.Items.Add("Trailer");
            comboBox1.Items.Add("Camioneta");
            comboBox1.Items.Add("Volteo");
        }

        public class OpcionFiltro
        {
            public string Texto { get; set; }
            public bool? Valor { get; set; }
        }

        private void AplicarFiltroActual()
        {
            var valor = lts_Filtarpor.SelectedValue as bool?;
            CargarCamiones(valor);
        }
    }
}
