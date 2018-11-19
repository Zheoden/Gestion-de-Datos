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
    public partial class FormModificacion : Form {
        public FormModificacion() {
            InitializeComponent();
        }

        private void cargarFuncionalidades() {

            List<Funcionalidad> func = ClienteHelper.getFuncionalidades();
            lstFuncionalidadesRol.Items.Clear();
            foreach (Funcionalidad item in func) {

                lstFuncionalidadesTotales.Items.Add(item.descripcion);

            }
        }

        private void cargarHabilitado() {
            cbHabilitado.Checked = ClienteHelper.rolStatusHabilitado(txtNombre.Text);
        }

        private void seleccionarFuncionalidadesDelRol() {

            List<Funcionalidad> func = ClienteHelper.getFuncionalidadesPorRol(txtNombre.Text);
            foreach (Funcionalidad item in func) {

                lstFuncionalidadesRol.Items.Add(item.descripcion);
                lstFuncionalidadesTotales.Items.Remove(item.descripcion);

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void FormModificacion_Load(object sender, EventArgs e) {
            cargarFuncionalidades();
            seleccionarFuncionalidadesDelRol();
            cargarHabilitado();
        }

        private void btnAIzquierda_Click(object sender, EventArgs e) {
            if (lstFuncionalidadesTotales.SelectedItem != null) {
                lstFuncionalidadesRol.Items.Add(lstFuncionalidadesTotales.SelectedItem.ToString());
                lstFuncionalidadesTotales.Items.Remove(lstFuncionalidadesTotales.SelectedItem.ToString());
            }
        }

        private void btnADerecha_Click(object sender, EventArgs e) {
            if (lstFuncionalidadesRol.SelectedItem != null) {
                lstFuncionalidadesTotales.Items.Add(lstFuncionalidadesRol.SelectedItem.ToString());
                lstFuncionalidadesRol.Items.Remove(lstFuncionalidadesRol.SelectedItem.ToString());
            }
        }

        private void btnModificacion_Click(object sender, EventArgs e) {

            ClienteHelper.bajaFuncionalidades(txtNombre.Text);

            foreach (string item in lstFuncionalidadesRol.Items) {
                ClienteHelper.altaFuncionalidades(txtNombre.Text, item);
            }
            if(cbHabilitado.Checked){
                ClienteHelper.habilitarRol(txtNombre.Text);
            }
            else{
                ClienteHelper.deshabilitarRol(txtNombre.Text);
            }

            MessageBox.Show("Modificacion realizada con exito!!");
        }

    }
}
