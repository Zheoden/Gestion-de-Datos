namespace PalcoNet.Generar_Publicacion
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpEspectaculo = new System.Windows.Forms.DateTimePicker();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbDireccion = new System.Windows.Forms.ComboBox();
            this.btnEliminarDire = new System.Windows.Forms.Button();
            this.btnAgregarDire = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUsuarioResponsable = new System.Windows.Forms.TextBox();
            this.cmbGrado = new System.Windows.Forms.ComboBox();
            this.cmbFechaEspectaculo = new System.Windows.Forms.ComboBox();
            this.btnAgregarFecha = new System.Windows.Forms.Button();
            this.btnSacarFecha = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(221, 418);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(128, 51);
            this.btnCerrar.TabIndex = 110;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(115, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(168, 50);
            this.pictureBox2.TabIndex = 43;
            this.pictureBox2.TabStop = false;
            // 
            // btnAlta
            // 
            this.btnAlta.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAlta.Location = new System.Drawing.Point(89, 418);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(128, 51);
            this.btnAlta.TabIndex = 100;
            this.btnAlta.Text = "Confirmar Publicacion";
            this.btnAlta.UseVisualStyleBackColor = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 26);
            this.label2.TabIndex = 40;
            this.label2.Text = "Generar Publicacion";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSacarFecha);
            this.groupBox2.Controls.Add(this.btnAgregarFecha);
            this.groupBox2.Controls.Add(this.cmbFechaEspectaculo);
            this.groupBox2.Controls.Add(this.dtpEspectaculo);
            this.groupBox2.Controls.Add(this.cmbGrado);
            this.groupBox2.Controls.Add(this.txtUsuarioResponsable);
            this.groupBox2.Controls.Add(this.cmbEstado);
            this.groupBox2.Controls.Add(this.cmbDireccion);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnEliminarDire);
            this.groupBox2.Controls.Add(this.btnAgregarDire);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtRubro);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPrecio);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtStock);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtDescripcion);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(11, 104);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(434, 299);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles de la Publicacion";
            // 
            // dtpEspectaculo
            // 
            this.dtpEspectaculo.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpEspectaculo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEspectaculo.Location = new System.Drawing.Point(143, 88);
            this.dtpEspectaculo.Name = "dtpEspectaculo";
            this.dtpEspectaculo.Size = new System.Drawing.Size(231, 20);
            this.dtpEspectaculo.TabIndex = 30;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownHeight = 100;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.DropDownWidth = 100;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.IntegralHeight = false;
            this.cmbEstado.Location = new System.Drawing.Point(143, 269);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(231, 21);
            this.cmbEstado.TabIndex = 90;
            // 
            // cmbDireccion
            // 
            this.cmbDireccion.DropDownHeight = 500;
            this.cmbDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDireccion.DropDownWidth = 800;
            this.cmbDireccion.FormattingEnabled = true;
            this.cmbDireccion.IntegralHeight = false;
            this.cmbDireccion.Location = new System.Drawing.Point(143, 194);
            this.cmbDireccion.Name = "cmbDireccion";
            this.cmbDireccion.Size = new System.Drawing.Size(231, 21);
            this.cmbDireccion.TabIndex = 60;
            // 
            // btnEliminarDire
            // 
            this.btnEliminarDire.Location = new System.Drawing.Point(404, 194);
            this.btnEliminarDire.Name = "btnEliminarDire";
            this.btnEliminarDire.Size = new System.Drawing.Size(20, 20);
            this.btnEliminarDire.TabIndex = 29;
            this.btnEliminarDire.Text = "-";
            this.btnEliminarDire.UseVisualStyleBackColor = true;
            this.btnEliminarDire.Click += new System.EventHandler(this.btnEliminarDire_Click);
            // 
            // btnAgregarDire
            // 
            this.btnAgregarDire.Location = new System.Drawing.Point(378, 194);
            this.btnAgregarDire.Name = "btnAgregarDire";
            this.btnAgregarDire.Size = new System.Drawing.Size(20, 20);
            this.btnAgregarDire.TabIndex = 27;
            this.btnAgregarDire.Text = "+";
            this.btnAgregarDire.UseVisualStyleBackColor = true;
            this.btnAgregarDire.Click += new System.EventHandler(this.btnAgregarDire_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Estado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Usuario responsable:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Direccion:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Grado:";
            // 
            // txtRubro
            // 
            this.txtRubro.Location = new System.Drawing.Point(143, 166);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(231, 20);
            this.txtRubro.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Rubro:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(143, 140);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(231, 20);
            this.txtPrecio.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Precio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Fecha del Espectaculo:";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(143, 62);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(231, 20);
            this.txtStock.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Stock:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(143, 36);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(231, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Descripcion:";
            // 
            // txtUsuarioResponsable
            // 
            this.txtUsuarioResponsable.Location = new System.Drawing.Point(143, 244);
            this.txtUsuarioResponsable.Name = "txtUsuarioResponsable";
            this.txtUsuarioResponsable.ReadOnly = true;
            this.txtUsuarioResponsable.Size = new System.Drawing.Size(231, 20);
            this.txtUsuarioResponsable.TabIndex = 80;
            // 
            // cmbGrado
            // 
            this.cmbGrado.DropDownHeight = 500;
            this.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrado.DropDownWidth = 800;
            this.cmbGrado.FormattingEnabled = true;
            this.cmbGrado.IntegralHeight = false;
            this.cmbGrado.Location = new System.Drawing.Point(143, 220);
            this.cmbGrado.Name = "cmbGrado";
            this.cmbGrado.Size = new System.Drawing.Size(231, 21);
            this.cmbGrado.TabIndex = 91;
            // 
            // cmbFechaEspectaculo
            // 
            this.cmbFechaEspectaculo.DropDownHeight = 500;
            this.cmbFechaEspectaculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFechaEspectaculo.DropDownWidth = 800;
            this.cmbFechaEspectaculo.FormattingEnabled = true;
            this.cmbFechaEspectaculo.IntegralHeight = false;
            this.cmbFechaEspectaculo.Location = new System.Drawing.Point(143, 113);
            this.cmbFechaEspectaculo.Name = "cmbFechaEspectaculo";
            this.cmbFechaEspectaculo.Size = new System.Drawing.Size(231, 21);
            this.cmbFechaEspectaculo.TabIndex = 92;
            // 
            // btnAgregarFecha
            // 
            this.btnAgregarFecha.Location = new System.Drawing.Point(378, 97);
            this.btnAgregarFecha.Name = "btnAgregarFecha";
            this.btnAgregarFecha.Size = new System.Drawing.Size(20, 20);
            this.btnAgregarFecha.TabIndex = 93;
            this.btnAgregarFecha.Text = "+";
            this.btnAgregarFecha.UseVisualStyleBackColor = true;
            this.btnAgregarFecha.Click += new System.EventHandler(this.btnAgregarFecha_Click);
            // 
            // btnSacarFecha
            // 
            this.btnSacarFecha.Location = new System.Drawing.Point(404, 97);
            this.btnSacarFecha.Name = "btnSacarFecha";
            this.btnSacarFecha.Size = new System.Drawing.Size(20, 20);
            this.btnSacarFecha.TabIndex = 94;
            this.btnSacarFecha.Text = "-";
            this.btnSacarFecha.UseVisualStyleBackColor = true;
            this.btnSacarFecha.Click += new System.EventHandler(this.btnSacarFecha_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 484);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Generar Publicacion";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cmbEstado;
        public System.Windows.Forms.ComboBox cmbDireccion;
        private System.Windows.Forms.Button btnEliminarDire;
        private System.Windows.Forms.Button btnAgregarDire;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRubro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpEspectaculo;
        private System.Windows.Forms.TextBox txtUsuarioResponsable;
        public System.Windows.Forms.ComboBox cmbGrado;
        private System.Windows.Forms.Button btnSacarFecha;
        private System.Windows.Forms.Button btnAgregarFecha;
        public System.Windows.Forms.ComboBox cmbFechaEspectaculo;
    }
}