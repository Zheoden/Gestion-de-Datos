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

namespace PalcoNet.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.username = txtUsuario.Text;
            user.password = txtPassword.Text;

            /* Verifico que sea un login valido */
            if (UsuarioHelper.validLogin(user.username, user.password) && UsuarioHelper.usuarioHabilitado(user.username))
            {
                MessageBox.Show("Bienvenido!!!");
                UsuarioHelper.cleanFailLogin(user.username);
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña son invalidos");
                UsuarioHelper.addFailLogin(user.username);
                user = UsuarioHelper.getUserData(user.username);
                if (user != null)
                {
                    if (user.cant_logeo_error > 2)
                    {
                        MessageBox.Show("Ingreso por lo menos 3 veces mal la contraseña. Su usuario fue bloqueado");
                    }
                }
            }

            /* Me traigo los datos */
            //user = UsuarioHelper.getUserData("admin");
            /*
            Usuario user = new Usuario();
            user.username = txtUsuario.Text;
            user.password = txtPassword.Text;

            if (!Login.isValidUser(user))
            {
                MessageBox.Show("No es un usuario valido");
            }
            else
            {
                int intentos = Login.login(user, pass);

                if (intentos == 0)
                {
                    FormSeleccionRol fSeleccionRol = new FormSeleccionRol();
                    this.Hide();
                    fSeleccionRol.ShowDialog();
                    this.Close();
                }
                else if (intentos < 3)
                {
                    MessageBox.Show("La contraseña es erronea. Lleva intentos : " + intentos);
                }
                else
                {
                    MessageBox.Show("Contactese con el administrador para limpiar su clave");
                }
            }
        */}
    }
}
