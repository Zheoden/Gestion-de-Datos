using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
                cmbTarjeta.Items.Add("Datos de la Tarjeta(Numero##Titular##Vencimiento##Tipo##Codigo de Seguidad): " + testDialog.txtNumero.Text + "##" + testDialog.txtTitular.Text + "##" + testDialog.txtVencimiento.Text + "##" + testDialog.cmbTipos.Text + "##" + testDialog.txtCodSeg.Text);
            }
        }

        private void btnEliminarTarj_Click(object sender, EventArgs e) {
            cmbTarjeta.Items.Remove(cmbTarjeta.SelectedItem);
        }

        private void btnAgregarDire_Click(object sender, EventArgs e) {
            FormDireccion testDialog = new FormDireccion();
            if (testDialog.ShowDialog(this) == DialogResult.OK) {
                cmbDireccion.Items.Add("Datos de la direccion(Calle##Numero##Piso##Departamento##Localidad##Codigo Postal): " + testDialog.txtCalle.Text + "##" + testDialog.txtNumero.Text + "##" + testDialog.txtPiso.Text + "##" + testDialog.txtDepartamento.Text + "##" + testDialog.txtLocalidad.Text + "##" + testDialog.txtCodigoPostal.Text);
            }
        }

        private void btnEliminarDire_Click(object sender, EventArgs e) {
            cmbDireccion.Items.Remove(cmbDireccion.SelectedItem);
        }

        private void btnAlta_Click(object sender, EventArgs e) {
            foreach (string item in cmbTarjeta.Items) {
                string[] items = item.Split(';');
                SqlConnection conn = new SqlConnection(Connection.getStringConnection());
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO EL_REJUNTE.Direccion (dire_calle, dire_numero, dire_piso, dire_depto, dire_localidad, dire_codigo_postal) " +
                                      "VALUES ('" + "" + "',)";
                command.Connection = conn;
                command.Connection.Open();
                int rows = command.ExecuteNonQuery();
                command.Connection.Close();
                conn.Close();
            }
        }
    }
}
