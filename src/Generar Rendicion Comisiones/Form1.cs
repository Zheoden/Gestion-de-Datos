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

        List<CompraNoFacturada> compras = DBHelper.comprasNoFacturadas();

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
            int cont = 0;
            foreach (DataGridViewRow row in dgvCompras.Rows) {
                CompraNoFacturada compra = new CompraNoFacturada();
                compra.id = Convert.ToInt32(row.Cells[0].Value.ToString());
                compra.fullName = row.Cells[1].Value.ToString();
                compra.documento = row.Cells[2].Value.ToString();
                compra.fecha = Convert.ToDateTime(row.Cells[3].Value.ToString());
                compra.cantidad = Convert.ToInt32(row.Cells[4].Value.ToString());
                compra.descripcion = row.Cells[5].Value.ToString();
                compra.precio = Convert.ToInt32(row.Cells[6].Value.ToString());
                compra.ubica_id = compras[cont].ubica_id;
                compra.compra_empresa_id = compras[cont].compra_empresa_id;
                if (compra != null) {
                    if (DBHelper.altaItem_Factura(compra, DBHelper.altaFactura(compra)) && DBHelper.facturarCompra(compra.id)) {
                        MessageBox.Show("Se Facturo correctamente!");
                        compras = DBHelper.comprasNoFacturadas();
                    }
                }
                cont++;
            }
            cargarCompras();
        }

        private void cargarCompras() {

            dgvCompras.Rows.Clear();
            dgvCompras.Refresh();
            int cont = 0;

            foreach (CompraNoFacturada item in compras) {
                dgvCompras.Rows.Add();
                dgvCompras.Rows[cont].Cells[0].Value = item.id;
                dgvCompras.Rows[cont].Cells[1].Value = item.fullName;
                dgvCompras.Rows[cont].Cells[2].Value = item.documento;
                dgvCompras.Rows[cont].Cells[3].Value = item.fecha;
                dgvCompras.Rows[cont].Cells[4].Value = item.cantidad;
                dgvCompras.Rows[cont].Cells[5].Value = item.descripcion;
                dgvCompras.Rows[cont].Cells[6].Value = item.precio;
                cont++;

            }
        }
    }
}
