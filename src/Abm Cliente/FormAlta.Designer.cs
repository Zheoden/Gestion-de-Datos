namespace PalcoNet.Abm_Cliente {
    partial class FormAlta {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlta));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTarjeta = new System.Windows.Forms.ComboBox();
            this.cmbDireccion = new System.Windows.Forms.ComboBox();
            this.btnAgregarTarj = new System.Windows.Forms.Button();
            this.btnEliminarDire = new System.Windows.Forms.Button();
            this.btnEliminarTarj = new System.Windows.Forms.Button();
            this.btnAgregarDire = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCuil = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(219, 418);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(128, 34);
            this.btnCerrar.TabIndex = 39;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(113, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(168, 50);
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // btnAlta
            // 
            this.btnAlta.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAlta.Location = new System.Drawing.Point(87, 418);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(128, 34);
            this.btnAlta.TabIndex = 37;
            this.btnAlta.Text = "ConfirmarAlta";
            this.btnAlta.UseVisualStyleBackColor = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 26);
            this.label2.TabIndex = 35;
            this.label2.Text = "Alta de Clientes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpFechaNac);
            this.groupBox2.Controls.Add(this.cmbTarjeta);
            this.groupBox2.Controls.Add(this.cmbDireccion);
            this.groupBox2.Controls.Add(this.btnAgregarTarj);
            this.groupBox2.Controls.Add(this.btnEliminarDire);
            this.groupBox2.Controls.Add(this.btnEliminarTarj);
            this.groupBox2.Controls.Add(this.btnAgregarDire);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtTelefono);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCuil);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDocumento);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTipoDoc);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtApellido);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(9, 104);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(434, 299);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles del Cliente";
            // 
            // cmbTarjeta
            // 
            this.cmbTarjeta.DropDownHeight = 500;
            this.cmbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjeta.DropDownWidth = 800;
            this.cmbTarjeta.FormattingEnabled = true;
            this.cmbTarjeta.IntegralHeight = false;
            this.cmbTarjeta.Location = new System.Drawing.Point(143, 269);
            this.cmbTarjeta.Name = "cmbTarjeta";
            this.cmbTarjeta.Size = new System.Drawing.Size(231, 21);
            this.cmbTarjeta.TabIndex = 32;
            // 
            // cmbDireccion
            // 
            this.cmbDireccion.DropDownHeight = 500;
            this.cmbDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDireccion.DropDownWidth = 800;
            this.cmbDireccion.FormattingEnabled = true;
            this.cmbDireccion.IntegralHeight = false;
            this.cmbDireccion.Location = new System.Drawing.Point(143, 218);
            this.cmbDireccion.Name = "cmbDireccion";
            this.cmbDireccion.Size = new System.Drawing.Size(231, 21);
            this.cmbDireccion.TabIndex = 31;
            // 
            // btnAgregarTarj
            // 
            this.btnAgregarTarj.Location = new System.Drawing.Point(378, 269);
            this.btnAgregarTarj.Name = "btnAgregarTarj";
            this.btnAgregarTarj.Size = new System.Drawing.Size(20, 20);
            this.btnAgregarTarj.TabIndex = 30;
            this.btnAgregarTarj.Text = "+";
            this.btnAgregarTarj.UseVisualStyleBackColor = true;
            this.btnAgregarTarj.Click += new System.EventHandler(this.btnAgregarTarj_Click);
            // 
            // btnEliminarDire
            // 
            this.btnEliminarDire.Location = new System.Drawing.Point(404, 218);
            this.btnEliminarDire.Name = "btnEliminarDire";
            this.btnEliminarDire.Size = new System.Drawing.Size(20, 20);
            this.btnEliminarDire.TabIndex = 29;
            this.btnEliminarDire.Text = "-";
            this.btnEliminarDire.UseVisualStyleBackColor = true;
            this.btnEliminarDire.Click += new System.EventHandler(this.btnEliminarDire_Click);
            // 
            // btnEliminarTarj
            // 
            this.btnEliminarTarj.Location = new System.Drawing.Point(404, 269);
            this.btnEliminarTarj.Name = "btnEliminarTarj";
            this.btnEliminarTarj.Size = new System.Drawing.Size(20, 20);
            this.btnEliminarTarj.TabIndex = 28;
            this.btnEliminarTarj.Text = "-";
            this.btnEliminarTarj.UseVisualStyleBackColor = true;
            this.btnEliminarTarj.Click += new System.EventHandler(this.btnEliminarTarj_Click);
            // 
            // btnAgregarDire
            // 
            this.btnAgregarDire.Location = new System.Drawing.Point(378, 218);
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
            this.label9.Text = "Tarjeta:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Fecha de Nacimiento:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Direccion:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(143, 192);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(231, 20);
            this.txtTelefono.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Telefono:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(143, 166);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(231, 20);
            this.txtMail.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Mail:";
            // 
            // txtCuil
            // 
            this.txtCuil.Location = new System.Drawing.Point(143, 140);
            this.txtCuil.Name = "txtCuil";
            this.txtCuil.Size = new System.Drawing.Size(231, 20);
            this.txtCuil.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "CUIL:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(143, 114);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(231, 20);
            this.txtDocumento.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Documento:";
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Location = new System.Drawing.Point(143, 88);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.ReadOnly = true;
            this.txtTipoDoc.Size = new System.Drawing.Size(231, 20);
            this.txtTipoDoc.TabIndex = 8;
            this.txtTipoDoc.Text = "DNI";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Tipo de Documento:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(143, 62);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(231, 20);
            this.txtApellido.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(143, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(231, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Nombre:";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Location = new System.Drawing.Point(143, 245);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(231, 20);
            this.dtpFechaNac.TabIndex = 33;
            // 
            // FormAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 475);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormAlta";
            this.Text = "FormAlta";
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
        public System.Windows.Forms.ComboBox cmbTarjeta;
        public System.Windows.Forms.ComboBox cmbDireccion;
        private System.Windows.Forms.Button btnAgregarTarj;
        private System.Windows.Forms.Button btnEliminarDire;
        private System.Windows.Forms.Button btnEliminarTarj;
        private System.Windows.Forms.Button btnAgregarDire;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCuil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
    }
}