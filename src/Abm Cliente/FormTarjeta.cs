using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente {
    public partial class FormTarjeta : Form {
        public FormTarjeta() {
            InitializeComponent();
            cmbTipos.Items.Add("Visa");
            cmbTipos.Items.Add("MasterCard");
            cmbTipos.Items.Add("AmericanExpress");
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnDarAlta_Click(object sender, EventArgs e) {

            if (txtCodSeg.Text != "" && txtNumero.Text != "" && txtTitular.Text != "" && txtVencimiento.Text != "" && cmbTipos.SelectedItem.ToString() != "") {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else {
                MessageBox.Show("Todos los campos son obligatorios, por favor verifique que toda la informacion sea correcta e intente nuevamente");
            }
        }
    }
}
