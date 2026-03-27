namespace CapaPresentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.choferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeChoferesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.camionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeCamionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeRutasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidaDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.choferToolStripMenuItem,
            this.camionesToolStripMenuItem,
            this.rutasToolStripMenuItem,
            this.salidaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // choferToolStripMenuItem
            // 
            this.choferToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeChoferesToolStripMenuItem});
            this.choferToolStripMenuItem.Name = "choferToolStripMenuItem";
            this.choferToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            this.choferToolStripMenuItem.Text = "Chofer";
            // 
            // gestionDeChoferesToolStripMenuItem
            // 
            this.gestionDeChoferesToolStripMenuItem.Name = "gestionDeChoferesToolStripMenuItem";
            this.gestionDeChoferesToolStripMenuItem.Size = new System.Drawing.Size(271, 34);
            this.gestionDeChoferesToolStripMenuItem.Text = "Gestion de choferes";
            this.gestionDeChoferesToolStripMenuItem.Click += new System.EventHandler(this.gestionDeChoferesToolStripMenuItem_Click);
            // 
            // camionesToolStripMenuItem
            // 
            this.camionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeCamionesToolStripMenuItem});
            this.camionesToolStripMenuItem.Name = "camionesToolStripMenuItem";
            this.camionesToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.camionesToolStripMenuItem.Text = "Camiones";
            // 
            // gestionDeCamionesToolStripMenuItem
            // 
            this.gestionDeCamionesToolStripMenuItem.Name = "gestionDeCamionesToolStripMenuItem";
            this.gestionDeCamionesToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.gestionDeCamionesToolStripMenuItem.Text = "Gestion de camiones";
            this.gestionDeCamionesToolStripMenuItem.Click += new System.EventHandler(this.gestionDeCamionesToolStripMenuItem_Click);
            // 
            // rutasToolStripMenuItem
            // 
            this.rutasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeRutasToolStripMenuItem});
            this.rutasToolStripMenuItem.Name = "rutasToolStripMenuItem";
            this.rutasToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.rutasToolStripMenuItem.Text = "Rutas";
            // 
            // gestionDeRutasToolStripMenuItem
            // 
            this.gestionDeRutasToolStripMenuItem.Name = "gestionDeRutasToolStripMenuItem";
            this.gestionDeRutasToolStripMenuItem.Size = new System.Drawing.Size(243, 34);
            this.gestionDeRutasToolStripMenuItem.Text = "Gestion de rutas";
            this.gestionDeRutasToolStripMenuItem.Click += new System.EventHandler(this.gestionDeRutasToolStripMenuItem_Click);
            // 
            // salidaToolStripMenuItem
            // 
            this.salidaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salidaDelSistemaToolStripMenuItem});
            this.salidaToolStripMenuItem.Name = "salidaToolStripMenuItem";
            this.salidaToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.salidaToolStripMenuItem.Text = "Salida";
            // 
            // salidaDelSistemaToolStripMenuItem
            // 
            this.salidaDelSistemaToolStripMenuItem.Name = "salidaDelSistemaToolStripMenuItem";
            this.salidaDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(255, 34);
            this.salidaDelSistemaToolStripMenuItem.Text = "Salida del sistema";
            this.salidaDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.salidaDelSistemaToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem choferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeChoferesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem camionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeCamionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rutasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeRutasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidaDelSistemaToolStripMenuItem;
    }
}