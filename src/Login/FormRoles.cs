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

                this.Close();
                Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + "Menu" + "." + "FormMenu").Unwrap();
                nextForm.Show();
            }
            else {
                MessageBox.Show("Seleccion algun rol de la lista.");
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            if (VariablesGlobales.usuario.roles.Count > 1) {
                foreach (Rol rol in VariablesGlobales.usuario.roles) {
                    cmbMenu.Items.Add(rol.nombre.ToString());
                }
            }

            if (VariablesGlobales.usuario.roles.Count == 1) {
                MessageBox.Show("Se detecto que tiene solo un rol asignado (" + VariablesGlobales.usuario.roles[0].nombre + "), por lo que se conectó automaticamente con ese rol.");
                VariablesGlobales.usuario = DBHelper.getUserFuncionalidades(VariablesGlobales.usuario, VariablesGlobales.usuario.roles[0].nombre);
                this.Close();
                Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + "Menu" + "." + "FormMenu").Unwrap();
                nextForm.Show();
            }

            if (VariablesGlobales.usuario.roles.Count == 0) {
                MessageBox.Show("Se detecto que no tiene ningun rol asignado, por lo que no podra continuar operando. Por favor contacte a un administrador.");
                Application.Exit();
            }
        }
    }
}
