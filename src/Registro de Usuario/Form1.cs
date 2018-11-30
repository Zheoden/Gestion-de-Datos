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

namespace PalcoNet.Registro_de_Usuario {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {
            Usuario newUser = new Usuario();
            if (validarDatos()) {
                newUser.username = tb_user.Text;
                newUser.password = Encrypt.Sha256(tb_pass.Text);
                if (!DBHelper.clienteDontExistCuil(tb_cuit_cuil.Text)) {//Si es Cliente
                    newUser.roles = new List<Rol>();
                    Rol rol = new Rol();
                    rol.nombre = "Cliente";
                    newUser.roles.Add(rol);

                }
                else if (!DBHelper.EmpresaDontExistCuit(tb_cuit_cuil.Text)) {
                    //Si es empresa
                    newUser.roles = new List<Rol>();
                    Rol rol = new Rol();
                    rol.nombre = "Empresa";
                    newUser.roles.Add(rol);
                }

                //query
                if (!DBHelper.altaUsuario(newUser)) {
                    MessageBox.Show("Se produjo un error intenta dar de alta el usuario");
                }
                else {
                    MessageBox.Show("El usuario se creo correctamente.");
                    this.Close();
                }
            }
        }

        private Boolean validarDatos() {
            if (tb_user.Text != "" && tb_pass.Text != "" && tb_pass_confirm.Text != "" && tb_cuit_cuil.Text != "") {
                if (!DBHelper.existUser(tb_user.Text)) {
                    if (tb_pass.Text == tb_pass_confirm.Text) {
                        if (!DBHelper.clienteDontExistCuil(tb_cuit_cuil.Text) || !DBHelper.EmpresaDontExistCuit(tb_cuit_cuil.Text)) {
                            return true;
                        }
                        else {
                            MessageBox.Show("El Cliente/Empresa no existe en la base de datos");
                        }
                    }
                    else {
                        MessageBox.Show("Las contraseñas no coinciden, por favor vuelva a escribirla");
                    }
                }
                else {
                    MessageBox.Show("El nombre de usuario ya existe!");
                }
            }
            else {
                MessageBox.Show("Debe completar todos los campos para poder dar de alta el usuario");
            }
            return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }
    }

}
