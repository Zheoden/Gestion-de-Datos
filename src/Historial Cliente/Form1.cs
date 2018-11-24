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

namespace PalcoNet.Historial_Cliente
{
    public partial class Form1 : Form
    {
        private static int totalRecords = DBHelper.clieGetHistorial(DBHelper.clienteGetId(VariablesGlobales.usuario.id)).Count;
        private const int pageSize = 13;

        public Form1()
        {
            InitializeComponent();

            bindingNavigator1.BindingSource = bindingSource1;
            bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            bindingSource1.DataSource = new PageOffsetList();
        }

        private void Form1_Load(object sender, EventArgs e) {
            foreach (Funcionalidad func in VariablesGlobales.usuario.funcionalidades) {
                ToolStripMenuItem item = new ToolStripMenuItem(func.descripcion);
                item.Tag = func.descripcion.ToString();

                menuToolStripMenuItem.DropDownItems.Add(item);

                item.Click += new EventHandler(eventClick);
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e) {
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            int offset = (int)bindingSource1.Current;
            var records = new List<ClienteHistorial>();
            for (int i = offset; i < offset + pageSize && i < totalRecords; i++) {
                ClienteHistorial test = new ClienteHistorial();
                records.Add(DBHelper.clieGetHistorial(DBHelper.clienteGetId(VariablesGlobales.usuario.id))[i]);
            }
            dgvHistorial.DataSource = records;
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
    }
}
