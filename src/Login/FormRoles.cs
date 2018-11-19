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

namespace PalcoNet.Login {

    public partial class FormRoles : Form {

        public FormRoles() {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            string rol = cmbMenu.Text;
            if (rol != "") {
                VariablesGlobales.usuario = DBHelper.getUserFuncionalidades(VariablesGlobales.usuario, rol);

                this.Hide();
                Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + "Menu" + "." + "FormMenu").Unwrap();
                nextForm.Show();
            }
            else {
                MessageBox.Show("Seleccion algun rol de la lista.");
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            foreach (Rol rol in VariablesGlobales.usuario.roles) {
                cmbMenu.Items.Add(rol.nombre.ToString());
            }
        }
    }
}
