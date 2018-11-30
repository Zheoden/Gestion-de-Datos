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
using PalcoNet.Objetos;

namespace PalcoNet.Abm_Rubro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gb_b_avanzada.Visible = false;
        }


        private void cb_busquedaAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_busquedaAvanzada.Checked)
            {
                gb_b_avanzada.Visible = true;
            }else
            {
                gb_b_avanzada.Visible = false;
            }
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

        private void cerrarAplicacionToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
