using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion {
    public partial class FormDireccion : Form {
        public FormDireccion() {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {

            if (txtLocalidad.Text != "" && txtCalle.Text != "" && txtNumero.Text != "" && txtPiso.Text != "" && txtCodigoPostal.Text != "" && txtDepartamento.Text != "") {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else {
                MessageBox.Show("Todos los campos son obligatorios, por favor verifique que toda la informacion sea correcta e intente nuevamente");
            }
        }
    }
}
