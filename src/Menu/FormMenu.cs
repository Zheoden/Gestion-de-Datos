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

namespace PalcoNet.Menu {

    public partial class FormMenu : Form {

        public FormMenu() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string opcion = cmbMenu.Text;
            opcion = opcion.Replace(' ', '_');

            this.Hide();
            Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + opcion + "." + "Form1").Unwrap();
            nextForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e) {
            foreach (Funcionalidad func in VariablesGlobales.usuario.funcionalidades) {
                cmbMenu.Items.Add(func.descripcion.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
