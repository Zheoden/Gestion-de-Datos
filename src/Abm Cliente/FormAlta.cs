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
    public partial class FormAlta : Form {
        public FormAlta() {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void btnAgregarTarj_Click(object sender, EventArgs e) {
            FormTarjeta testDialog = new FormTarjeta();
            if (testDialog.ShowDialog(this) == DialogResult.OK) {
                cmbTarjeta.Items.Add("Numero de Tarjeta: " + testDialog.txtNumero.Text + "\nTitular: " + testDialog.txtTitular.Text + "\nVencimiento: " + testDialog.txtVencimiento.Text + "\nTipo: " + testDialog.cmbTipos.Text +"\nCodigo: " + testDialog.txtCodSeg.Text );
            }
        }

        private void btnEliminarTarj_Click(object sender, EventArgs e) {
            cmbTarjeta.Items.Remove(cmbTarjeta.SelectedItem);
        }
    }
}
