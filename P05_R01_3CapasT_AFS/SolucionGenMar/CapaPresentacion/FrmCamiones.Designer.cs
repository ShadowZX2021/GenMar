namespace CapaPresentacion
{
    partial class FrmCamiones
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
            this.label11 = new System.Windows.Forms.Label();
            this.txt_ApMaterno = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chk_DisponibilidadCh = new System.Windows.Forms.CheckBox();
            this.num_Kilometraje = new System.Windows.Forms.NumericUpDown();
            this.num_Modelo = new System.Windows.Forms.NumericUpDown();
            this.dataGrid_Chofer = new System.Windows.Forms.DataGridView();
            this.lts_Filtarpor = new System.Windows.Forms.ComboBox();
            this.txt_UrlFotos = new System.Windows.Forms.TextBox();
            this.txt_matricula = new System.Windows.Forms.TextBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.num_capacidad = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_Kilometraje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Modelo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Chofer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_capacidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(84, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 20);
            this.label11.TabIndex = 79;
            this.label11.Text = "Capacidad";
            // 
            // txt_ApMaterno
            // 
            this.txt_ApMaterno.Location = new System.Drawing.Point(242, 142);
            this.txt_ApMaterno.Name = "txt_ApMaterno";
            this.txt_ApMaterno.Size = new System.Drawing.Size(123, 26);
            this.txt_ApMaterno.TabIndex = 76;
            this.txt_ApMaterno.TextChanged += new System.EventHandler(this.txt_ApMaterno_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(84, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 20);
            this.label10.TabIndex = 75;
            this.label10.Text = "Tipo de camion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 74;
            this.label9.Text = "Modelo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(986, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 73;
            this.label6.Text = "Filtrar por";
            // 
            // chk_DisponibilidadCh
            // 
            this.chk_DisponibilidadCh.AutoSize = true;
            this.chk_DisponibilidadCh.Location = new System.Drawing.Point(88, 343);
            this.chk_DisponibilidadCh.Name = "chk_DisponibilidadCh";
            this.chk_DisponibilidadCh.Size = new System.Drawing.Size(133, 24);
            this.chk_DisponibilidadCh.TabIndex = 72;
            this.chk_DisponibilidadCh.Text = "Disponibilidad";
            this.chk_DisponibilidadCh.UseVisualStyleBackColor = true;
            this.chk_DisponibilidadCh.CheckedChanged += new System.EventHandler(this.chk_DisponibilidadCh_CheckedChanged);
            // 
            // num_Kilometraje
            // 
            this.num_Kilometraje.Location = new System.Drawing.Point(245, 223);
            this.num_Kilometraje.Name = "num_Kilometraje";
            this.num_Kilometraje.Size = new System.Drawing.Size(120, 26);
            this.num_Kilometraje.TabIndex = 71;
            this.num_Kilometraje.ValueChanged += new System.EventHandler(this.num_Licencia_ValueChanged);
            // 
            // num_Modelo
            // 
            this.num_Modelo.Location = new System.Drawing.Point(245, 103);
            this.num_Modelo.Name = "num_Modelo";
            this.num_Modelo.Size = new System.Drawing.Size(120, 26);
            this.num_Modelo.TabIndex = 70;
            this.num_Modelo.ValueChanged += new System.EventHandler(this.num_Telefono_ValueChanged);
            // 
            // dataGrid_Chofer
            // 
            this.dataGrid_Chofer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Chofer.Location = new System.Drawing.Point(574, 16);
            this.dataGrid_Chofer.Name = "dataGrid_Chofer";
            this.dataGrid_Chofer.RowHeadersWidth = 62;
            this.dataGrid_Chofer.RowTemplate.Height = 28;
            this.dataGrid_Chofer.Size = new System.Drawing.Size(673, 162);
            this.dataGrid_Chofer.TabIndex = 69;
            this.dataGrid_Chofer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Chofer_CellContentClick);
            this.dataGrid_Chofer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Chofer_CellContentClick);
            // 
            // lts_Filtarpor
            // 
            this.lts_Filtarpor.FormattingEnabled = true;
            this.lts_Filtarpor.Location = new System.Drawing.Point(1126, 200);
            this.lts_Filtarpor.Name = "lts_Filtarpor";
            this.lts_Filtarpor.Size = new System.Drawing.Size(121, 28);
            this.lts_Filtarpor.TabIndex = 68;
            this.lts_Filtarpor.SelectedIndexChanged += new System.EventHandler(this.lts_Filtarpor_SelectedIndexChanged);
            // 
            // txt_UrlFotos
            // 
            this.txt_UrlFotos.Location = new System.Drawing.Point(245, 261);
            this.txt_UrlFotos.Name = "txt_UrlFotos";
            this.txt_UrlFotos.Size = new System.Drawing.Size(123, 26);
            this.txt_UrlFotos.TabIndex = 67;
            // 
            // txt_matricula
            // 
            this.txt_matricula.Location = new System.Drawing.Point(245, 16);
            this.txt_matricula.Name = "txt_matricula";
            this.txt_matricula.Size = new System.Drawing.Size(123, 26);
            this.txt_matricula.TabIndex = 66;
            this.txt_matricula.TextChanged += new System.EventHandler(this.txt_matricula_TextChanged);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(232, 418);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 35);
            this.btn_guardar.TabIndex = 65;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Location = new System.Drawing.Point(332, 418);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(86, 35);
            this.btn_modificar.TabIndex = 64;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(438, 418);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 35);
            this.btn_eliminar.TabIndex = 63;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(535, 418);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 35);
            this.btn_cancelar.TabIndex = 62;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(1172, 244);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 35);
            this.btn_buscar.TabIndex = 61;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Location = new System.Drawing.Point(127, 418);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(75, 35);
            this.btn_nuevo.TabIndex = 60;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 59;
            this.label8.Text = "Kilometraje";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 58;
            this.label7.Text = "URL Foto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Marca";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(84, 22);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(73, 20);
            this.lb.TabIndex = 56;
            this.lb.Text = "Matricula";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(244, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 80;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // num_capacidad
            // 
            this.num_capacidad.Location = new System.Drawing.Point(245, 184);
            this.num_capacidad.Name = "num_capacidad";
            this.num_capacidad.Size = new System.Drawing.Size(120, 26);
            this.num_capacidad.TabIndex = 81;
            this.num_capacidad.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // FrmCamiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 469);
            this.Controls.Add(this.num_capacidad);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_ApMaterno);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chk_DisponibilidadCh);
            this.Controls.Add(this.num_Kilometraje);
            this.Controls.Add(this.num_Modelo);
            this.Controls.Add(this.dataGrid_Chofer);
            this.Controls.Add(this.lts_Filtarpor);
            this.Controls.Add(this.txt_UrlFotos);
            this.Controls.Add(this.txt_matricula);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb);
            this.Name = "FrmCamiones";
            this.Text = "FrmCamiones";
            this.Load += new System.EventHandler(this.FrmCamiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_Kilometraje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Modelo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Chofer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_capacidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_ApMaterno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk_DisponibilidadCh;
        private System.Windows.Forms.NumericUpDown num_Kilometraje;
        private System.Windows.Forms.NumericUpDown num_Modelo;
        private System.Windows.Forms.DataGridView dataGrid_Chofer;
        private System.Windows.Forms.ComboBox lts_Filtarpor;
        private System.Windows.Forms.TextBox txt_UrlFotos;
        private System.Windows.Forms.TextBox txt_matricula;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown num_capacidad;
    }
}