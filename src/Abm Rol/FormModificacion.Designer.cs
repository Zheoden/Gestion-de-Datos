namespace PalcoNet.Abm_Rol {
    partial class FormModificacion {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModificacion));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbHabilitado = new System.Windows.Forms.CheckBox();
            this.btnADerecha = new System.Windows.Forms.Button();
            this.btnAIzquierda = new System.Windows.Forms.Button();
            this.lstFuncionalidadesTotales = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstFuncionalidadesRol = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(309, 330);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(128, 59);
            this.btnCerrar.TabIndex = 34;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(207, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 50);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // btnModificacion
            // 
            this.btnModificacion.BackColor = System.Drawing.Color.SeaGreen;
            this.btnModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificacion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificacion.Location = new System.Drawing.Point(127, 330);
            this.btnModificacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(128, 59);
            this.btnModificacion.TabIndex = 32;
            this.btnModificacion.Text = "Confirmar Modificacion";
            this.btnModificacion.UseVisualStyleBackColor = false;
            this.btnModificacion.Click += new System.EventHandler(this.btnModificacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 26);
            this.label1.TabIndex = 30;
            this.label1.Text = "Modificacion de Rol";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHabilitado);
            this.groupBox1.Controls.Add(this.btnADerecha);
            this.groupBox1.Controls.Add(this.btnAIzquierda);
            this.groupBox1.Controls.Add(this.lstFuncionalidadesTotales);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstFuncionalidadesRol);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(7, 104);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(552, 222);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles del Rol";
            // 
            // cbHabilitado
            // 
            this.cbHabilitado.AutoSize = true;
            this.cbHabilitado.Location = new System.Drawing.Point(395, 32);
            this.cbHabilitado.Name = "cbHabilitado";
            this.cbHabilitado.Size = new System.Drawing.Size(73, 17);
            this.cbHabilitado.TabIndex = 38;
            this.cbHabilitado.Text = "Habilitado";
            this.cbHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnADerecha
            // 
            this.btnADerecha.Location = new System.Drawing.Point(254, 152);
            this.btnADerecha.Name = "btnADerecha";
            this.btnADerecha.Size = new System.Drawing.Size(42, 23);
            this.btnADerecha.TabIndex = 35;
            this.btnADerecha.Text = ">";
            this.btnADerecha.UseVisualStyleBackColor = true;
            this.btnADerecha.Click += new System.EventHandler(this.btnADerecha_Click);
            // 
            // btnAIzquierda
            // 
            this.btnAIzquierda.Location = new System.Drawing.Point(254, 123);
            this.btnAIzquierda.Name = "btnAIzquierda";
            this.btnAIzquierda.Size = new System.Drawing.Size(42, 23);
            this.btnAIzquierda.TabIndex = 36;
            this.btnAIzquierda.Text = "<";
            this.btnAIzquierda.UseVisualStyleBackColor = true;
            this.btnAIzquierda.Click += new System.EventHandler(this.btnAIzquierda_Click);
            // 
            // lstFuncionalidadesTotales
            // 
            this.lstFuncionalidadesTotales.FormattingEnabled = true;
            this.lstFuncionalidadesTotales.Location = new System.Drawing.Point(302, 83);
            this.lstFuncionalidadesTotales.Name = "lstFuncionalidadesTotales";
            this.lstFuncionalidadesTotales.Size = new System.Drawing.Size(231, 134);
            this.lstFuncionalidadesTotales.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Todas las Funcionalidades:";
            // 
            // lstFuncionalidadesRol
            // 
            this.lstFuncionalidadesRol.FormattingEnabled = true;
            this.lstFuncionalidadesRol.Location = new System.Drawing.Point(17, 83);
            this.lstFuncionalidadesRol.Name = "lstFuncionalidadesRol";
            this.lstFuncionalidadesRol.Size = new System.Drawing.Size(231, 134);
            this.lstFuncionalidadesRol.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Funcionalidades del Rol:";
            // 
            // txtNombre
            // 
            this.txtNombre.AcceptsReturn = true;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(106, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(231, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nombre del Rol:";
            // 
            // FormModificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 400);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnModificacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormModificacion";
            this.Text = "Modificacion de Roles";
            this.Load += new System.EventHandler(this.FormModificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnModificacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstFuncionalidadesRol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ListBox lstFuncionalidadesTotales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnADerecha;
        private System.Windows.Forms.Button btnAIzquierda;
        private System.Windows.Forms.CheckBox cbHabilitado;
    }
}