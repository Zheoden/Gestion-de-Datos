using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using PalcoNet.Utils;
using PalcoNet.Objetos;

namespace PalcoNet.Login {

    public partial class FormLogin : Form {

        public FormLogin() {
            InitializeComponent();
            txtUsuario.GotFocus += new EventHandler(this.UserGotFocus);
            txtUsuario.LostFocus += new EventHandler(this.UserLostFocus);
            txtPassword.GotFocus += new EventHandler(this.PassGotFocus);
            txtPassword.LostFocus += new EventHandler(this.PassLostFocus);
        }

        private void button_Login_Click(object sender, EventArgs e) {
            VariablesGlobales.usuario = new Usuario();
            VariablesGlobales.usuario.username = txtUsuario.Text;
            VariablesGlobales.usuario.password = txtPassword.Text;

            /* Verifico que sea un login valido */
            if (DBHelper.validLogin(VariablesGlobales.usuario.username, VariablesGlobales.usuario.password) && DBHelper.usuarioBloqueado(VariablesGlobales.usuario.username)) {
                //                MessageBox.Show("Bienvenido " + VariablesGlobales.usuario.username);
                DBHelper.cleanFailLogin(VariablesGlobales.usuario.username);
                VariablesGlobales.usuario = DBHelper.getUserData(VariablesGlobales.usuario.username);
                this.Hide();
                Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + "Login" + "." + "FormRoles").Unwrap();
                nextForm.Show();
            }
            else {
                DBHelper.addFailLogin(VariablesGlobales.usuario.username);
                VariablesGlobales.usuario = DBHelper.getUserData(VariablesGlobales.usuario.username);
                if (VariablesGlobales.usuario != null) {
                    if (VariablesGlobales.usuario.cant_logeo_error > 2 && VariablesGlobales.usuario.bloqueado) {
                        MessageBox.Show("Ingreso por lo menos 3 veces mal la contraseña. Su usuario fue bloqueado.");
                        DBHelper.bloquear(VariablesGlobales.usuario.username);
                    }
                    else if (!VariablesGlobales.usuario.habilitado) {
                        MessageBox.Show("Su usuario esta bloqueado. Reinicie su contraseña para volver a habilitarlo.");
                    }
                    else {
                        MessageBox.Show("El usuario o la contraseña son invalidos.");
                    }
                }
                else {
                    MessageBox.Show("El usuario o la contraseña son invalidos.");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void UserGotFocus(object sender, EventArgs e) {

            if (txtUsuario.Text == "Nombre de usuario") {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        public void UserLostFocus(object sender, EventArgs e) {

            if (txtUsuario.Text == "") {
                txtUsuario.Text = "Nombre de usuario";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        public void PassGotFocus(object sender, EventArgs e) {

            if (txtPassword.Text == "Contraseña") {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '*';
            }
        }

        public void PassLostFocus(object sender, EventArgs e) {

            if (txtPassword.Text == "") {
                txtPassword.Text = "Contraseña";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.PasswordChar = '\0';
            }
        }

        private void lblRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Hide();
            Form nextForm = (Form)Activator.CreateInstance(null, "PalcoNet" + "." + "Registro_de_Usuario" + "." + "Form1").Unwrap();
            nextForm.Show();
        }

        private void lblContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

        }
    }
}
