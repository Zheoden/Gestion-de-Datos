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


namespace PalcoNet.Abm_Grado {
    public partial class FormModificacion : Form {

        Grado grado = new Grado();

        public FormModificacion() {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e) {

            if (validarDatos()) {

                grado.prioridad = txtTipos.Text;
                grado.comision = Int32.Parse(txtComision.Text);

                if (!DBHelper.modificarGrado(grado)) {
                    MessageBox.Show("Se produjo un error al intentar modificar el Grado");
                }
                else {
                    MessageBox.Show("El Grado se modifico correctamente.");
                    this.Close();
                }
            }
        }

        private void cargarGrado() {

            grado = DBHelper.getGrado(Int32.Parse(txtID.Text));
            txtTipos.Text = grado.prioridad;
            txtComision.Text = grado.comision.ToString();
        }

        private Boolean validarDatos() {

            int numero;

            if (txtTipos.Text != "" && txtComision.Text != "") {
                if (Int32.TryParse(txtComision.Text, out numero)) {
                    if (DBHelper.gradoDontExist(txtTipos.Text, Int32.Parse(txtComision.Text))) {
                        return true;
                    }
                    else {
                        MessageBox.Show("Ya exite un Grado con esas Caracteristicas.");
                    }
                }
                else {
                    MessageBox.Show("Todos los campos deben ser un Numero.");
                }
            }
            else {
                MessageBox.Show("Todos los campos son obligatorios.");
            }
            return false;
        }

        private void FormModificacion_Load(object sender, EventArgs e) {
            cargarGrado();
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
