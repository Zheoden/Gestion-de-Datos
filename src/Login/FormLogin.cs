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
using PalcoNet.Abm_Rol;

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
        {/*
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
