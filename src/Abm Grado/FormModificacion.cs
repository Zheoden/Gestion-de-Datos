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
            cmbTipos.Items.Add("Alta");
            cmbTipos.Items.Add("Media");
            cmbTipos.Items.Add("Baja");
            cmbTipos.Items.Add("Otro");
        }

        private void btnAlta_Click(object sender, EventArgs e) {

            if (validarDatos()) {

                grado.prioridad = cmbTipos.Text;
                grado.comision = Int32.Parse(txtComision.Text);

                /* Creo el Cliente */
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
            cmbTipos.SelectedItem = grado.prioridad;
            txtComision.Text = grado.comision.ToString();
        }

        private Boolean validarDatos() {

            int numero;

            if (cmbTipos.Text != "" && txtComision.Text != "") {
                if (Int32.TryParse(txtComision.Text, out numero)) {
                    if (DBHelper.gradoDontExist(cmbTipos.Text, Int32.Parse(txtComision.Text))) {
                        return true;
                    }
                    else {
                        MessageBox.Show("Ya exite un cliente con ese tipo y numero de documento.");
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

    }
}
