namespace CapaPresentacion
{
    partial class FrmChoferes
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
            this.label6 = new System.Windows.Forms.Label();
            this.chk_DisponibilidadChofer = new System.Windows.Forms.CheckBox();
            this.num_LicenciaCh = new System.Windows.Forms.NumericUpDown();
            this.num_TelefonoCH = new System.Windows.Forms.NumericUpDown();
            this.lts_FiltarporCh = new System.Windows.Forms.ComboBox();
            this.txt_UrlFotosCH = new System.Windows.Forms.TextBox();
            this.txt_NombreCh = new System.Windows.Forms.TextBox();
            this.btn_guardarCh = new System.Windows.Forms.Button();
            this.btn_modificarCh = new System.Windows.Forms.Button();
            this.btn_eliminarCh = new System.Windows.Forms.Button();
            this.btn_cancelarCh = new System.Windows.Forms.Button();
            this.btn_buscarCH = new System.Windows.Forms.Button();
            this.btn_nuevoCh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_ApMaternoCh = new System.Windows.Forms.TextBox();
            this.txt_ApPaternoCh = new System.Windows.Forms.TextBox();
            this.date_FechaNacimientoCh = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGrid_Chofer2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.num_LicenciaCh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_TelefonoCH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Chofer2)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1458, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Filtrar por";
            // 
            // chk_DisponibilidadChofer
            // 
            this.chk_DisponibilidadChofer.AutoSize = true;
            this.chk_DisponibilidadChofer.Location = new System.Drawing.Point(59, 366);
            this.chk_DisponibilidadChofer.Name = "chk_DisponibilidadChofer";
            this.chk_DisponibilidadChofer.Size = new System.Drawing.Size(133, 24);
            this.chk_DisponibilidadChofer.TabIndex = 47;
            this.chk_DisponibilidadChofer.Text = "Disponibilidad";
            this.chk_DisponibilidadChofer.UseVisualStyleBackColor = true;
            this.chk_DisponibilidadChofer.CheckedChanged += new System.EventHandler(this.chk_DisponibilidadChofer_CheckedChanged);
            // 
            // num_LicenciaCh
            // 
            this.num_LicenciaCh.Location = new System.Drawing.Point(216, 246);
            this.num_LicenciaCh.Name = "num_LicenciaCh";
            this.num_LicenciaCh.Size = new System.Drawing.Size(120, 26);
            this.num_LicenciaCh.TabIndex = 46;
            this.num_LicenciaCh.ValueChanged += new System.EventHandler(this.num_LicenciaCh_ValueChanged);
            // 
            // num_TelefonoCH
            // 
            this.num_TelefonoCH.Location = new System.Drawing.Point(216, 165);
            this.num_TelefonoCH.Name = "num_TelefonoCH";
            this.num_TelefonoCH.Size = new System.Drawing.Size(120, 26);
            this.num_TelefonoCH.TabIndex = 45;
            this.num_TelefonoCH.ValueChanged += new System.EventHandler(this.num_TelefonoCH_ValueChanged);
            // 
            // lts_FiltarporCh
            // 
            this.lts_FiltarporCh.FormattingEnabled = true;
            this.lts_FiltarporCh.Location = new System.Drawing.Point(1598, 209);
            this.lts_FiltarporCh.Name = "lts_FiltarporCh";
            this.lts_FiltarporCh.Size = new System.Drawing.Size(121, 28);
            this.lts_FiltarporCh.TabIndex = 42;
            this.lts_FiltarporCh.SelectedIndexChanged += new System.EventHandler(this.lts_FiltarporCh_SelectedIndexChanged);
            // 
            // txt_UrlFotosCH
            // 
            this.txt_UrlFotosCH.Location = new System.Drawing.Point(216, 284);
            this.txt_UrlFotosCH.Name = "txt_UrlFotosCH";
            this.txt_UrlFotosCH.Size = new System.Drawing.Size(123, 26);
            this.txt_UrlFotosCH.TabIndex = 40;
            this.txt_UrlFotosCH.TextChanged += new System.EventHandler(this.txt_UrlFotosCH_TextChanged);
            // 
            // txt_NombreCh
            // 
            this.txt_NombreCh.Location = new System.Drawing.Point(216, 39);
            this.txt_NombreCh.Name = "txt_NombreCh";
            this.txt_NombreCh.Size = new System.Drawing.Size(123, 26);
            this.txt_NombreCh.TabIndex = 38;
            this.txt_NombreCh.TextChanged += new System.EventHandler(this.txt_NombreCh_TextChanged);
            // 
            // btn_guardarCh
            // 
            this.btn_guardarCh.Location = new System.Drawing.Point(203, 441);
            this.btn_guardarCh.Name = "btn_guardarCh";
            this.btn_guardarCh.Size = new System.Drawing.Size(75, 35);
            this.btn_guardarCh.TabIndex = 37;
            this.btn_guardarCh.Text = "Guardar";
            this.btn_guardarCh.UseVisualStyleBackColor = true;
            this.btn_guardarCh.Click += new System.EventHandler(this.btn_guardarCh_Click);
            // 
            // btn_modificarCh
            // 
            this.btn_modificarCh.Location = new System.Drawing.Point(303, 441);
            this.btn_modificarCh.Name = "btn_modificarCh";
            this.btn_modificarCh.Size = new System.Drawing.Size(86, 35);
            this.btn_modificarCh.TabIndex = 36;
            this.btn_modificarCh.Text = "Modificar";
            this.btn_modificarCh.UseVisualStyleBackColor = true;
            this.btn_modificarCh.Click += new System.EventHandler(this.btn_modificarCh_Click);
            // 
            // btn_eliminarCh
            // 
            this.btn_eliminarCh.Location = new System.Drawing.Point(409, 441);
            this.btn_eliminarCh.Name = "btn_eliminarCh";
            this.btn_eliminarCh.Size = new System.Drawing.Size(75, 35);
            this.btn_eliminarCh.TabIndex = 35;
            this.btn_eliminarCh.Text = "Eliminar";
            this.btn_eliminarCh.UseVisualStyleBackColor = true;
            this.btn_eliminarCh.Click += new System.EventHandler(this.btn_eliminarCh_Click);
            // 
            // btn_cancelarCh
            // 
            this.btn_cancelarCh.Location = new System.Drawing.Point(506, 441);
            this.btn_cancelarCh.Name = "btn_cancelarCh";
            this.btn_cancelarCh.Size = new System.Drawing.Size(75, 35);
            this.btn_cancelarCh.TabIndex = 34;
            this.btn_cancelarCh.Text = "Cancelar";
            this.btn_cancelarCh.UseVisualStyleBackColor = true;
            this.btn_cancelarCh.Click += new System.EventHandler(this.btn_cancelarCh_Click);
            // 
            // btn_buscarCH
            // 
            this.btn_buscarCH.Location = new System.Drawing.Point(1644, 253);
            this.btn_buscarCH.Name = "btn_buscarCH";
            this.btn_buscarCH.Size = new System.Drawing.Size(75, 35);
            this.btn_buscarCH.TabIndex = 33;
            this.btn_buscarCH.Text = "Buscar";
            this.btn_buscarCH.UseVisualStyleBackColor = true;
            this.btn_buscarCH.Click += new System.EventHandler(this.btn_buscarCH_Click);
            // 
            // btn_nuevoCh
            // 
            this.btn_nuevoCh.Location = new System.Drawing.Point(98, 441);
            this.btn_nuevoCh.Name = "btn_nuevoCh";
            this.btn_nuevoCh.Size = new System.Drawing.Size(75, 35);
            this.btn_nuevoCh.TabIndex = 32;
            this.btn_nuevoCh.Text = "Nuevo";
            this.btn_nuevoCh.UseVisualStyleBackColor = true;
            this.btn_nuevoCh.Click += new System.EventHandler(this.btn_nuevoCh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Licencia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "URL Foto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Telefono";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nombre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 20);
            this.label9.TabIndex = 49;
            this.label9.Text = "Apellido Materno";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(55, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 20);
            this.label10.TabIndex = 50;
            this.label10.Text = "Apellido Paterno";
            // 
            // txt_ApMaternoCh
            // 
            this.txt_ApMaternoCh.Location = new System.Drawing.Point(216, 126);
            this.txt_ApMaternoCh.Name = "txt_ApMaternoCh";
            this.txt_ApMaternoCh.Size = new System.Drawing.Size(123, 26);
            this.txt_ApMaternoCh.TabIndex = 51;
            this.txt_ApMaternoCh.TextChanged += new System.EventHandler(this.txt_ApMaterno_TextChanged);
            // 
            // txt_ApPaternoCh
            // 
            this.txt_ApPaternoCh.Location = new System.Drawing.Point(216, 84);
            this.txt_ApPaternoCh.Name = "txt_ApPaternoCh";
            this.txt_ApPaternoCh.Size = new System.Drawing.Size(123, 26);
            this.txt_ApPaternoCh.TabIndex = 52;
            this.txt_ApPaternoCh.TextChanged += new System.EventHandler(this.txt_ApPaternoCh_TextChanged);
            // 
            // date_FechaNacimientoCh
            // 
            this.date_FechaNacimientoCh.Location = new System.Drawing.Point(216, 207);
            this.date_FechaNacimientoCh.Name = "date_FechaNacimientoCh";
            this.date_FechaNacimientoCh.Size = new System.Drawing.Size(200, 26);
            this.date_FechaNacimientoCh.TabIndex = 54;
            this.date_FechaNacimientoCh.ValueChanged += new System.EventHandler(this.date_FechaNacimientoCh_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(55, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 20);
            this.label11.TabIndex = 55;
            this.label11.Text = "Fecha de nacimiento";
            // 
            // dataGrid_Chofer2
            // 
            this.dataGrid_Chofer2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Chofer2.Location = new System.Drawing.Point(706, 12);
            this.dataGrid_Chofer2.Name = "dataGrid_Chofer2";
            this.dataGrid_Chofer2.RowHeadersWidth = 62;
            this.dataGrid_Chofer2.RowTemplate.Height = 28;
            this.dataGrid_Chofer2.Size = new System.Drawing.Size(1013, 162);
            this.dataGrid_Chofer2.TabIndex = 43;
            this.dataGrid_Chofer2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Chofer2_CellContentClick);
            this.dataGrid_Chofer2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Chofer2_CellContentClick);
            // 
            // FrmChoferes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1742, 515);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.date_FechaNacimientoCh);
            this.Controls.Add(this.txt_ApPaternoCh);
            this.Controls.Add(this.txt_ApMaternoCh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chk_DisponibilidadChofer);
            this.Controls.Add(this.num_LicenciaCh);
            this.Controls.Add(this.num_TelefonoCH);
            this.Controls.Add(this.dataGrid_Chofer2);
            this.Controls.Add(this.lts_FiltarporCh);
            this.Controls.Add(this.txt_UrlFotosCH);
            this.Controls.Add(this.txt_NombreCh);
            this.Controls.Add(this.btn_guardarCh);
            this.Controls.Add(this.btn_modificarCh);
            this.Controls.Add(this.btn_eliminarCh);
            this.Controls.Add(this.btn_cancelarCh);
            this.Controls.Add(this.btn_buscarCH);
            this.Controls.Add(this.btn_nuevoCh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmChoferes";
            this.Text = "Gestion Choferes";
            this.Load += new System.EventHandler(this.FrmChoferes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_LicenciaCh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_TelefonoCH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Chofer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk_DisponibilidadChofer;
        private System.Windows.Forms.NumericUpDown num_LicenciaCh;
        private System.Windows.Forms.NumericUpDown num_TelefonoCH;
        private System.Windows.Forms.ComboBox lts_FiltarporCh;
        private System.Windows.Forms.TextBox txt_UrlFotosCH;
        private System.Windows.Forms.TextBox txt_NombreCh;
        private System.Windows.Forms.Button btn_guardarCh;
        private System.Windows.Forms.Button btn_modificarCh;
        private System.Windows.Forms.Button btn_eliminarCh;
        private System.Windows.Forms.Button btn_cancelarCh;
        private System.Windows.Forms.Button btn_buscarCH;
        private System.Windows.Forms.Button btn_nuevoCh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_ApMaternoCh;
        private System.Windows.Forms.TextBox txt_ApPaternoCh;
        private System.Windows.Forms.DateTimePicker date_FechaNacimientoCh;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGrid_Chofer2;
    }
}