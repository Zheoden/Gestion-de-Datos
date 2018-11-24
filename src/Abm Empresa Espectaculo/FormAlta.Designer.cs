namespace PalcoNet.Abm_Empresa_Espectaculo {
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
            this.cmbDireccion = new System.Windows.Forms.ComboBox();
            this.btnEliminarDire = new System.Windows.Forms.Button();
            this.btnAgregarDire = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCuil = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(216, 284);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(128, 34);
            this.btnCerrar.TabIndex = 44;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(115, 13);
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
            this.btnAlta.Location = new System.Drawing.Point(84, 284);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(128, 34);
            this.btnAlta.TabIndex = 42;
            this.btnAlta.Text = "Confirmar Alta";
            this.btnAlta.UseVisualStyleBackColor = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 26);
            this.label2.TabIndex = 40;
            this.label2.Text = "Alta de Empresas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbDireccion);
            this.groupBox2.Controls.Add(this.btnEliminarDire);
            this.groupBox2.Controls.Add(this.btnAgregarDire);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtTelefono);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCuil);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(11, 105);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(434, 175);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles de Empresas";
            // 
            // cmbDireccion
            // 
            this.cmbDireccion.DropDownHeight = 500;
            this.cmbDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDireccion.DropDownWidth = 800;
            this.cmbDireccion.FormattingEnabled = true;
            this.cmbDireccion.IntegralHeight = false;
            this.cmbDireccion.Location = new System.Drawing.Point(143, 113);
            this.cmbDireccion.Name = "cmbDireccion";
            this.cmbDireccion.Size = new System.Drawing.Size(231, 21);
            this.cmbDireccion.TabIndex = 31;
            // 
            // btnEliminarDire
            // 
            this.btnEliminarDire.Location = new System.Drawing.Point(404, 113);
            this.btnEliminarDire.Name = "btnEliminarDire";
            this.btnEliminarDire.Size = new System.Drawing.Size(20, 20);
            this.btnEliminarDire.TabIndex = 29;
            this.btnEliminarDire.Text = "-";
            this.btnEliminarDire.UseVisualStyleBackColor = true;
            this.btnEliminarDire.Click += new System.EventHandler(this.btnEliminarDire_Click);
            // 
            // btnAgregarDire
            // 
            this.btnAgregarDire.Location = new System.Drawing.Point(378, 113);
            this.btnAgregarDire.Name = "btnAgregarDire";
            this.btnAgregarDire.Size = new System.Drawing.Size(20, 20);
            this.btnAgregarDire.TabIndex = 27;
            this.btnAgregarDire.Text = "+";
            this.btnAgregarDire.UseVisualStyleBackColor = true;
            this.btnAgregarDire.Click += new System.EventHandler(this.btnAgregarDire_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Direccion:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(143, 87);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(231, 20);
            this.txtTelefono.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Telefono:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(143, 61);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(231, 20);
            this.txtMail.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 64);
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
            this.txtCuil.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "CUIT (Sin guiones ( - ) ):";
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
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Razon Social:";
            // 
            // FormAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 341);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormAlta";
            this.Text = "Form2";
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
        public System.Windows.Forms.ComboBox cmbDireccion;
        private System.Windows.Forms.Button btnEliminarDire;
        private System.Windows.Forms.Button btnAgregarDire;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCuil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label14;
    }
}