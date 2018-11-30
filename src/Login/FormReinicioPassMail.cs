using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Utils;
using PalcoNet.Objetos;

namespace PalcoNet.Login {
    public partial class FormReinicioPassMail : Form {
        public FormReinicioPassMail() {
            InitializeComponent();
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {
            validarDatos();
        }

        private Boolean validarDatos() {
            if (txtMail.Text != "" && txtPass.Text != "" && txtPassConfirm.Text != "" && txtUser.Text != "") {
                if (DBHelper.validLoginMail(txtUser.Text, txtMail.Text)) {
                    if (txtPass.Text == txtPassConfirm.Text) {
                        if (DBHelper.cambiarContraseña(txtUser.Text, txtPassConfirm.Text)) {
                            MessageBox.Show("Contraseña cambiada correctamente!");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else {
                            MessageBox.Show("Se produjo un error al cambiar la contraseña, por favor intente nuevamente y si el error persiste contacte al administrador.");
                        }
                    }
                    else {
                        MessageBox.Show("Las contraseñas no coinciden, por favor vuelva a escribirla");
                    }
                }
                else {
                    MessageBox.Show("El nombre de usuario no existe o la contraseña actual no coinciden.");
                }
            }
            else {
                MessageBox.Show("Debe completar todos los campos para poder cambiar la contraseña.");
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }
    }

}
