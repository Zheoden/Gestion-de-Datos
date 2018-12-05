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
        }

        private void btnAlta_Click(object sender, EventArgs e) {
            Grado grado = new Grado();

            if (validarDatos()) {

                grado.prioridad = txtTipos.Text;
                grado.comision = Int32.Parse(txtComision.Text);

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

            if (txtTipos.Text != "" && txtComision.Text != "") {
                if (Int32.TryParse(txtComision.Text, out numero)) {
                    if (DBHelper.gradoDontExist(txtTipos.Text, Int32.Parse(txtComision.Text))) {

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
