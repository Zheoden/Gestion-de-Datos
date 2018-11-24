using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PalcoNet.Utils;
using Microsoft.VisualBasic;
using PalcoNet.Objetos;
using System.Globalization;

namespace PalcoNet.Comprar {
    public partial class Form1 : Form {
        private static int totalRecords = DBHelper.clieGetHistorial(DBHelper.clienteGetId(VariablesGlobales.usuario.id)).Count;
        private const int pageSize = 13;

        public Form1() {
            InitializeComponent();
            cargarCategorias();

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            bindingSource1.DataSource = new PageOffsetList();

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e) {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            int offset = (int)bindingSource1.Current;
            var records = new List<ClienteHistorial>();
            for (int i = offset; i < offset + pageSize && i < totalRecords; i++) {
                ClienteHistorial test = new ClienteHistorial();
                records.Add(DBHelper.clieGetHistorial(DBHelper.clienteGetId(VariablesGlobales.usuario.id))[i]);
            }
            dgvEspectaculos.DataSource = records;
        }

        class PageOffsetList : System.ComponentModel.IListSource {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList() {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }


        public void cargarCategorias() {
            cboCategoria.ValueMember = "id";
            cboCategoria.DisplayMember = "descripcion";
            List<Rubro> rubros = DBHelper.getRubros();
            foreach (Rubro rubro in rubros) {
                cboCategoria.Items.Add(rubro);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

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

        private void btnContinuar_Click(object sender, EventArgs e) {

            if (dgvEspectaculos.SelectedCells.Count > 0) {
                int selectedrowindex = dgvEspectaculos.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEspectaculos.Rows[selectedrowindex];
                string publicacionSeleccionadaId = Convert.ToString(selectedRow.Cells["publi_id"].Value);
                string publicacionSeleccionadaDescripcion = Convert.ToString(selectedRow.Cells["publi_descripcion"].Value);
                if (publicacionSeleccionadaId != "") {
                    FormComprar testDialog = new FormComprar();
                    testDialog.txtPubli_id.Text = publicacionSeleccionadaId;
                    testDialog.txtPubli_descripcion.Text = publicacionSeleccionadaDescripcion;
                    testDialog.cargarTipo(Convert.ToInt32(publicacionSeleccionadaId));
                    testDialog.ShowDialog(this);

                }
                else {
                    MessageBox.Show("Seleccionó una celda invalida, por favor seleccione otra.");
                }
            }
            else {
                MessageBox.Show("Buscar una publicacion para poder continuar con la compra.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void cerrarAplicacionToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

    }
}
