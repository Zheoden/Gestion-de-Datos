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

namespace PalcoNet.Menu {

    public partial class FormMenu : Form {

        public FormMenu() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string opcion = cmbMenu.Text;
            if (opcion != "") {
                Menus menuSeleccionado = MenuHelper.getOpciones(opcion);

                this.Hide();
                Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + menuSeleccionado.carpeta + "." + menuSeleccionado.form).Unwrap();
                nextForm.Show();
            }
            else {
                MessageBox.Show("Seleccione una opcion de la lista.");
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            foreach (Funcionalidad func in VariablesGlobales.usuario.funcionalidades) {
                cmbMenu.Items.Add(func.descripcion.ToString());
            }
        }
    }
}
