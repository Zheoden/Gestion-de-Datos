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

namespace PalcoNet.Abm_Grado {
    public partial class FormAlta : Form {
        public FormAlta() {
            InitializeComponent();
            cmbTipos.Items.Add("Alta");
            cmbTipos.Items.Add("Media");
            cmbTipos.Items.Add("Baja");
        }

        private void btnAlta_Click(object sender, EventArgs e) {
            Grado grado = new Grado();

            if (validarDatos()) {

                grado.prioridad = cmbTipos.Text;
                grado.comision = Int32.Parse(txtComision.Text);
                grado.porcentaje = Int32.Parse(txtPorcentaje.Text);

                /* Creo el Cliente */
                if (!DBHelper.altaGrado(grado)) {
                    MessageBox.Show("Se produjo un error al intentar dar de alta el Grado");
                }
                else {
                    MessageBox.Show("El Grado se creo correctamente.");
                    this.Close();
                }
            }
        }

        private Boolean validarDatos() {

            int numero;

            if (cmbTipos.Text != "" && txtComision.Text != "" && txtPorcentaje.Text != "") {
                if (Int32.TryParse(txtComision.Text, out numero) && Int32.TryParse(txtPorcentaje.Text, out numero)) {
                    if (DBHelper.gradoDontExist(cmbTipos.Text, Int32.Parse(txtComision.Text), Int32.Parse(txtPorcentaje.Text))) {

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

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
