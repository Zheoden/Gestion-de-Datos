using PalcoNet.Objetos;
using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            cargarCompras();
            foreach (Funcionalidad func in VariablesGlobales.usuario.funcionalidades) {
                ToolStripMenuItem item = new ToolStripMenuItem(func.descripcion);
                item.Tag = func.descripcion.ToString();

                menuToolStripMenuItem.DropDownItems.Add(item);

                item.Click += new EventHandler(eventClick);
            }
        }

        public void eventClick(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            string opcion = item.Tag.ToString();

            Menus menuSeleccionado = MenuHelper.getOpciones(opcion);

            this.Close();
            Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + menuSeleccionado.carpeta + "." + menuSeleccionado.form).Unwrap();
            nextForm.Show();
        }

        private void cerrarAplicacionToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnModificar_Click(object sender, EventArgs e) {

        }

        private void cargarCompras() {

            dgvCompras.Rows.Clear();
            dgvCompras.Refresh();
            int cont = 0;

            List<CompraNoFacturada> compras = DBHelper.comprasNoFacturadas();
            foreach (CompraNoFacturada item in compras) {
                dgvCompras.Rows.Add();
                dgvCompras.Rows[cont].Cells[0].Value = item.fullName;
                dgvCompras.Rows[cont].Cells[1].Value = item.documento;
                dgvCompras.Rows[cont].Cells[2].Value = item.fecha;
                dgvCompras.Rows[cont].Cells[3].Value = item.cantidad;
                dgvCompras.Rows[cont].Cells[4].Value = item.descripcion;
                dgvCompras.Rows[cont].Cells[5].Value = item.precio;
                cont++;

            }

        }
    }
}
