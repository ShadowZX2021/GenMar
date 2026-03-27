namespace CapaPresentacion
{
    partial class FrmRutas
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
            this.kilometraje_rt = new System.Windows.Forms.NumericUpDown();
            this.distancia_rt = new System.Windows.Forms.NumericUpDown();
            this.Grid_ruta = new System.Windows.Forms.DataGridView();
            this.filtro_atiempo = new System.Windows.Forms.ComboBox();
            this.text_Origen = new System.Windows.Forms.TextBox();
            this.guardar_rt = new System.Windows.Forms.Button();
            this.modificar_rt = new System.Windows.Forms.Button();
            this.eliminar_rt = new System.Windows.Forms.Button();
            this.cancelar_rt = new System.Windows.Forms.Button();
            this.buscar_rt = new System.Windows.Forms.Button();
            this.nuevo_rt = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_Atiempo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.fch_llegada = new System.Windows.Forms.DateTimePicker();
            this.fch_salida = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.tex_Destino = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCamion = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbChofer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kilometraje_rt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distancia_rt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_ruta)).BeginInit();
            this.SuspendLayout();
            // 
            // kilometraje_rt
            // 
            this.kilometraje_rt.Location = new System.Drawing.Point(184, 330);
            this.kilometraje_rt.Name = "kilometraje_rt";
            this.kilometraje_rt.Size = new System.Drawing.Size(120, 26);
            this.kilometraje_rt.TabIndex = 45;
            this.kilometraje_rt.ValueChanged += new System.EventHandler(this.kilometraje_rt_ValueChanged);
            // 
            // distancia_rt
            // 
            this.distancia_rt.Location = new System.Drawing.Point(184, 289);
            this.distancia_rt.Name = "distancia_rt";
            this.distancia_rt.Size = new System.Drawing.Size(120, 26);
            this.distancia_rt.TabIndex = 44;
            this.distancia_rt.ValueChanged += new System.EventHandler(this.distancia_rt_ValueChanged);
            // 
            // Grid_ruta
            // 
            this.Grid_ruta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_ruta.Location = new System.Drawing.Point(611, 27);
            this.Grid_ruta.Name = "Grid_ruta";
            this.Grid_ruta.RowHeadersWidth = 62;
            this.Grid_ruta.RowTemplate.Height = 28;
            this.Grid_ruta.Size = new System.Drawing.Size(794, 188);
            this.Grid_ruta.TabIndex = 42;
            this.Grid_ruta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_ruta_CellContentClick);
            this.Grid_ruta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_ruta_CellContentClick);
            // 
            // filtro_atiempo
            // 
            this.filtro_atiempo.FormattingEnabled = true;
            this.filtro_atiempo.Location = new System.Drawing.Point(1284, 238);
            this.filtro_atiempo.Name = "filtro_atiempo";
            this.filtro_atiempo.Size = new System.Drawing.Size(121, 28);
            this.filtro_atiempo.TabIndex = 41;
            this.filtro_atiempo.SelectedIndexChanged += new System.EventHandler(this.filtro_atiempo_SelectedIndexChanged);
            // 
            // text_Origen
            // 
            this.text_Origen.Location = new System.Drawing.Point(184, 103);
            this.text_Origen.Name = "text_Origen";
            this.text_Origen.Size = new System.Drawing.Size(123, 26);
            this.text_Origen.TabIndex = 37;
            this.text_Origen.TextChanged += new System.EventHandler(this.text_Origen_TextChanged);
            // 
            // guardar_rt
            // 
            this.guardar_rt.Location = new System.Drawing.Point(184, 449);
            this.guardar_rt.Name = "guardar_rt";
            this.guardar_rt.Size = new System.Drawing.Size(75, 35);
            this.guardar_rt.TabIndex = 36;
            this.guardar_rt.Text = "Guardar";
            this.guardar_rt.UseVisualStyleBackColor = true;
            this.guardar_rt.Click += new System.EventHandler(this.guardar_rt_Click);
            // 
            // modificar_rt
            // 
            this.modificar_rt.Location = new System.Drawing.Point(284, 449);
            this.modificar_rt.Name = "modificar_rt";
            this.modificar_rt.Size = new System.Drawing.Size(75, 35);
            this.modificar_rt.TabIndex = 35;
            this.modificar_rt.Text = "Modificar";
            this.modificar_rt.UseVisualStyleBackColor = true;
            this.modificar_rt.Click += new System.EventHandler(this.modificar_rt_Click);
            // 
            // eliminar_rt
            // 
            this.eliminar_rt.Location = new System.Drawing.Point(390, 449);
            this.eliminar_rt.Name = "eliminar_rt";
            this.eliminar_rt.Size = new System.Drawing.Size(75, 35);
            this.eliminar_rt.TabIndex = 34;
            this.eliminar_rt.Text = "Eliminar";
            this.eliminar_rt.UseVisualStyleBackColor = true;
            this.eliminar_rt.Click += new System.EventHandler(this.eliminar_rt_Click);
            // 
            // cancelar_rt
            // 
            this.cancelar_rt.Location = new System.Drawing.Point(487, 449);
            this.cancelar_rt.Name = "cancelar_rt";
            this.cancelar_rt.Size = new System.Drawing.Size(75, 35);
            this.cancelar_rt.TabIndex = 33;
            this.cancelar_rt.Text = "Cancelar";
            this.cancelar_rt.UseVisualStyleBackColor = true;
            this.cancelar_rt.Click += new System.EventHandler(this.cancelar_rt_Click);
            // 
            // buscar_rt
            // 
            this.buscar_rt.Location = new System.Drawing.Point(1330, 290);
            this.buscar_rt.Name = "buscar_rt";
            this.buscar_rt.Size = new System.Drawing.Size(75, 35);
            this.buscar_rt.TabIndex = 32;
            this.buscar_rt.Text = "Buscar";
            this.buscar_rt.UseVisualStyleBackColor = true;
            this.buscar_rt.Click += new System.EventHandler(this.buscar_rt_Click);
            // 
            // nuevo_rt
            // 
            this.nuevo_rt.Location = new System.Drawing.Point(79, 449);
            this.nuevo_rt.Name = "nuevo_rt";
            this.nuevo_rt.Size = new System.Drawing.Size(75, 35);
            this.nuevo_rt.TabIndex = 31;
            this.nuevo_rt.Text = "Nuevo";
            this.nuevo_rt.UseVisualStyleBackColor = true;
            this.nuevo_rt.Click += new System.EventHandler(this.nuevo_rt_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "Kilometraje";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Fecha de salida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Distancia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Origen";
            // 
            // chk_Atiempo
            // 
            this.chk_Atiempo.AutoSize = true;
            this.chk_Atiempo.Location = new System.Drawing.Point(40, 377);
            this.chk_Atiempo.Name = "chk_Atiempo";
            this.chk_Atiempo.Size = new System.Drawing.Size(102, 24);
            this.chk_Atiempo.TabIndex = 46;
            this.chk_Atiempo.Text = "A Tiempo";
            this.chk_Atiempo.UseVisualStyleBackColor = true;
            this.chk_Atiempo.CheckedChanged += new System.EventHandler(this.chk_Atiempo_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1144, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 47;
            this.label6.Text = "Filtrar por";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "Fecha de llegada";
            // 
            // fch_llegada
            // 
            this.fch_llegada.Location = new System.Drawing.Point(184, 232);
            this.fch_llegada.Name = "fch_llegada";
            this.fch_llegada.Size = new System.Drawing.Size(200, 26);
            this.fch_llegada.TabIndex = 51;
            this.fch_llegada.ValueChanged += new System.EventHandler(this.fch_llegada_ValueChanged);
            // 
            // fch_salida
            // 
            this.fch_salida.Location = new System.Drawing.Point(184, 188);
            this.fch_salida.Name = "fch_salida";
            this.fch_salida.Size = new System.Drawing.Size(200, 26);
            this.fch_salida.TabIndex = 53;
            this.fch_salida.ValueChanged += new System.EventHandler(this.fch_salida_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Destino";
            // 
            // tex_Destino
            // 
            this.tex_Destino.Location = new System.Drawing.Point(184, 146);
            this.tex_Destino.Name = "tex_Destino";
            this.tex_Destino.Size = new System.Drawing.Size(123, 26);
            this.tex_Destino.TabIndex = 49;
            this.tex_Destino.TextChanged += new System.EventHandler(this.tex_Destino_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 59;
            this.label7.Text = "Camion";
            // 
            // cmbCamion
            // 
            this.cmbCamion.FormattingEnabled = true;
            this.cmbCamion.Location = new System.Drawing.Point(184, 12);
            this.cmbCamion.Name = "cmbCamion";
            this.cmbCamion.Size = new System.Drawing.Size(152, 28);
            this.cmbCamion.TabIndex = 60;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 20);
            this.label11.TabIndex = 61;
            this.label11.Text = "Chofer";
            // 
            // cmbChofer
            // 
            this.cmbChofer.FormattingEnabled = true;
            this.cmbChofer.Location = new System.Drawing.Point(184, 53);
            this.cmbChofer.Name = "cmbChofer";
            this.cmbChofer.Size = new System.Drawing.Size(152, 28);
            this.cmbChofer.TabIndex = 62;
            // 
            // FrmRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 531);
            this.Controls.Add(this.cmbChofer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbCamion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fch_salida);
            this.Controls.Add(this.fch_llegada);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tex_Destino);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chk_Atiempo);
            this.Controls.Add(this.kilometraje_rt);
            this.Controls.Add(this.distancia_rt);
            this.Controls.Add(this.Grid_ruta);
            this.Controls.Add(this.filtro_atiempo);
            this.Controls.Add(this.text_Origen);
            this.Controls.Add(this.guardar_rt);
            this.Controls.Add(this.modificar_rt);
            this.Controls.Add(this.eliminar_rt);
            this.Controls.Add(this.cancelar_rt);
            this.Controls.Add(this.buscar_rt);
            this.Controls.Add(this.nuevo_rt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmRutas";
            this.Text = "Rutas";
            this.Load += new System.EventHandler(this.FrmRutas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kilometraje_rt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distancia_rt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_ruta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown kilometraje_rt;
        private System.Windows.Forms.NumericUpDown distancia_rt;
        private System.Windows.Forms.DataGridView Grid_ruta;
        private System.Windows.Forms.ComboBox filtro_atiempo;
        private System.Windows.Forms.TextBox text_Origen;
        private System.Windows.Forms.Button guardar_rt;
        private System.Windows.Forms.Button modificar_rt;
        private System.Windows.Forms.Button eliminar_rt;
        private System.Windows.Forms.Button cancelar_rt;
        private System.Windows.Forms.Button buscar_rt;
        private System.Windows.Forms.Button nuevo_rt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_Atiempo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker fch_llegada;
        private System.Windows.Forms.DateTimePicker fch_salida;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tex_Destino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCamion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbChofer;
    }
}