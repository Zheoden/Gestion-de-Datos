namespace PalcoNet.Abm_Grado
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvGrados = new System.Windows.Forms.DataGridView();
            this.grado_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grado_prioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grado_comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grado_porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDarAlta = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnActualizarVista = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPrioridad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_b_avanzada = new System.Windows.Forms.GroupBox();
            this.btnEliminarFiltro = new System.Windows.Forms.Button();
            this.lstFiltro = new System.Windows.Forms.ListBox();
            this.txtComision = new System.Windows.Forms.TextBox();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_busquedaAvanzada = new System.Windows.Forms.CheckBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gb_b_avanzada.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(480, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 50);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvGrados);
            this.groupBox3.Location = new System.Drawing.Point(10, 337);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(1112, 236);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información";
            // 
            // dgvGrados
            // 
            this.dgvGrados.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grado_id,
            this.grado_prioridad,
            this.grado_comision,
            this.grado_porcentaje});
            this.dgvGrados.Location = new System.Drawing.Point(4, 18);
            this.dgvGrados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGrados.Name = "dgvGrados";
            this.dgvGrados.RowTemplate.Height = 24;
            this.dgvGrados.Size = new System.Drawing.Size(1104, 213);
            this.dgvGrados.TabIndex = 0;
            // 
            // grado_id
            // 
            this.grado_id.HeaderText = "ID de Grado";
            this.grado_id.Name = "grado_id";
            this.grado_id.ReadOnly = true;
            // 
            // grado_prioridad
            // 
            this.grado_prioridad.HeaderText = "Prioridad";
            this.grado_prioridad.Name = "grado_prioridad";
            this.grado_prioridad.ReadOnly = true;
            // 
            // grado_comision
            // 
            this.grado_comision.HeaderText = "Comision";
            this.grado_comision.Name = "grado_comision";
            this.grado_comision.ReadOnly = true;
            // 
            // grado_porcentaje
            // 
            this.grado_porcentaje.HeaderText = "Porcentaje";
            this.grado_porcentaje.Name = "grado_porcentaje";
            // 
            // btnDarAlta
            // 
            this.btnDarAlta.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDarAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDarAlta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDarAlta.Location = new System.Drawing.Point(725, 578);
            this.btnDarAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btnDarAlta.Name = "btnDarAlta";
            this.btnDarAlta.Size = new System.Drawing.Size(128, 34);
            this.btnDarAlta.TabIndex = 27;
            this.btnDarAlta.Text = "Dar de Alta";
            this.btnDarAlta.UseVisualStyleBackColor = false;
            this.btnDarAlta.Click += new System.EventHandler(this.btnDarAlta_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Location = new System.Drawing.Point(857, 578);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(128, 34);
            this.btnModificar.TabIndex = 28;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkRed;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(990, 578);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(128, 34);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(10, 578);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(128, 34);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(990, 177);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(128, 34);
            this.btnLimpiar.TabIndex = 31;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizarVista
            // 
            this.btnActualizarVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarVista.Location = new System.Drawing.Point(990, 133);
            this.btnActualizarVista.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizarVista.Name = "btnActualizarVista";
            this.btnActualizarVista.Size = new System.Drawing.Size(128, 34);
            this.btnActualizarVista.TabIndex = 32;
            this.btnActualizarVista.Text = "Actualizar Vista";
            this.btnActualizarVista.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 26);
            this.label1.TabIndex = 25;
            this.label1.Text = "ABM Grado";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPrioridad);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.gb_b_avanzada);
            this.groupBox1.Controls.Add(this.cb_busquedaAvanzada);
            this.groupBox1.Location = new System.Drawing.Point(10, 113);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(976, 222);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de la Empresa";
            // 
            // txtPrioridad
            // 
            this.txtPrioridad.Location = new System.Drawing.Point(164, 29);
            this.txtPrioridad.Name = "txtPrioridad";
            this.txtPrioridad.Size = new System.Drawing.Size(231, 20);
            this.txtPrioridad.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Prioridad (Alta, Media, Baja):";
            // 
            // gb_b_avanzada
            // 
            this.gb_b_avanzada.Controls.Add(this.btnEliminarFiltro);
            this.gb_b_avanzada.Controls.Add(this.lstFiltro);
            this.gb_b_avanzada.Controls.Add(this.txtComision);
            this.gb_b_avanzada.Controls.Add(this.txtPorcentaje);
            this.gb_b_avanzada.Controls.Add(this.btnFiltro);
            this.gb_b_avanzada.Controls.Add(this.label3);
            this.gb_b_avanzada.Controls.Add(this.label2);
            this.gb_b_avanzada.Location = new System.Drawing.Point(4, 102);
            this.gb_b_avanzada.Margin = new System.Windows.Forms.Padding(2);
            this.gb_b_avanzada.Name = "gb_b_avanzada";
            this.gb_b_avanzada.Padding = new System.Windows.Forms.Padding(2);
            this.gb_b_avanzada.Size = new System.Drawing.Size(968, 113);
            this.gb_b_avanzada.TabIndex = 4;
            this.gb_b_avanzada.TabStop = false;
            this.gb_b_avanzada.Text = "Busqueda avanzada";
            // 
            // btnEliminarFiltro
            // 
            this.btnEliminarFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFiltro.Location = new System.Drawing.Point(406, 71);
            this.btnEliminarFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarFiltro.Name = "btnEliminarFiltro";
            this.btnEliminarFiltro.Size = new System.Drawing.Size(120, 27);
            this.btnEliminarFiltro.TabIndex = 8;
            this.btnEliminarFiltro.Text = "Eliminar Filtro";
            this.btnEliminarFiltro.UseVisualStyleBackColor = true;
            this.btnEliminarFiltro.Click += new System.EventHandler(this.btnEliminarFiltro_Click);
            // 
            // lstFiltro
            // 
            this.lstFiltro.FormattingEnabled = true;
            this.lstFiltro.Location = new System.Drawing.Point(586, 30);
            this.lstFiltro.Name = "lstFiltro";
            this.lstFiltro.Size = new System.Drawing.Size(316, 69);
            this.lstFiltro.TabIndex = 6;
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(96, 35);
            this.txtComision.Name = "txtComision";
            this.txtComision.Size = new System.Drawing.Size(209, 20);
            this.txtComision.TabIndex = 1;
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(96, 61);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(209, 20);
            this.txtPorcentaje.TabIndex = 1;
            // 
            // btnFiltro
            // 
            this.btnFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltro.Location = new System.Drawing.Point(406, 29);
            this.btnFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(120, 27);
            this.btnFiltro.TabIndex = 2;
            this.btnFiltro.Text = "Agregar filtro";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Comision:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Porcentaje:";
            // 
            // cb_busquedaAvanzada
            // 
            this.cb_busquedaAvanzada.AutoSize = true;
            this.cb_busquedaAvanzada.Location = new System.Drawing.Point(100, 81);
            this.cb_busquedaAvanzada.Margin = new System.Windows.Forms.Padding(2);
            this.cb_busquedaAvanzada.Name = "cb_busquedaAvanzada";
            this.cb_busquedaAvanzada.Size = new System.Drawing.Size(124, 17);
            this.cb_busquedaAvanzada.TabIndex = 4;
            this.cb_busquedaAvanzada.Text = "Busqueda avanzada";
            this.cb_busquedaAvanzada.UseVisualStyleBackColor = true;
            this.cb_busquedaAvanzada.CheckedChanged += new System.EventHandler(this.cb_busquedaAvanzada_CheckedChanged);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1142, 24);
            this.menu.TabIndex = 113;
            this.menu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 629);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDarAlta);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnActualizarVista);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "ABM Grado";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_b_avanzada.ResumeLayout(false);
            this.gb_b_avanzada.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvGrados;
        private System.Windows.Forms.Button btnDarAlta;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActualizarVista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPrioridad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gb_b_avanzada;
        private System.Windows.Forms.Button btnEliminarFiltro;
        private System.Windows.Forms.ListBox lstFiltro;
        private System.Windows.Forms.TextBox txtComision;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_busquedaAvanzada;
        private System.Windows.Forms.DataGridViewTextBoxColumn grado_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn grado_prioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn grado_comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn grado_porcentaje;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;

    }
}