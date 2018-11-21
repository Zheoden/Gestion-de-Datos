using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Objetos;
using PalcoNet.Utils;

namespace PalcoNet.Abm_Rol {
    public partial class FormAlta : Form {
        public FormAlta() {
            InitializeComponent();
            cargarFuncionalidades();
        }

        private void cargarFuncionalidades() {

            List<Funcionalidad> func = DBHelper.getFuncionalidades();
            lstFuncionalidades.Items.Clear();
            foreach (Funcionalidad item in func) {

                lstFuncionalidades.Items.Add(item.descripcion);

            }
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {
            string rol = txtNombre.Text;
            if (rol != "") {
                if (DBHelper.rolExistDesHabilitado(rol)) {
                    MessageBox.Show("El rol que intenta crear ya existe y se encuentra inhabilitado.");
                }
                if (DBHelper.rolExistHabilitado(rol)) {
                    MessageBox.Show("El rol que intenta crear ya existe.");
                }
                if (DBHelper.rolDontExist(rol)) {
                    if (lstFuncionalidades.SelectedItems != null) {
                        //Datos Validos
                        List<String> funcionalidades = new List<String>();

                        foreach (string str in lstFuncionalidades.SelectedItems) {
                            funcionalidades.Add(str);
                        }
                        if (DBHelper.altaRol(rol, funcionalidades)) {
                            MessageBox.Show("Rol creado correctamente.");
                            txtNombre.Text = "";
                            cargarFuncionalidades();
                            this.Close();
                        }
                        else {
                            MessageBox.Show("No se pudo crear el Rol. Por favor contacte al administrador.");
                        }
                    }
                    else {
                        MessageBox.Show("Seleccione por lo menos una funcionalidad para el Rol.");
                    }
                }
            }
            else {
                MessageBox.Show("Debe ingresar un nombre para el Rol.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Hide();
        }
   
    }
}
