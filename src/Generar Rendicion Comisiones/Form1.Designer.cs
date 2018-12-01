namespace PalcoNet.Generar_Rendicion_Comisiones
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarAplicacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clie_documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compra_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compra_cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ubica_tipo_descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ubica_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.cerrarAplicacionToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(695, 24);
            this.menu.TabIndex = 113;
            this.menu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // cerrarAplicacionToolStripMenuItem
            // 
            this.cerrarAplicacionToolStripMenuItem.Name = "cerrarAplicacionToolStripMenuItem";
            this.cerrarAplicacionToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.cerrarAplicacionToolStripMenuItem.Text = "Cerrar aplicacion";
            this.cerrarAplicacionToolStripMenuItem.Click += new System.EventHandler(this.cerrarAplicacionToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(256, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 50);
            this.pictureBox1.TabIndex = 119;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dgvCompras);
            this.groupBox3.Location = new System.Drawing.Point(7, 131);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(679, 409);
            this.groupBox3.TabIndex = 118;
            this.groupBox3.TabStop = false;
            // 
            // dgvCompras
            // 
            this.dgvCompras.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullName,
            this.clie_documento,
            this.compra_fecha,
            this.compra_cantidad,
            this.ubica_tipo_descripcion,
            this.ubica_precio});
            this.dgvCompras.Location = new System.Drawing.Point(5, 42);
            this.dgvCompras.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.RowTemplate.Height = 24;
            this.dgvCompras.Size = new System.Drawing.Size(663, 356);
            this.dgvCompras.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 26);
            this.label1.TabIndex = 117;
            this.label1.Text = "Rendicion de Comisiones";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Location = new System.Drawing.Point(196, 544);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(269, 34);
            this.btnModificar.TabIndex = 120;
            this.btnModificar.Text = "Generar Rendicion de Comisiones";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(412, 26);
            this.label2.TabIndex = 117;
            this.label2.Text = "Recuerde que toda la informacion mostrada en este listado es de compras facturada" +
    "s.\r\nLas compras en proceso de facturacion NO se muestran en este listado.";
            // 
            // fullName
            // 
            this.fullName.HeaderText = "Nombre del Comprador";
            this.fullName.Name = "fullName";
            this.fullName.ReadOnly = true;
            // 
            // clie_documento
            // 
            this.clie_documento.HeaderText = "Documento";
            this.clie_documento.Name = "clie_documento";
            this.clie_documento.ReadOnly = true;
            // 
            // compra_fecha
            // 
            this.compra_fecha.HeaderText = "Fecha de Compra";
            this.compra_fecha.Name = "compra_fecha";
            this.compra_fecha.ReadOnly = true;
            // 
            // compra_cantidad
            // 
            this.compra_cantidad.HeaderText = "Cantidad";
            this.compra_cantidad.Name = "compra_cantidad";
            this.compra_cantidad.ReadOnly = true;
            // 
            // ubica_tipo_descripcion
            // 
            this.ubica_tipo_descripcion.HeaderText = "Descripcion de Ubicacion";
            this.ubica_tipo_descripcion.Name = "ubica_tipo_descripcion";
            this.ubica_tipo_descripcion.ReadOnly = true;
            // 
            // ubica_precio
            // 
            this.ubica_precio.HeaderText = "Precio";
            this.ubica_precio.Name = "ubica_precio";
            this.ubica_precio.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 586);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Rendicion por Comisiones";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarAplicacionToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clie_documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn compra_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn compra_cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ubica_tipo_descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ubica_precio;
    }
}