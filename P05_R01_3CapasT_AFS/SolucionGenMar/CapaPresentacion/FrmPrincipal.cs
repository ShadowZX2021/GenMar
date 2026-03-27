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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void gestionDeChoferesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChoferes frm = new FrmChoferes();
            frm.Show(); // abrir normal, no modal
        }

        private void gestionDeCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCamiones frm = new FrmCamiones();
            frm.Show(); // abrir normal, no modal
        }

        private void gestionDeRutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRutas frm = new FrmRutas();
            frm.Show(); // abrir normal, no modal
        }

        private void salidaDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }


    }
}
